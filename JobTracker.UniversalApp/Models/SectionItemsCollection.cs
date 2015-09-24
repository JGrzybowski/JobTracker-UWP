using JobTracker.Models.CV;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace JobTracker.Models
{
    public class SectionItemsCollection<T> : ObservableKeyedCollection<string, T>, INotifyPropertyChanged where T : ISectionItem
    {
        public event PropertyChangedEventHandler PropertyChanged;

        protected override string GetKeyForItem(T item)
        {
            return item.Name;
        }
    }
}
