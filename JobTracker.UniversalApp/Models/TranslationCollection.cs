using JobTracker.Models.CV;
using System;
using System.Collections.Generic;
using System.Collections.Specialized;
using System.ComponentModel;

namespace JobTracker.Models
{
    public class TranslationCollection<T> : ObservableKeyedCollection<string, T>, ITranslationCollection<T> where T : ITranslation
    {
        public event PropertyChangedEventHandler PropertyChanged;

        protected override string GetKeyForItem(T item)
        {
            return item.LanguageTag;
        }


    }
}
