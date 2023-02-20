using Microsoft.Toolkit.Mvvm.Input;
using One.Models;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace One.ViewModels
{
    public partial class IntroScreenViewModel
    {
        public ObservableCollection<IntroScreenModel> IntroScreens { get; set; } = new ObservableCollection<IntroScreenModel>();


      
            public IntroScreenViewModel() {
            IntroScreens.Add(new IntroScreenModel
            {
                IntroTitle = "Strong Security With One Authenticator",
                IntroDescription = "Get Varification Code For All Your Accounts Using 2-Step Verification",
                IntroImage = "dotnet_bot"
            }) ;


            IntroScreens.Add(new IntroScreenModel
            {
                IntroTitle = "Simple Setup Using Your Camera",
                IntroDescription = "To set up an account, you'll scan the QR code in your 2-step Verification settings for Google or any third-party services",
                IntroImage = "dotnet_bot"
            });


            IntroScreens.Add(new IntroScreenModel
            {
                IntroTitle = "A unique code used to Sign in",
                IntroDescription = "When using 2-step Verification,you'll enter your password and a code from this app",
                IntroImage = "dotnet_bot"
            });


        }
        [ICommand]
        public async void  GetStarted()
        {
            // await AppShell.Current.DisplayAlert("One Authenticator", "Ok This Metod is working", "Ok");

            await AppShell.Current.GoToAsync("OneCreateAccountPageView");
        }



    }
}
