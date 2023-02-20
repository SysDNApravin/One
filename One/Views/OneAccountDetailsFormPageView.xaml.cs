using One.ViewModels;
using static System.Net.Mime.MediaTypeNames;

namespace One.Views;

public partial class OneAccountDetailsFormPageView : ContentPage
{
	public OneAccountDetailsFormPageView(OneAccountDetailsFormPageViewModel viewModel)
	{
		InitializeComponent();
		this.BindingContext = viewModel;
	}

}