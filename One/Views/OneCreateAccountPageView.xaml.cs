using One.ViewModels;

namespace One.Views;

public partial class OneCreateAccountPageView : ContentPage
{
	public OneCreateAccountPageView(OneCreateAccountPageViewModel viewModel)
	{
		InitializeComponent();
		this.BindingContext= viewModel;
	}

  

   
}