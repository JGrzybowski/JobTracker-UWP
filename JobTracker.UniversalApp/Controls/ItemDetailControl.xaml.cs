using JobTracker.UniversalApp.ViewModels;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Runtime.InteropServices.WindowsRuntime;
using Windows.Foundation;
using Windows.Foundation.Collections;
using Windows.UI.Xaml;
using Windows.UI.Xaml.Controls;
using Windows.UI.Xaml.Controls.Primitives;
using Windows.UI.Xaml.Data;
using Windows.UI.Xaml.Input;
using Windows.UI.Xaml.Media;
using Windows.UI.Xaml.Navigation;

// The User Control item template is documented at http://go.microsoft.com/fwlink/?LinkId=234236

namespace JobTracker.UniversalApp.Controls
{
    public sealed partial class ItemDetailControl : UserControl
    {
        public ItemDetailControl()
        {
            this.InitializeComponent();
        }

        public ISectionPageViewModel ViewModel => DataContext as ISectionPageViewModel;
        
        private void AddNewTranslation_Click(object sender, RoutedEventArgs e)
        {
            MenuFlyoutItem langButton = sender as MenuFlyoutItem;
            if (langButton != null)
            {
                ViewModel.AddTranslation(langButton.Tag.ToString());
            }
        }
    }
}
