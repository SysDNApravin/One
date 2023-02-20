using Microsoft.Toolkit.Mvvm.ComponentModel;
using Microsoft.Toolkit.Mvvm.Input;
using One.Models;
using One.Services;
using One.Views;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace One.ViewModels
{
    [QueryProperty(nameof(OneEmailDetail), "OneEmailDetail")]
    public partial class QrcodeScanPageViewModel : ObservableObject
    {

        [ObservableProperty]
        private OneEmailModel _oneEmailDetail = new OneEmailModel();

        private readonly IOneEmailServices _oneEmailServices;
        public QrcodeScanPageViewModel(IOneEmailServices oneEmailServices)
        {
            _oneEmailServices = oneEmailServices;
        }



        [ICommand]
        public async void AddAccountOne()
        {

            //Generate Random number of Six Digits
            Random rnd = new Random();
            int onevarcode = rnd.Next(111111, 999999);
            int response = -1;


            /*
              int n = 0;
        for (int i = 1; i >= n ; i++)
        {
            var delay = Task.Delay(TimeSpan.FromSeconds(60));

            var seconds = 0;
            while (!delay.IsCompleted)
            {
                // While we're waiting, note the time ticking past
                seconds++;
                Thread.Sleep(TimeSpan.FromSeconds(1));
                
                if (seconds == 60)
                {
                   _oneEmailServices.UpdatOneEmail(OneEmailDetail);
                 //console.Writeline("Hi Praveen");
                }
            }
             */

            if (OneEmailDetail.Id > 0)
            {

                await _oneEmailServices.UpdatOneEmail(OneEmailDetail);


            }
            //Check Proper Qr Code is Or not
            else if (string.IsNullOrWhiteSpace(OneEmailDetail.Email))
            {
                await Shell.Current.DisplayAlert("Alert !", "Please Scan Proper QRCode", "Ok");
            }

            else
            {


                response = await _oneEmailServices.AddOneEmail(new Models.OneEmailModel
                {



                    Email = OneEmailDetail.Email,
                    Application_Name = "Gmail",
                    VarCode = onevarcode

                }); ;




                if (response > 0)
                {

                    // await Shell.Current.GoToAsync("OneHomePageView");
                    // await Navigation.PopModalAsync();
                    OneEmailDetail.Email = ""; // it clear entry

                    await Shell.Current.GoToAsync("OneHomePageView");

                }
                else
                {
                    await Shell.Current.DisplayAlert("One!", "Something went wrong!", "OK");
                }
            }

        }

    }
}
