using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;


namespace JobTracker.Models.CV
{
    public interface IWithTranslation<TTranslation> where TTranslation : ITranslation
    {
        ITranslationCollection<TTranslation> Translations { get; }
    }
}
