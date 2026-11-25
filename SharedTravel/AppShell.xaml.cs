using SharedTravel.Pages;

namespace SharedTravel
{
    public partial class AppShell : Shell
    {
        public AppShell()
        {
            InitializeComponent();
            
            //  ROUTES
            Routing.RegisterRoute(nameof(AddTripPage), typeof(AddTripPage));
        }
    }
}
