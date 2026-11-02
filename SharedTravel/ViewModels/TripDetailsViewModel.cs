using CommunityToolkit.Mvvm.ComponentModel;
using SharedTravel.Models;

namespace SharedTravel.ViewModels;

[QueryProperty(nameof(Trip), "Trip")] // Страница-получатель объявляет, что ждёт Trip как параметр, через атрибут [QueryProperty]
public partial class TripDetailsViewModel : ObservableObject
{
    [ObservableProperty] private Trip? _trip;
}