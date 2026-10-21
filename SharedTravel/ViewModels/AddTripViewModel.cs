using CommunityToolkit.Mvvm.ComponentModel;
using CommunityToolkit.Mvvm.Input;
using SharedTravel.Data;
using SharedTravel.Models;

namespace SharedTravel.ViewModels;

public partial class AddTripViewModel : ObservableObject
{
    //  FORM FIELDS
    [ObservableProperty] private string _tripTitle = "";
    [ObservableProperty] private DateTime _tripStartDate = DateTime.Today;
    [ObservableProperty] private DateTime _tripEndDate = DateTime.Today;
    [ObservableProperty] private decimal _tripPlannedBudget;
    
    [RelayCommand]
    private async Task SaveNewTripToDb()
    {
        using var db = new AppDbContext();
        
        Trip trip = new Trip
        {
            Name = _tripTitle,
            StartDate = _tripStartDate,
            EndDate = _tripEndDate,
            PlannedBudget = _tripPlannedBudget
        };

        db.Trips.Add(trip);
        await db.SaveChangesAsync();

        await Shell.Current.GoToAsync(".."); // Go back to the main screen
    }
}