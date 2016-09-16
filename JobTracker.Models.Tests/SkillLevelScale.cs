using JobTracker.Models.FieldTypes;
using Shouldly;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Xunit;

namespace JobTracker.Models.Tests
{
    public class SkillLevelScaleTest
    {
        [Fact]
        public void MaxCannotBeSmallerThanMin()
        {
            var scale = new SkillLevelScale() { Min = 8 };

            Should.Throw<ArgumentException>(
                () => scale.Max = 5);
        }

        [Fact]
        public void MinMustBeSmallerThanMax()
        {
            var scale = new SkillLevelScale() { Max = 5 };

            Should.Throw<ArgumentException>(
                () => scale.Min = 10);
        }
    }
}
