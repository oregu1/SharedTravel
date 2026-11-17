using SharedTravel.ViewModels;

namespace SharedTravel.Pages;

public partial class TripDetailsPage : ContentPage
{
    public TripDetailsPage()
    {
        InitializeComponent();

        BindingContext = new TripDetailsViewModel();
    }
}