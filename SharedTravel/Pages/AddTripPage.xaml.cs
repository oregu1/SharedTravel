using SharedTravel.ViewModels;

namespace SharedTravel.Pages;

public partial class AddTripPage : ContentPage
{
    public AddTripPage()
    {
        InitializeComponent();

        BindingContext = new AddTripViewModel();
    }
}