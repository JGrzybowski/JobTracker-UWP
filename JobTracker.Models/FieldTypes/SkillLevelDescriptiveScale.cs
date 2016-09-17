using Prism.Mvvm;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace JobTracker.Models.FieldTypes
{
    public class SkillLevelDescriptiveScale : BindableBase, IDescriptiveScale
    {
        private int scaleSize;
        public int ScaleSize
        {
            get { return scaleSize; }
            set
            {   if (value > 0)
                    SetProperty(ref scaleSize, value);
                else
                    throw new ArgumentException("Scale size must be a positive integer.");
            }
        }

        private Dictionary<string, string>[] _levels;

        public SkillLevelDescriptiveScale(int scaleSize)
        {
            ScaleSize = scaleSize;
            _levels = new Dictionary<string, string>[ScaleSize];
        }

        public string this[int level, string languageCode]
        {
            get
            {
                throw new NotImplementedException();
            }

            set
            {
                throw new NotImplementedException();
            }
        }


        public void AddDictionary(string languageCode)
        {
            throw new NotImplementedException();
        }

        public void AddDictionary(string languageCode, IEnumerable<string> levelsNames)
        {
            throw new NotImplementedException();
        }

        public void RemoveDictionary(string languageCode)
        {
            throw new NotImplementedException();
        }
        public void AddLevel(int newLevelIndex)
        {
            throw new NotImplementedException();
        }

        public void RemoveLevel(int level)
        {
            throw new NotImplementedException();
        }

    }
}
