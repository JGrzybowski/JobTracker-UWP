using JobTracker.Models;
using JobTracker.UniversalApp.Mvvm;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace JobTracker.UniversalApp.ViewModels
{
    public class ShellViewModel : ViewModelBase
    {
        public ShellViewModel() : base()
        {
            this.UserData = ExampleData.ExampleUser;
        }

        private User _UserData;
        public User UserData
        {
            get { return _UserData; }
            set { Set(ref _UserData, value); }
        }
    }
}
