using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace JobTracker.UniversalApp.Models
{
    public static class SupportedLanguages
    {
        public const string English = "en-US";
        public const string Polish = "pl";
        public const string German = "de-DE";
        //public const string Spanish = "sp-SP";
        //public const string Italian = "it-IT";
        public const string French = "fr-FR";
        public static readonly List<string> List = new List<string>{ English, German, French, Polish };
    }
}
