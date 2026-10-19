using SharedTravel.Pages;

namespace SharedTravel
{
    public partial class AppShell : Shell
    {
        public AppShell()
        {
            InitializeComponent();
            
            //  МАРШРУТЫ
            Routing.RegisterRoute("AddTripPage", typeof(AddTripPage));
        }
    }
}
