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
        private string _title = "One  Authenticator";
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

                /* while (true)
                 {
                     Random rand = new Random();
                     int ran = rand.Next(10, 20);
                     Thread.Sleep(6000);
                     Console.WriteLine(ran);
                 }
                */

                foreach (var onemail in oneEmailList)
                {
                    Random rand = new Random();
                    int ran = rand.Next(10, 20);
                    // string Time = DateTime.Now.ToLongTimeString();
                    Oneemail.Add(new OneEmailModel
                    {

                        Id = onemail.Id,
                        Email = onemail.Email,

                       // VarCode = ran + onemail.Id,
                       VarCode= onemail.VarCode,
                        Application_Name = onemail.Application_Name
                    });



                }



            }





        }



    }
}
