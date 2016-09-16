using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Xml.Serialization;

namespace JobTracker.Models.CV
{
    public class ProjectItem : PeriodicalTranslatedItem<ProjectTranslation>
    {
        public ProjectItem() : base() { }
    }
}
