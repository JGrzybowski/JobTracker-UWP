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
    /// <summary>
    /// An empty page that can be used on its own or navigated to within a Frame.
    /// </summary>
    public sealed partial class EducationSectionPage : Page
    {
        public EducationSectionPage()
        {
            this.DataContext = new SectionPageViewModel<EducationSection, EducationItem, EducationTranslation>();
            this.InitializeComponent();
            NavigationCacheMode = NavigationCacheMode.Disabled;
        }
        
        // strongly-typed view models enable x:bind
        public SectionPageViewModel<EducationSection, EducationItem, EducationTranslation> ViewModel => DataContext as SectionPageViewModel<EducationSection, EducationItem, EducationTranslation>;

        private void AddItemButton_Click(object sender, RoutedEventArgs e)
        {
            ViewModel.AddItemPanelVisibility = Visibility.Visible;
        }

        private void RemoveItemButton_Click(object sender, RoutedEventArgs e)
        {
            ViewModel.RemoveItemPanelVisibility = Visibility.Visible;
        }

        private void ConfirmAddItemButtom_Click(object sender, RoutedEventArgs e)
        {
            ViewModel.AddItem();
        }

        private void CancelRemoveItemButtom_Click(object sender, RoutedEventArgs e)
        {
            ViewModel.RemoveItemPanelVisibility = Visibility.Collapsed;
        }
        private void ConfirmRemoveItemButtom_Click(object sender, RoutedEventArgs e)
        {
            ViewModel.RemoveItem();
        }
        private void AddNewTranslation_Click(object sender, RoutedEventArgs e)
        {
            MenuFlyoutItem langButton = sender as MenuFlyoutItem;
            if (langButton != null)
            {
                ViewModel.AddTranslation(langButton.Tag.ToString());
            }
        }

        private void OnKeyDownHandler(object sender, KeyRoutedEventArgs e)
        {
            TextBox textBox = sender as TextBox;
            if (e.Key == VirtualKey.Enter)
            {
                ViewModel.AddItem(textBox.Text);
                e.Handled = true;
            }
        }
    }
}
