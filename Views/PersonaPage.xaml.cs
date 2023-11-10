using MauiAppEjercicio1_3.ViewModels;

namespace MauiAppEjercicio1_3.Views;

public partial class PersonaPage : ContentPage
{
	public PersonaPage(PersonaViewModel viewModel)
	{
		InitializeComponent();
		BindingContext = viewModel;
	}
}