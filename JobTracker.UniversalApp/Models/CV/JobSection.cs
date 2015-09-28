using JobTracker.Models.CV;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace JobTracker.Models.CV
{
    public class JobSection : Section<JobItem>
    {
        public JobSection() : base("JobSectionName"){ }
    }
}
