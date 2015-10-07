using JobTracker.Models.CV;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Windows.UI.Xaml;

namespace JobTracker.UniversalApp.ViewModels
{
    public interface ISectionPageViewModel
    {
        void AddItem();
        void AddItem(string itemName);
        Visibility AddItemPanelVisibility { get; set; }

        void RemoveItem();
        Visibility RemoveItemPanelVisibility { get; set; }

        void AddTranslation(string languageTag);
        
        bool IsAnyItemSelected { get; }
    }
}
