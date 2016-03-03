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
using Windows.UI.Xaml.Media;
using Syncfusion.DocIO.DLS;

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
        public ImageSource CVlookup { get { return cvLookup; } set { Set(ref cvLookup, value); } }
        private ImageSource cvLookup;
        public WordDocument Doc { get { return doc; } set { Set(ref doc, value); } }
        private WordDocument doc;

        public async Task GenerateDocx()
        {
            var fileSaver = new FileSavePicker();
            fileSaver.FileTypeChoices.Add("DocX file", new List<string> { ".docx" });
            fileSaver.DefaultFileExtension = ".docx";
            StorageFile file = await fileSaver.PickSaveFileAsync();
            if(file != null)
                await new BasicCvTemplate().GenerateCV(file, UserData, SelectedLanguage);
        }

        public override Task OnNavigatedToAsync(object parameter, NavigationMode mode, IDictionary<string, object> state)
        {
            if (parameter is User)
                UserData = parameter as User;
            return base.OnNavigatedToAsync(parameter, mode, state);    
        }
    }
}