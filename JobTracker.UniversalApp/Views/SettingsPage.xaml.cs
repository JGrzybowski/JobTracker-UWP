using JobTracker.UniversalApp.ViewModels;
using System;
using System.Collections.Generic;
using Windows.Storage;
using Windows.Storage.Pickers;
using Windows.UI.Xaml.Controls;

namespace JobTracker.UniversalApp.Views
{
    public sealed partial class SettingsPage : Page
    {
        public SettingsPage()
        {
            this.InitializeComponent();
            NavigationCacheMode = Windows.UI.Xaml.Navigation.NavigationCacheMode.Disabled;
        }

        // strongly-typed view models enable x:bind
        public SettingsPageViewModel ViewModel => this.DataContext as SettingsPageViewModel;

        private async void ImportDataButton_Click(object sender, Windows.UI.Xaml.RoutedEventArgs e)
        {
            var fileOpener = new FileOpenPicker();
            fileOpener.FileTypeFilter.Add(".xml");
            fileOpener.FileTypeFilter.Add(".json");

            StorageFile file = await fileOpener.PickSingleFileAsync();
            ViewModel.ImportData(file);
        }

        private async void ExportDataButton_Click(object sender, Windows.UI.Xaml.RoutedEventArgs e)
        {
            var fileSaver = new FileSavePicker();
            fileSaver.FileTypeChoices.Add("XML file", new List<string> { ".xml" });
            fileSaver.FileTypeChoices.Add("JSON file", new List<string> { ".json" });
            fileSaver.FileTypeChoices.Add("DocX file", new List<string> { ".docx" });
            fileSaver.DefaultFileExtension = ".xml";

            StorageFile file = await fileSaver.PickSaveFileAsync();
            ViewModel.ExportData(file);
        }
    }
}
