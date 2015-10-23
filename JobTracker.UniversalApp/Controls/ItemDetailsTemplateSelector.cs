using JobTracker.Models.CV;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Windows.UI.Xaml;
using Windows.UI.Xaml.Controls;

namespace JobTracker.UniversalApp.Controls
{
    public class ItemDetailsTemplateSelector : DataTemplateSelector
    {
        public DataTemplate EducationTranslationTemplate { get; set; }
        public DataTemplate JobTranslationTemplate { get; set; }
        public DataTemplate ProjectTranslationTemplate { get; set; }
        public DataTemplate DefaultTemplate { get; set; }

        protected override DataTemplate SelectTemplateCore(object item, DependencyObject container)
        {
            if (item is EducationTranslation)
                return EducationTranslationTemplate;
            if (item is JobTranslation)
                return JobTranslationTemplate;
            if (item is ProjectTranslation)
                return ProjectTranslationTemplate;
            return DefaultTemplate;
        }
    }
}
