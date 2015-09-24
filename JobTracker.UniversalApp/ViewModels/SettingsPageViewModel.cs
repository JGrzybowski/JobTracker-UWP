using JobTracker.Models;
using JobTracker.UniversalApp.Views;
using Newtonsoft.Json;
using System;
using System.IO;
using System.Xml.Serialization;
using Windows.Storage;
using Windows.Storage.Pickers;
using Windows.UI.Xaml;

namespace JobTracker.UniversalApp.ViewModels
{
    public class SettingsPageViewModel : JobTracker.UniversalApp.Mvvm.ViewModelBase
    {
        Services.SettingsServices.SettingsService _settings;

        public SettingsPageViewModel()
        {
            if (Windows.ApplicationModel.DesignMode.DesignModeEnabled)
            {
                // designtime data
                return;
            }
            _settings = Services.SettingsServices.SettingsService.Instance;
        }

        #region Settings

        public bool UseShellBackButton
        {
            get { return _settings.UseShellBackButton; }
            set { _settings.UseShellBackButton = value; base.RaisePropertyChanged(); }
        }

        private string _BusyText = "Please wait...";
        public string BusyText { get { return _BusyText; } set { Set(ref _BusyText, value); } }
        public void ShowBusy() { Views.Shell.SetBusyIndicator(true, _BusyText); }
        public void HideBusy() { Views.Shell.SetBusyIndicator(false); }

        #endregion

        #region About

        public Uri Logo { get { return Windows.ApplicationModel.Package.Current.Logo; } }
        public string DisplayName { get { return Windows.ApplicationModel.Package.Current.DisplayName; } }
        public string Publisher { get { return Windows.ApplicationModel.Package.Current.PublisherDisplayName; } }
        public string Version
        {
            get
            {
                var ver = Windows.ApplicationModel.Package.Current.Id.Version;
                return ver.Major.ToString() + "." + ver.Minor.ToString() + "." + ver.Build.ToString() + "." + ver.Revision.ToString();
            }
        }
        public Uri RateMe { get { return new Uri(""); } }

        #endregion  

        private ShellViewModel GetShellVM() { return (Window.Current.Content as Shell).DataContext as ShellViewModel; }

        public async void ExportData(StorageFile file)
        {
            var vm = GetShellVM();
            if (file.FileType == ".xml")
            {
                XmlSerializer xmlSerializer = new XmlSerializer(typeof(User));
                using (var stream = await file.OpenStreamForWriteAsync())
                {
                    xmlSerializer.Serialize(stream, vm.UserData);
                }
            }
            else if (file.FileType == ".json")
            {
                var json = JsonConvert.SerializeObject(vm.UserData);
                await FileIO.WriteTextAsync(file, json);
            }
        }

        public async void ImportData(StorageFile file)
        {
            if (file.FileType == ".xml")
            {
                XmlSerializer xmlSerializer = new XmlSerializer(typeof(User));
                using (var stream = await file.OpenStreamForReadAsync())
                {
                    User user = xmlSerializer.Deserialize(stream) as User;
                    GetShellVM().UserData = user;
                }
            }
            else if (file.FileType == ".json")
            {
                var fileText = await FileIO.ReadTextAsync(file);
                var user = JsonConvert.DeserializeObject<User>(fileText);
                GetShellVM().UserData = user;
            }
        }
    }
}
