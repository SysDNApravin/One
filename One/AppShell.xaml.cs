using One.Views;

namespace One;

public partial class AppShell : Shell
{
	public AppShell()
	{
		InitializeComponent();

		Routing.RegisterRoute(nameof(OneHomePageView), typeof(OneHomePageView));
		Routing.RegisterRoute(nameof(OneCreateAccountPageView),typeof(OneCreateAccountPageView));
		Routing.RegisterRoute(nameof(QrcodeScanPageView), typeof(QrcodeScanPageView));
		Routing.RegisterRoute(nameof(OneAccountDetailsFormPageView), typeof(OneAccountDetailsFormPageView));

		Routing.RegisterRoute(nameof(OneUpdateEmailPageView),typeof(OneUpdateEmailPageView));
	}
}
