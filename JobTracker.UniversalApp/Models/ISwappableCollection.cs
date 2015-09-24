using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace JobTracker.Models
{
    public interface ISwappableCollection
    {
        void SwapItems(int indexA, int indexB);
    }
}
