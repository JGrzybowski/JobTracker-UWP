using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace JobTracker.UniversalApp.Services.ResourcesServices
{
    public interface ILocalizedStringsProvider
    {
        string GetLocalizedString(string resourceStringName, string languageTag);
    }
}
