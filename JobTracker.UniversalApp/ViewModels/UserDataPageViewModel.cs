using JobTracker.Models;
using JobTracker.UniversalApp.Mvvm;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Windows.UI.Xaml.Navigation;

namespace JobTracker.UniversalApp.ViewModels
{
    public class UserDataPageViewModel : ViewModelBase
    {
        public User User { get { return user; } set { Set(ref user, value); } }
        private User user = new User();

        public override void OnNavigatedTo(object parameter, NavigationMode mode, IDictionary<string, object> state)
        {
            base.OnNavigatedTo(parameter, mode, state);
            if (parameter is User)
                User = parameter as User;

        }


    }
}
