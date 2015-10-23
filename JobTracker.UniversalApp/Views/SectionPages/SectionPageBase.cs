using JobTracker.Models.CV;
using JobTracker.UniversalApp.ViewModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Windows.System;
using Windows.UI.Xaml;
using Windows.UI.Xaml.Controls;
using Windows.UI.Xaml.Input;
using Windows.UI.Xaml.Navigation;

namespace JobTracker.UniversalApp.Views.SectionPages
{
    public class SectionPageBase<TSection, TItem, TTranslation> : Page
        where TSection : class, ISection<TItem>, ISection, new()
        where TItem : class, ISectionItem<TTranslation>, new()
        where TTranslation : class, ITranslation, new()
    {
        public SectionPageViewModel<TSection, TItem, TTranslation> ViewModel => DataContext as SectionPageViewModel<TSection, TItem, TTranslation>;

        public SectionPageBase() : base()
        {
            this.DataContext = new SectionPageViewModel<TSection, TItem, TTranslation>();
            NavigationCacheMode = NavigationCacheMode.Disabled;
        }

        protected void AddItemButton_Click(object sender, RoutedEventArgs e)
        {
            ViewModel.AddItemPanelVisibility = Visibility.Visible;
        }

        protected void RemoveItemButton_Click(object sender, RoutedEventArgs e)
        {
            ViewModel.RemoveItemPanelVisibility = Visibility.Visible;
        }

        protected void ConfirmAddItemButtom_Click(object sender, RoutedEventArgs e)
        {
            ViewModel.AddItem();
        }

        protected void CancelRemoveItemButtom_Click(object sender, RoutedEventArgs e)
        {
            ViewModel.RemoveItemPanelVisibility = Visibility.Collapsed;
        }

        protected void ConfirmRemoveItemButtom_Click(object sender, RoutedEventArgs e)
        {
            ViewModel.RemoveItem();
        }

        protected void AddNewTranslation_Click(object sender, RoutedEventArgs e)
        {
            MenuFlyoutItem langButton = sender as MenuFlyoutItem;
            if (langButton != null)
            {
                ViewModel.AddTranslation(langButton.Tag.ToString());
            }
        }

        protected void OnKeyDownHandler(object sender, KeyRoutedEventArgs e)
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
