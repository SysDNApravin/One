using One.ViewModels;

namespace One.Views;

public partial class OneUpdateEmailPageView : ContentPage
{
	public OneUpdateEmailPageView(OneUpdateEmailPageViewModel viewModel)
	{
		InitializeComponent();
		this.BindingContext= viewModel;	
	}
}