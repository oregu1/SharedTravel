using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
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