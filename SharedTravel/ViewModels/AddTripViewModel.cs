using System.Collections.ObjectModel;
using CommunityToolkit.Mvvm.ComponentModel;
using CommunityToolkit.Mvvm.Input;
using SharedTravel.Data;
using SharedTravel.Models;
using SharedTravel.Models.Helpers;

namespace SharedTravel.ViewModels;

public partial class AddTripViewModel : ObservableObject
{
    #region COLLECTIONS
        public List<CountryOption> Countries { get; } =
            Enum.GetValues<CountryCode>()
                .Select(c => new CountryOption { Value = c, Name = c.GetDescription() })
                .OrderBy(o => o.Name)
                .ToList();//  Список стран: создаём список объектов CountryOption, где Name - это описание страны, а Value - это enum CountryCode
        public List<CurrencyCode> Currencies { get; } = Enum.GetValues<CurrencyCode>().ToList();//  Список валют: сами значения enum, Picker покажет их как CNY, USD, EUR...
        public ObservableCollection<City> Cities { get; } = new();
        public ObservableCollection<Participant> Participants { get; } = new();
    #endregion

    #region FORM_FIELDS
        [ObservableProperty] private string _tripTitle = "";
        [ObservableProperty] private DateTime _tripStartDate = DateTime.Today;
        [ObservableProperty] private DateTime _tripEndDate = DateTime.Today;
        [ObservableProperty] private decimal _tripPlannedBudget;
        [ObservableProperty] private CountryOption? _selectedCountry;
        [ObservableProperty] private CurrencyCode _selectedCurrency = CurrencyCode.USD; // Выбранная валюта, по умолчанию USD
        [ObservableProperty] private string _newCityName = "";
        [ObservableProperty] private string _newParticipant = "";
    #endregion
    

    public AddTripViewModel()
    {
        SelectedCountry = Countries.First(c => c.Value == CountryCode.US);
    }
    
    [RelayCommand]
    private async Task SaveNewTripToDb()
    {
        // Страна не выбрана: сохранять нечего, страница остаётся открытой.
        if (SelectedCountry == null)
            return;

        using var db = new AppDbContext();
        
        Trip trip = new Trip
        {
            Name = TripTitle,
            StartDate = TripStartDate,
            EndDate = TripEndDate,
            PlannedBudget = TripPlannedBudget,
            CountryCode = SelectedCountry.Value,
            CurrencyCode = SelectedCurrency,
            Cities = Cities.ToList(),
            Participants = Participants.ToList(),
        };

        db.Trips.Add(trip);
        await db.SaveChangesAsync();

        await Shell.Current.GoToAsync(".."); // Go back to the main screen
    }

    [RelayCommand]
    private void AddCity()
    {
        var cityName = NewCityName.Trim();
        if(cityName.Length == 0) return;
        
        City city = new City();
        city.Name = cityName;
        //  TODO: Add city.TripId = trip.TripId
        
        Cities.Add(city);
        NewCityName = "";
    }
    
    [RelayCommand]
    private void AddParticipant()
    {
        var name = NewParticipant.Trim();
        if(name.Length == 0) return;
        
        Participant user = new Participant();
        user.Name = name;
        //  TODO: Add user.TripId = trip.TripId
        
        Participants.Add(user);
        NewParticipant = "";
    }
}