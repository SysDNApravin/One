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
            
            bool containsSearchResult = qrCode.Contains("?secret=");
            bool containsName = qrCode.Contains("Google");
            if(containsSearchResult==true ||containsName==true) {
                string MyString = qrCode;
                var TrmQrCode1 = (MyString.Remove(0, 15));
                var TrmQrCode2 = "(" + TrmQrCode1;
                String phraseQr1 = TrmQrCode2;
                String phraseQr2 = phraseQr1.Replace("%3A", ") ");
                String phraseQr3 = phraseQr2.Replace("%40", "@");
                int TrmQrcode3 = phraseQr3.IndexOf("?secret=");
                string phraseQr4 = phraseQr3.Remove(TrmQrcode3, 61);


                barcodeResult.Text = phraseQr4;

            }
            else
            {
                DisplayAlert("Alert!", "Scaned QR Code is Not Valid", "Ok");
            }


            // Navigation.PushModalAsync(new DetailsPage(barcodeResult));


        });
    }

    private void Button_Clicked_Check(object sender, EventArgs e)
    {
        Navigation.PopAsync();
    }
}