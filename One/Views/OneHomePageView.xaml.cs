using One.ViewModels;

namespace One.Views;

public partial class OneHomePageView : ContentPage
{
    private readonly OneHomePageViewModel _viewMode;
    public OneHomePageView(OneHomePageViewModel viewModel)
	{
		InitializeComponent();
        _viewMode = viewModel;
        this.BindingContext = viewModel;	
	}
    protected override void OnAppearing()
    {
        
        base.OnAppearing();
        _viewMode.GetOneEmailListCommand.Execute(null);

    }

   
}