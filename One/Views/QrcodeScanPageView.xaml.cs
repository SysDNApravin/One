using Android.Graphics;
using One.ViewModels;
using ZXing.Net.Maui;

namespace One.Views;

public partial class QrcodeScanPageView : ContentPage
{
	public QrcodeScanPageView(QrcodeScanPageViewModel viewModel)
	{
		InitializeComponent();
		this.BindingContext= viewModel;	
        barcodeReader.Options = new ZXing.Net.Maui.BarcodeReaderOptions();
        {
           var Formats = BarcodeFormats.All;
        }
	}
    private  void  CameraBarcodeReaderView_BarcodesDetected(object sender, ZXing.Net.Maui.BarcodeDetectionEventArgs e)
    {
        Dispatcher.Dispatch(() =>
        {
             var qrCode = $"{e.Results[0].Value} {e.Results[0].Format}";
              
          
                barcodeResult.Text = qrCode;

            // Navigation.PushModalAsync(new DetailsPage(barcodeResult));


        });
    }

    private void Button_Clicked_Check(object sender, EventArgs e)
    {
        Navigation.PopAsync();
    }
}