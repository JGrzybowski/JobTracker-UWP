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
        public int Size
        {
            get { return _levels.Count; }
        }

        private List<Dictionary<string, string>> _levels;

        public SkillLevelDescriptiveScale(int scaleSize)
        {
            if (scaleSize <= 0)
                throw new ArgumentException("Scale size must be greater than zero (>0).");

            _levels = new List<Dictionary<string, string>>();
            for (int i = 0; i < scaleSize; i++)
                _levels.Add(new Dictionary<string, string>());
        }

        public string this[int level, string languageCode]
        {
            get
            {
                if (level >= 0 && level < Size && _levels[level].ContainsKey(languageCode))
                    return _levels[level][languageCode];
                else
                    throw new ArgumentOutOfRangeException("The scale does not contain such language");
            }

            set
            {
                if (level >= 0 && level < Size && _levels[level].ContainsKey(languageCode))
                    _levels[level][languageCode] = value;
                else
                    throw new ArgumentOutOfRangeException("The scale does not contain such language");
            }
        }


        public void AddDictionary(string languageCode)
        {
            foreach(var level in _levels)
                level.Add(languageCode, string.Empty);
        }

        public void AddDictionary(string languageCode, IList<string> levelsNames)
        {
            for (int i = 0; i < _levels.Count; i++)
                _levels[i].Add(languageCode, levelsNames[i]);
        }

        public void RemoveDictionary(string languageCode)
        {
            CheckLanguageCode(languageCode);
            foreach (var level in _levels)
                level.Remove(languageCode);
        }

        public void AddLevel(int newLevelIndex)
        {
            var levelDictionary = new Dictionary<string, string>();
            foreach (var language in languages)
                levelDictionary.Add(language, string.Empty);

            _levels.Insert(newLevelIndex, levelDictionary);

        }

        public void RemoveLevel(int level)
        {
            _levels.RemoveAt(level);
        }

        private void CheckLanguageCode(string languageCode)
        {
            if (!languages.Contains(languageCode))
                throw new ArgumentOutOfRangeException("The scale does not contain such language");
        }

        private IEnumerable<string> languages {
            get
            {
                return _levels.SelectMany(level => level.Keys).Distinct();
            }
        }
    }
}
