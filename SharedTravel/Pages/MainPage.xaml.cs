using SharedTravel.ViewModels;

namespace SharedTravel.Pages
{
    public partial class MainPage : ContentPage
    {
        public MainPage()
        {
            InitializeComponent();

            // Через BindingContext передаем Все элементы внутри страницы MainViewModel и наследуют его автоматически.
            BindingContext = new MainViewModel();
        }
    }
}