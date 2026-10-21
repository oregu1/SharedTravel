using SharedTravel.ViewModels;

namespace SharedTravel.Pages
{
    public partial class MainPage : ContentPage
    {
        private MainViewModel _viewModel;
        public MainPage()
        {
            InitializeComponent();

            _viewModel = new MainViewModel();
            // Через BindingContext передаем Все элементы внутри страницы MainViewModel и наследуют его автоматически.
            BindingContext = _viewModel;
        }

        protected override void OnAppearing()// Каждрый раз как возвращаемся на главную страницу, делаем запрос к базе для обновления данных
        {
            base.OnAppearing();
            _viewModel.LoadTripsFromDb();
        }
    }
}