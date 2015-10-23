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

// The User Control item template is documented at http://go.microsoft.com/fwlink/?LinkId=234236

namespace JobTracker.UniversalApp.Controls
{
    public sealed partial class MasterListControl : UserControl
    {
        public MasterListControl()
        {
            this.InitializeComponent();
        }

        public ISectionPageViewModel ViewModel => DataContext as ISectionPageViewModel;

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
