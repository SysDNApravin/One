using One.ViewModels;

namespace One.Views;

public partial class IntroScreenView : ContentPage
{
	public IntroScreenView()
	{
		InitializeComponent();
		this.BindingContext = new IntroScreenViewModel();

    }
}