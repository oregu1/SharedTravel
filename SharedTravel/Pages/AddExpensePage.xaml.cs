using SharedTravel.ViewModels;

namespace SharedTravel.Pages;

public partial class AddExpensePage : ContentPage
{
    public AddExpensePage()
    {
        InitializeComponent();
        
        BindingContext = new AddExpenseViewModel();
    }
}