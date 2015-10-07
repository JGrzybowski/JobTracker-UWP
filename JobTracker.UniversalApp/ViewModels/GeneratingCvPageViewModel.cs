using System;
using System.Collections.Generic;
using JobTracker.UniversalApp.Mvvm;
using Windows.UI.Xaml.Navigation;
using JobTracker.Models;
using JobTracker.UniversalApp.Models;
using System.Threading.Tasks;
using Windows.Storage;
using JobTracker.UniversalApp.Services.CvGeneratingServices;
using Windows.Storage.Pickers;

namespace JobTracker.UniversalApp.ViewModels
{
    public class GeneratingCvPageViewModel : ViewModelBase
    {
        public User UserData { get { return userData; } set { Set(ref userData, value); } }
        private User userData = new User();

        public string SelectedLanguage { get { return selectedLanguage; } set { Set(ref selectedLanguage, value); } }
        private string selectedLanguage;
        public List<string> LanguagesList { get { return languagesList; } set { Set(ref languagesList, value); } }
        private List<string> languagesList = SupportedLanguages.List;
        
        public async Task GenerateDocx()
        {
            var fileSaver = new FileSavePicker();
            fileSaver.FileTypeChoices.Add("DocX file", new List<string> { ".docx" });
            fileSaver.DefaultFileExtension = ".docx";
            StorageFile file = await fileSaver.PickSaveFileAsync();
            if(file != null)
                await new BasicCvTemplate().GenerateCV(file, UserData, SelectedLanguage);
        }

        public override void OnNavigatedTo(object parameter, NavigationMode mode, IDictionary<string, object> state)
        {
            base.OnNavigatedTo(parameter, mode, state);
            if (parameter is User)
                UserData = parameter as User;
        }
    }
}