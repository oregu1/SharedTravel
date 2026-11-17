using CommunityToolkit.Mvvm.ComponentModel;
using SharedTravel.Models;

namespace SharedTravel.ViewModels;

[QueryProperty(nameof(Trip), "Trip")]
public partial class AddExpenseViewModel : ObservableObject
{
    [ObservableProperty] private Trip? _trip;
}