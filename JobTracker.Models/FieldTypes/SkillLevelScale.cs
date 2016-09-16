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
        private int step = 1;
        public int Step
        {
            get { return step; }
            set
            {
                if (value > 0)
                    SetProperty(ref step, value);
                else
                    throw new ArgumentException("Step size must be greater than zero.");
            }
        }
    }
}
