using JobTracker.Models;
using JobTracker.Models.CV;
using JobTracker.UniversalApp.Models;
using JobTracker.UniversalApp.Mvvm;
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
    public class SectionPageViewModel<TSection, TItem, TTranslation> : ViewModelBase, ISectionPageViewModel
        where TSection : class, ISection<TItem>, ISection, new()
        where TItem : class, ISectionItem<TTranslation>, new()
        where TTranslation : class, ITranslation, new()
    {
        public SectionPageViewModel() : base()
        {
            if (Windows.ApplicationModel.DesignMode.DesignModeEnabled)
            {
                //FIX use factory to generate example data
                Section = new TSection();
                Section.Items.Add(new TItem());
                Section.Items.Add(new TItem());
                Section.Items[0].Name = "Item Name";
                Section.Items[1].Name = "Item Name2";
                SelectedItem = Section.Items.FirstOrDefault();
                SelectedItem.Translations.Add(new TTranslation());
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
        public bool IsAnyItemSelected
        {
            get { return SelectedItem != null; }
        }
        
        #region Items Buttons Panel
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
        
        private string newItemsName = "";
        public string NewItemsName { get { return newItemsName; } set { Set(ref newItemsName, value); } }
        private Visibility addItemErrorMessageVisibility = Visibility.Collapsed;
        public Visibility AddItemErrorMessageVisibility { get { return addItemErrorMessageVisibility; } set { Set(ref addItemErrorMessageVisibility, value); } }

        public void AddItem()
        {
            this.AddItem(newItemsName);
        }
        public void AddItem(string itemName)
        {
            if (!string.IsNullOrWhiteSpace(itemName))
            {
                try
                {
                    var newItem = new TItem() { Name = itemName };
                    AddItemPanelVisibility = Visibility.Collapsed;
                    Section.Items.Add(newItem);
                    SelectedItem = newItem;
                    NewItemsName = "";
                }
                catch (ArgumentException e)
                {
                    this.AddItemErrorMessageVisibility = Visibility.Visible;
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
        #endregion
        #region Translations Buttons Panel
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
        #endregion

        public override void OnNavigatedTo(object parameter, NavigationMode mode, IDictionary<string, object> state)
        {
            base.OnNavigatedTo(parameter, mode, state);
            var section = parameter as TSection;
            if (section != null)
                _Section = section;
        }

    }
}
