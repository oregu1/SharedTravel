using CommunityToolkit.Mvvm.ComponentModel;
using CommunityToolkit.Mvvm.Input;
using SharedTravel.Models;
using System.Collections.ObjectModel;
using SharedTravel.Data;

namespace SharedTravel.ViewModels;

public partial class MainViewModel : ObservableObject
{
    public ObservableCollection<Trip> Trips { get; set; }

    //  CONSTRUCTOR
    public MainViewModel()
    {
        Trips = new ObservableCollection<Trip>();
    }

    public void LoadTripsFromDb()
    {
        using var db = new AppDbContext();
        db.Database.EnsureCreated(); // 1. создать файл и таблицы, если их нет
        
        Trips.Clear();
        foreach (var trip in db.Trips.ToList())
            Trips.Add(trip);
    }

    [RelayCommand] // Кнопка в XAML не может вызвать метод напрямую, ей нужна команда (Command), то есть объект, который знает, как выполнить действие.
    private async Task GoToAddTripPage()
    {
        await Shell.Current.GoToAsync("AddTripPage");
    }
}