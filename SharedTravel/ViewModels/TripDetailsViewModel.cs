using CommunityToolkit.Mvvm.ComponentModel;
using CommunityToolkit.Mvvm.Input;
using SharedTravel.Models;
using SharedTravel.Pages;

namespace SharedTravel.ViewModels;

[QueryProperty(nameof(Trip), "Trip")] // Страница-получатель объявляет, что ждёт Trip как параметр, через атрибут [QueryProperty]
public partial class TripDetailsViewModel : ObservableObject
{
    [ObservableProperty] private Trip? _trip;

    [RelayCommand]
    private async Task OpenAddExpense()
    {
        if (Trip is not { } trip)
            return;

        await Shell.Current.GoToAsync(
            nameof(AddExpensePage),
            new ShellNavigationQueryParameters
            {
                ["Trip"] = trip
            }); // На экране Add expense достаточно получить поездку один раз при открытии, поэтому ShellNavigationQueryParameters
    }
}