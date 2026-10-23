using CommunityToolkit.Mvvm.ComponentModel;
using CommunityToolkit.Mvvm.Input;
using SharedTravel.Data;
using SharedTravel.Models;
using SharedTravel.Models.Helpers;

namespace SharedTravel.ViewModels;

public partial class AddTripViewModel : ObservableObject
{
    //  Список стран: создаём список объектов CountryOption, где Name - это описание страны, а Value - это enum CountryCode
    public List<CountryOption> Countries { get; } =
        Enum.GetValues<CountryCode>()
            .Select(c => new CountryOption { Value = c, Name = c.GetDescription() })
            .OrderBy(o => o.Name)
            .ToList();
    
    //  Список валют: сами значения enum, Picker покажет их как CNY, USD, EUR...
    public List<CurrencyCode> Currencies { get; } = Enum.GetValues<CurrencyCode>().ToList();
    
    //  FORM FIELDS
    [ObservableProperty] private string _tripTitle = "";
    [ObservableProperty] private DateTime _tripStartDate = DateTime.Today;
    [ObservableProperty] private DateTime _tripEndDate = DateTime.Today;
    [ObservableProperty] private decimal _tripPlannedBudget;
    [ObservableProperty] private CountryOption? _selectedCountry;
    [ObservableProperty] private CurrencyCode _selectedCurrency = CurrencyCode.USD; // Выбранная валюта, по умолчанию USD

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
            CurrencyCode = SelectedCurrency
        };

        db.Trips.Add(trip);
        await db.SaveChangesAsync();

        await Shell.Current.GoToAsync(".."); // Go back to the main screen
    }
}