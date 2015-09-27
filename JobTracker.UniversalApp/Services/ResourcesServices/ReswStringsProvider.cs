using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Windows.ApplicationModel.Resources.Core;

namespace JobTracker.UniversalApp.Services.ResourcesServices
{
    public class ReswStringsProvider : ILocalizedStringsProvider
    {
        private static ResourceContext context = ResourceContext.GetForViewIndependentUse();
        
        public string GetLocalizedString(string resourceStringName, string languageTag)
        {
            context.Languages = new string[] { languageTag };
            var resMap = ResourceManager.Current.MainResourceMap.GetSubtree("Resources");
            var candidate = resMap.GetValue(resourceStringName, context);
            return candidate.ValueAsString;
        }
    }
}
