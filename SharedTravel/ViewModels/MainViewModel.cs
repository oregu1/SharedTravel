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
        Trips = new ObservableCollection<Trip>(LoadTripsFromDb());
    }

    private List<Trip> LoadTripsFromDb()
    {
        using var db = new AppDbContext();
        db.Database.EnsureCreated(); // 1. создать файл и таблицы, если их нет

        //  TODO: Удалить тестовую запись
        if (!db.Trips.Any()) // 2. проверить, пуста ли таблица
        {
            Trip trip = new Trip
            {
                Name = "Magic China",
                Cities = new List<City>
                {
                    new City
                    {
                        Name = "Beijing",
                    },
                    new City
                    {
                        Name = "Shanghai",
                    },
                    new City
                    {
                        Name = "Jangjiajze",
                    },
                },
                StartDate = new DateTime(2026, 04, 04),
                EndDate = new DateTime(2026, 04, 18),
                Country = CountryCode.CN,
                CurrencyCode = CurrencyCode.CNY
            };
            
            db.Trips.Add(trip); // 3. Добавляем путешествие в базу
            db.SaveChanges(); // 4. Сохраняем изменения в базе. ОБЯЗАТЕЛЬНО!
        }

        return db.Trips.ToList();
    }

    [RelayCommand] // Кнопка в XAML не может вызвать метод напрямую, ей нужна команда (Command), то есть объект, который знает, как выполнить действие.
    private async Task GoToAddTripPage()
    {
        await Shell.Current.GoToAsync("AddTripPage");
    }
}