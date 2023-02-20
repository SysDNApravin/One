using Microsoft.Toolkit.Mvvm.Input;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace One.ViewModels
{
    public partial class OneCreateAccountPageViewModel
    {
        [ICommand]
        public async void OneHomePageNav()
        {
            await AppShell.Current.GoToAsync("OneHomePageView");
        }

        [ICommand]
        public async void OneCreateAccount()
        {
            await AppShell.Current.GoToAsync("OneAccountDetailsFormPageView");
        }
       
        [ICommand]
        public async void QrCodeScanig()
        {
            await AppShell.Current.GoToAsync("QrcodeScanPageView");
        }

        [ICommand]
        public async void VdotClick()
        {
          var action = await AppShell.Current.DisplayActionSheet("", "", "", "How it works", "Settings", "Help and feedback");
             

        }
    }
}
