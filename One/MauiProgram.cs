using Microsoft.Extensions.Logging;
using One.Services;
using One.ViewModels;
using One.Views;
using ZXing.Net.Maui;
using ZXing.Net.Maui.Controls;

namespace One;

public static class MauiProgram
{
	public static MauiApp CreateMauiApp()
	{
		var builder = MauiApp.CreateBuilder();
		builder
			.UseMauiApp<App>()
            .UseBarcodeReader()
            .ConfigureFonts(fonts =>
			{
				fonts.AddFont("OpenSans-Regular.ttf", "OpenSansRegular");
				fonts.AddFont("OpenSans-Semibold.ttf", "OpenSansSemibold");
			})

		#region
			.ConfigureMauiHandlers(h =>
             {
                 h.AddHandler(typeof(ZXing.Net.Maui.Controls.CameraBarcodeReaderView), typeof(CameraBarcodeReaderViewHandler));
                 h.AddHandler(typeof(ZXing.Net.Maui.Controls.CameraView), typeof(CameraViewHandler));
                 h.AddHandler(typeof(ZXing.Net.Maui.Controls.BarcodeGeneratorView), typeof(BarcodeGeneratorViewHandler));
             });
        #endregion

#if DEBUG
        builder.Logging.AddDebug();


		//Services
		builder.Services.AddSingleton<IOneEmailServices, OneEmailServices>();

		//Views 
	
		builder.Services.AddSingleton<IntroScreenView>();
		builder.Services.AddSingleton<OneHomePageView>();
		builder.Services.AddSingleton<OneCreateAccountPageView>();
		builder.Services.AddTransient<QrcodeScanPageView>();
		builder.Services.AddSingleton<OneAccountDetailsFormPageView>();
		builder.Services.AddSingleton<OneUpdateEmailPageView>();

        //ViewModels
        builder.Services.AddSingleton<IntroScreenViewModel>();
		builder.Services.AddSingleton<OneHomePageViewModel>();
		builder.Services.AddSingleton<OneCreateAccountPageViewModel>();
		builder.Services.AddTransient<QrcodeScanPageViewModel>();
		builder.Services.AddSingleton<OneAccountDetailsFormPageViewModel>();
		builder.Services.AddSingleton<OneUpdateEmailPageViewModel>();
       


#endif

        return builder.Build();
	}
}
