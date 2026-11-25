using CommunityToolkit.Mvvm.Input;
using System.Collections.ObjectModel;
using Microsoft.EntityFrameworkCore;
using SharedTravel.Data;
using SharedTravel.Models;
using SharedTravel.Pages;

namespace SharedTravel.ViewModels;

public partial class MainViewModel
{
    public ObservableCollection<Trip> Trips { get; set; } = new ObservableCollection<Trip>();

    public async Task LoadTripsFromDbAsync()
    {
        var trips = await Task.Run(() =>
        {
            using var dbContext = new AppDbContext(); // using освобождает контекст после чтения.
            dbContext.Database.EnsureCreated();

            return dbContext.Trips
                .AsNoTracking()
                .Include(trip => trip.Cities)
                .Include(trip => trip.Participants)
                .Include(trip => trip.Expenses)
                .Include(trip => trip.Settlements)
                .ToList();
        });
        
        Trips.Clear();
        
        foreach (var trip in trips)
        {
            Trips.Add(trip);
        }
    }

    [RelayCommand]
    private async Task GoToAddTripPage()
    {
        await Shell.Current.GoToAsync(nameof(AddTripPage));
    }
}
