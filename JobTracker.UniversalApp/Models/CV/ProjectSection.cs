using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace JobTracker.Models.CV
{
    public class ProjectSection : Section<ProjectItem>
    {
        public ProjectSection() : base("ProjectSectionName") { }
    }
}
