﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace JobTracker.Models.FieldTypes
{
    public interface IDescriptiveScale
    {
        int ScaleSize { get; set; }
        void AddDictionary(string languageCode);
        void AddDictionary(string languageCode, IEnumerable<string> levelsNames);
        void RemoveDictionary(string languageCode);
        void AddLevel(int newLevelIndex);
        void RemoveLevel(int level);
        string this [int level, string languageCode] { get; set; }
    }
}
