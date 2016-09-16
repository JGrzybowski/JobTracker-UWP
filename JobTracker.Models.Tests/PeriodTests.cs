using JobTracker.Models.FieldTypes;
using Shouldly;
using System;
using Xunit;
namespace JobTracker.Models.Tests
{
    public class PeriodTests
    {
        [Fact]
        public void ToDateCantBeBeforeFromDate()
        {
            var period = new Period(new DateTime(2000, 12, 24), new DateTime(2000, 12, 24));

            Should.Throw<ArgumentException>(
                () => period.To = new DateTime(1990, 11, 01));
        }

        [Fact]
        public void FromDateValueCantBeAfterToDate()
        {
            var period = new Period(new DateTime(1990, 12, 24), new DateTime(1990, 12, 24));

            Should.Throw<ArgumentException>(
                () => period.From = new DateTime(2000, 11, 01));
        }
    }
}
