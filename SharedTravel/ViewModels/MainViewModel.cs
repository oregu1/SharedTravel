using CommunityToolkit.Mvvm.ComponentModel;
using CommunityToolkit.Mvvm.Input;
using SharedTravel.Models;
using System.Collections.ObjectModel;
using SharedTravel.Data;

namespace SharedTravel.ViewModels;

public partial class MainViewModel : ObservableObject
{
    // Из этого поля генератор создаёт публичное свойство Trips (с большой буквы, без подчёркивания).
    // Именно свойство Trips используется в XAML и в коде ниже.
    [ObservableProperty]
    private ObservableCollection<Trip> _trips = new();

    public void LoadTripsFromDb()
    {
        using var db = new AppDbContext();
        db.Database.EnsureCreated(); // создать файл и таблицы, если их нет

        // Присваиваем СВОЙСТВУ Trips (не полю _trips): тогда экран узнает о замене коллекции.
        Trips = new ObservableCollection<Trip>(db.Trips.ToList());
    }

    [RelayCommand] // Кнопка в XAML не может вызвать метод напрямую, ей нужна команда (Command), то есть объект, который знает, как выполнить действие.
    private async Task GoToAddTripPage()
    {
        await Shell.Current.GoToAsync("AddTripPage");
    }
}