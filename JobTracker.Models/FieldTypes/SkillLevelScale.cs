using Prism.Mvvm;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace JobTracker.Models.FieldTypes
{
    public class SkillLevelScale : BindableBase
    {
        private int min = 0;
        public int Min
        {
            get { return min; }
            set
            {
                if(value < Max)
                    SetProperty(ref min, value);
                else 
                    throw new ArgumentException("Min must be less than Max.");
            }
        }

        private int max = 10;
        public int Max
        {
            get { return max; }
            set
            {
                if (value > Min)
                    SetProperty(ref max, value);
                else
                    throw new ArgumentException("Max must be greater than Min.");
            }
        }
        private int step = 0;
        public int Step
        {
            get { return step; }
            set { SetProperty(ref step, value); }
        }
    }
}
