using JobTracker.Models;
using JobTracker.Models.CV;
using JobTracker.UniversalApp.Models;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Input;
using Windows.UI.Xaml;
using Windows.UI.Xaml.Navigation;

namespace JobTracker.UniversalApp.ViewModels
{
    public class SectionPageViewModel<TSection, TItem, TTranslation> : JobTracker.UniversalApp.Mvvm.ViewModelBase, ISectionPageViewModel
        where TSection : class, ISection<TItem>, ISection
        where TItem : class, ISectionItem<TTranslation>, new()
        where TTranslation : class, ITranslation, new()
    {
        public SectionPageViewModel() : base()
        {
            if (Windows.ApplicationModel.DesignMode.DesignModeEnabled)
            {
                //this.Section = ExampleData.ExampleUser.Education as TSection;
                SelectedItem = Section.Items[0];
            }
        }

        private TSection _Section;
        public TSection Section { get { return _Section; } set { Set(ref _Section, value); } }

        private TItem _SelectedItem;
        public TItem SelectedItem {
            get { return _SelectedItem; }
            set
            {
                Set(ref _SelectedItem, value);
                RaisePropertyChanged(nameof(IsAnyItemSelected));
                RaisePropertyChanged(nameof(AvaliableNewLanguages));
            }
        }
        
        private Visibility _AddItemPanelVisibility = Visibility.Collapsed;
        public Visibility AddItemPanelVisibility
        {
            get { return _AddItemPanelVisibility; }
            set { Set(ref _AddItemPanelVisibility, value); }
        }

        private Visibility _RemoveItemPanelVisibility = Visibility.Collapsed;
        public Visibility RemoveItemPanelVisibility
        {
            get { return _RemoveItemPanelVisibility; }
            set { Set(ref _RemoveItemPanelVisibility, value); }
        }

        public void AddItem(string itemTitle)
        {
            if (!string.IsNullOrWhiteSpace(itemTitle))
            {
                try {
                    var newItem = new TItem() { Name = itemTitle };
                    Section.Items.Add(newItem);
                    SelectedItem = newItem;
                    AddItemPanelVisibility = Visibility.Collapsed;
                }
                catch (ArgumentException e)
                {
                    //TODO
                    //Signal user that Name is already taken
                }
            }
        }
        public void RemoveItem()
        {
            if(IsAnyItemSelected)
            {
                var item = SelectedItem;
                SelectedItem = null;
                Section.Items.Remove(item.Name);
                this.RemoveItemPanelVisibility = Visibility.Collapsed;
            }
        }

        public bool IsAnyItemSelected
        {
            get { return SelectedItem != null; }
        }

        public void AddTranslation(string languageTag)
        {
            //OPTIMIZE
            object[] args = { languageTag };
            TTranslation translation = (TTranslation)Activator.CreateInstance(typeof(TTranslation), args);
                        
            SelectedItem.Translations.Add(translation);
            RaisePropertyChanged(nameof(AvaliableNewLanguages));
        }
        private TTranslation createTranslation(string languageTag, Func<string, TTranslation> f)
        {
            return f(languageTag);
        }
        public void RemoveTranslation()
        {
            RaisePropertyChanged(nameof(AvaliableNewLanguages));
        }

        public override void OnNavigatedTo(object parameter, NavigationMode mode, IDictionary<string, object> state)
        {
            base.OnNavigatedTo(parameter, mode, state);
            var section = parameter as TSection;
            if (section != null)
                _Section = section;
        }

        public ObservableCollection<string> AvaliableNewLanguages
        {
            get
            {
                if (!IsAnyItemSelected)
                    return null;
                return new ObservableCollection<string>(SupportedLanguages.List.Except(SelectedItem.Translations.Select(item => item.LanguageTag)));
            }
            //set { Set(ref _AvaliableNewLanguages, value); }
        }

    }
}
