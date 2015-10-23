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
using Windows.UI.Core;
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

    public class EducationSectionPageBase : SectionPageBase<EducationSection, EducationItem, EducationTranslation>
    {
        public EducationSectionPageBase() : base() { }
    }

    /// <summary>
    /// An empty page that can be used on its own or navigated to within a Frame.
    /// </summary>
    public sealed partial class EducationSectionPage : EducationSectionPageBase
    {
        public EducationSectionPage() : base()
        {
            this.InitializeComponent();
        }
    }
}
