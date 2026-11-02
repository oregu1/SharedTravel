using SharedTravel.Pages;

namespace SharedTravel
{
    public partial class AppShell : Shell
    {
        public AppShell()
        {
            InitializeComponent();
            
            //  ROUTES
            Routing.RegisterRoute("AddTripPage", typeof(AddTripPage));
            Routing.RegisterRoute("TripDetailsPage", typeof(TripDetailsPage));
        }
    }
}
