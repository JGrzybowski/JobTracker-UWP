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

        [Theory]
        [InlineData(0)]
        [InlineData(-5)]
        public void StepSizeCantBeLessOrEqualZero(int stepSize)
        {
            var scale = new SkillLevelScale();

            Should.Throw<ArgumentException>(() => scale.Step = stepSize);
        }

        [Theory]
        [InlineData(5)]
        public void StepSizeMustBeGreaterThanZero(int stepSize)
        {
            var scale = new SkillLevelScale();
            Should.NotThrow(() => scale.Step = stepSize);
            scale.Step.ShouldBe(stepSize);
        }
    }
}
