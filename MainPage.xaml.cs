using MauiAppEjercicio1_3.ViewModels;

namespace MauiAppEjercicio1_3
{
    public partial class MainPage : ContentPage
    {
        int count = 0;

        public MainPage(MainViewModel viewModel)
        {
            InitializeComponent();
            BindingContext = viewModel;
        }

        
    }
}