using JobTracker.Models.CV;
using JobTracker.UniversalApp.ViewModels;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Runtime.InteropServices.WindowsRuntime;
using Windows.Foundation;
using Windows.Foundation.Collections;
using Windows.System;
using Windows.UI.Xaml;
using Windows.UI.Xaml.Controls;
using Windows.UI.Xaml.Controls.Primitives;
using Windows.UI.Xaml.Data;
using Windows.UI.Xaml.Input;
using Windows.UI.Xaml.Media;
using Windows.UI.Xaml.Navigation;

// The Blank Page item template is documented at http://go.microsoft.com/fwlink/?LinkId=234238

namespace JobTracker.UniversalApp.Views.SectionPages
{
    public class ProjectSectionPageBase : SectionPageBase<ProjectSection, ProjectItem, ProjectTranslation>
    {
        public ProjectSectionPageBase() : base() { }
    }
   
    public sealed partial class ProjectSectionPage : ProjectSectionPageBase
    {
        public ProjectSectionPage() : base()
        {
            this.InitializeComponent();
        }
    }
}
