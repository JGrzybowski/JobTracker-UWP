using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace JobTracker.UniversalApp.Models
{
    public static class SupportedLanguages
    {
        public const string English = "en";
        public const string Polish = "pl";
        public const string German = "de";
        public const string Spanish = "sp";
        public const string Italian = "it";
        public const string French = "fr";
        public static readonly List<string> List = new List<string>{ English, German, French, Spanish, Italian, Polish };
    }
}
