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

        [Fact]
        public void EqualityIgnoresDatesPartsVisibility()
        {
            var periodA = new Period(new DateTime(2000, 01, 01), new DateTime(2010, 01, 01)) { DatesPartsVisibility = TimeUnit.DayMonth};
            var periodB = new Period(new DateTime(2000, 01, 01), new DateTime(2010, 01, 01)) { DatesPartsVisibility = TimeUnit.DayMonthYear};

            periodA.ShouldBe(periodB);
        }

        [Fact]
        public void EqualityIgnoresDatesVisibility()
        {
            var periodA = new Period(new DateTime(2000, 01, 01), new DateTime(2010, 01, 01)) { DatesVisibility = DatesVisibility.Single};
            var periodB = new Period(new DateTime(2000, 01, 01), new DateTime(2010, 01, 01)) { DatesVisibility = DatesVisibility.Both};

            periodA.ShouldBe(periodB);
        }

        [Fact]
        public void EqualityRespectsTillNow()
        {
            var periodA = new Period(new DateTime(2000, 01, 01), new DateTime(2010, 01, 01)) { TillNow = true };
            var periodB = new Period(new DateTime(2000, 01, 01), new DateTime(2010, 01, 01)) { TillNow = false };

            periodA.ShouldNotBe(periodB);
        }

    }
}
