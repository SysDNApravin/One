using Microsoft.Toolkit.Mvvm.ComponentModel;
using Microsoft.Toolkit.Mvvm.Input;
using One.Models;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using One.Services;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Reflection.Metadata.Ecma335;
using System.ComponentModel;
using System.Diagnostics;
using System.Net;

using System.Runtime.CompilerServices;
using One.Views;
using SQLitePCL;


namespace One.ViewModels
{
    public partial class OneHomePageViewModel : ObservableObject, INotifyPropertyChanged
    {
        public ObservableCollection<OneEmailModel> Oneemail { get; set; } = new ObservableCollection<OneEmailModel>();
        [ObservableProperty]
        private OneEmailModel _oneEmailDetail = new OneEmailModel();

        private readonly IOneEmailServices _oneEmailServices;
        public OneHomePageViewModel(IOneEmailServices oneEmailServices)
        {
            _oneEmailServices = oneEmailServices;
        }
        [ObservableProperty]
        private string _title = "Red";
        [ObservableProperty]
        private int _ran;

        [ObservableProperty]
        private double _progressbarval = 0.4;
        /*

        Stopwatch stopwatch = new Stopwatch();


        private string _stopWatchHours;
        public string StopWatchHours
        {
            get { return _stopWatchHours; }
            set
            {
                _stopWatchHours = value;
                OnPropertyChanged("StopWatchHours");
            }
        }

        private string _stopWatchMinutes;
        public string StopWatchMinutes
        {
            get { return _stopWatchMinutes; }
            set
            {
                _stopWatchMinutes = value;
                OnPropertyChanged("StopWatchMinutes");
            }
        }

        private string _stopWatchSeconds;
        public string StopWatchSeconds
        {
            get { return _stopWatchSeconds; }
            set
            {
                _stopWatchSeconds = value;
                OnPropertyChanged("StopWatchSeconds");
            }
        }

        public event PropertyChangedEventHandler PropertyChanged;
        protected virtual void OnPropertyChanged (string propertyName){
            var changed = PropertyChanged;  
            if(changed != null )
            {
                PropertyChanged(this, new PropertyChangedEventArgs(propertyName));
            }
         }

        [Obsolete]
        public OneHomePageViewModel()
        {
            stopwatch.Start();
            StopWatchHours = stopwatch.Elapsed.Hours.ToString();
            StopWatchMinutes = stopwatch.Elapsed.Minutes.ToString();
            StopWatchSeconds= stopwatch.Elapsed.Seconds.ToString();

            Device.StartTimer(TimeSpan.FromSeconds(1), () =>
            {
                  StopWatchHours = stopwatch.Elapsed.Hours.ToString();
            StopWatchMinutes = stopwatch.Elapsed.Minutes.ToString();
            StopWatchSeconds= stopwatch.Elapsed.Seconds.ToString();


                return true;
            });
        }
*/


        // here Geting Data in list

        [ICommand]
        public async void GetOneEmailList()
        {
            Oneemail.Clear();
            var oneEmailList = await _oneEmailServices.GetOneEmailList();
            if (oneEmailList?.Count > 0)
            {
                //Tips 
                //1)creat new random number every 60 sec
                //2)if new rndom number generated execute foreach loop
                //while(true)
                //{
                //    Random rand = new Random();
                //    int Ran = rand.Next(10, 20);
                //}

                foreach (var onemail in oneEmailList)
                {
                
                    Oneemail.Add(new OneEmailModel
                    {

                        Id = onemail.Id,
                        Email = onemail.Email,

                        VarCode =  onemail.VarCode,
                        ProgressBarVal = Progressbarval
                    }) ;
                
                
                
                }

                
             }


        }






        /*
                [ICommand]
                public async void AuthenticationCodeChange()
                   {


                    while (true)
                    {

                        var oneEmailList = await _oneEmailServices.GetOneEmailList();
                        if (oneEmailList?.Count > 0)
                        {

                            GetOneEmailList();
                            var delay = Task.Delay(TimeSpan.FromSeconds(5));

                            var seconds = 0;
                            while (!delay.IsCompleted)
                            {

                                seconds++;
                                Thread.Sleep(TimeSpan.FromSeconds(1));
                                GetOneEmailList();
                                if (seconds == 5)
                                {
                                    GetOneEmailList();

                                }




                            }


                            GetOneEmailList();



                        }

                    }


                }


                */     /*
                    [ICommand]
                    public async void AuthenticationCodeChange()
                    {


                        //OneEmailDetail.VarCode = 123;

                        //var navParam = new Dictionary<string, object>();
                        //navParam.Add("OneEmailDetail", oneEmailModel);

                        //await AppShell.Current.GoToAsync(nameof(AddUpdateLogsView), navParam);
                        //int oneUpdate = await _oneEmailServices.UpdatOneEmail(OneEmailDetail);
                        var oneEmailList = await _oneEmailServices.GetOneEmailList();
                        if (oneEmailList?.Count > 0)
                        {

                            while (true)
                            {



                                Random rand = new Random();
                                int ran = rand.Next(10, 20);
                                Thread.Sleep(20000);
                                OneEmailDetail.Id = 1;
                                OneEmailDetail.VarCode = ran;

                                int oneUpdate = await _oneEmailServices.UpdatOneEmail(OneEmailDetail);
                                if (oneUpdate > 0)
                                {
                                    GetOneEmailList();
                                }

                            }

                        }

                    }
                    */

       


        [ICommand]
        public async void DisplayAction(OneEmailModel oneEmailModel)
        {
            var response = await AppShell.Current.DisplayActionSheet("Select Option", "Cancel", null, "Edit", "Delete","Test");
            if (response == "Edit")
            {
                //var navParam = new Dictionary<string, object>();
               // navParam.Add("OneEmailDetail", oneEmailModel);
                // AppShell.Current.GoToAsync(nameof(OneUpdateEmailPageView), navParam);

                // string result = await AppShell.Current.DisplayPromptAsync("Edit Email", "Update Email");
                int Email_id = oneEmailModel.Id;
                string updateemailresult = await AppShell.Current.DisplayPromptAsync("", "Change Name", initialValue: $"{oneEmailModel.Email}", keyboard: Keyboard.Email);
                if(Email_id > 0 && !string.IsNullOrWhiteSpace(updateemailresult))
                {
                    oneEmailModel.Email = updateemailresult;

                    var updateResponse = await _oneEmailServices.UpdatOneEmail(oneEmailModel);
                    if(updateResponse > 0)
                    {
                        GetOneEmailList();
                    }
                }

            }
            else if (response == "Delete")
            {
                var delResponse = await _oneEmailServices.DeleteOneEmail(oneEmailModel);
                if (delResponse > 0)
                {
                    GetOneEmailList();
                }
            }
            else if(response=="Test") {
                int a = 1;
                if (a == 1)
                {
                    GetOneEmailList();
                }
               
               Thread.Sleep(10000);
                while (true)
                {





                    Random rand = new Random();
                    var ran = rand.Next(100000, 999999);



                    oneEmailModel.VarCode = ran;
                    
                    var updateResponseok = await _oneEmailServices.UpdatOneEmail(oneEmailModel);
                    if (updateResponseok > 0)
                    {
                        GetOneEmailList();
                    }
                    //Thread.Sleep(25000);
                }
              
            }



        }


    }
}
