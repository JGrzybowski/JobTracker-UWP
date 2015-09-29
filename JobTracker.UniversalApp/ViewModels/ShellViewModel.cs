using JobTracker.Models;
using JobTracker.UniversalApp.Mvvm;
using JobTracker.UniversalApp.ViewModels;
using JobTracker.UniversalApp.Views;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Template10.Controls;

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

        //public List<HamburgerButtonInfo> ButtonInfos
        //{
        //    get
        //    {
        //        var list = new List<HamburgerButtonInfo>();
        //        foreach (var section in UserData.Sections)
        //        {
        //            Type t = typeof(SectionPageViewModel<,,>);
        //            Type[] type = { section.GetType() };
        //            var vmType = t.MakeGenericType(type);

        //            list.Add(new HamburgerButtonInfo{
        //                ClearHistory = true,
        //                PageParameter = section,
        //                PageType = typeof(SectionPage)
        //            });
        //        }
        //        return list;
        //    }
        //}
    }
}
