using Microsoft.Toolkit.Mvvm.ComponentModel;
using One.Models;
using One.Services;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace One.ViewModels
{
    [QueryProperty(nameof(OneEmailDetail), "OneEmailDetail")]
    public partial class OneUpdateEmailPageViewModel:ObservableObject
    {
        public ObservableCollection<OneEmailModel> Oneemail { get; set; } = new ObservableCollection<OneEmailModel>();
        [ObservableProperty]
        private OneEmailModel _oneEmailDetail = new OneEmailModel();

        private readonly IOneEmailServices _oneEmailServices;
        public OneUpdateEmailPageViewModel(IOneEmailServices oneEmailServices)
        {
            _oneEmailServices = oneEmailServices;
        }





    }
}
