using JobTracker.Models.FieldTypes;
using JobTracker.Models.Tests;
using Shouldly;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Xunit;

namespace JobTracker.Models.Tests
{
    public class SkillLevelDescriptiveScaleTests
    {
        public class Constructor
        {
            [Theory]
            [InlineData(0)]
            [InlineData(-5)]
            public void CantConstructScaleWithSizeLessOrEqualZero(int scaleSize)
            {
                Should.Throw<ArgumentException>(
                    () => new SkillLevelDescriptiveScale(scaleSize));
            }

            //[Fact]
            //public void CreatesEmptyReadableScale()
            //{
            //    var scale = new SkillLevelDescriptiveScale(3);                
            //}
        }

        public class ScaleSizeProperty
        {
            //[Theory]
            //[InlineData(0)]
            //[InlineData(-5)]
            //public void CantBeSetLessOrEqualZero(int scaleSize)
            //{
            //    var scale = new SkillLevelDescriptiveScale(10);

            //    Should.Throw<ArgumentException>(
            //        () => scale.Size = scaleSize);
            //}

            //[Theory]
            //[InlineData(15)]
            //public void CanBeGreaterThanZero(int scaleSize)
            //{
            //    var scale = new SkillLevelDescriptiveScale(5);

            //    Should.NotThrow(() => scale.Size = scaleSize);
            //    scale.Size.ShouldBe(scaleSize);
            //}


        }

        public class AddLanguageMethod
        {
            [Fact]
            public void CantAddSameLanguageTwice()
            {
                var langCode = "en";
                var scale = new SkillLevelDescriptiveScale(5);
                scale.AddDictionary(langCode);

                Should.Throw<ArgumentException>(() => scale.AddDictionary(langCode));
            }

            [Fact]
            public void CantAddNullLanguage()
            {
                string langCode = null;
                var scale = new SkillLevelDescriptiveScale(5);

                Should.Throw<ArgumentException>(() => scale.AddDictionary(langCode));
            }

            [Fact]
            public void AddsEmptyDictionary()
            {
                var scale = EnglishScale();

                scale.AddDictionary("es");

                scale[0, "es"].ShouldBeNullOrEmpty();
                scale[1, "es"].ShouldBeNullOrEmpty();
                scale[2, "es"].ShouldBeNullOrEmpty();
            }
        }
        public class AddLanguageWithEnumerableMethod
        {
            [Fact]
            public void CantAddSameLanguageTwice()
            {
                var langCode = "en";
                var existingDictionary = new List<string>() { "Beginner", "Expert" };

                var scale = new SkillLevelDescriptiveScale(existingDictionary.Count);
                scale.AddDictionary(langCode);

                Should.Throw<ArgumentException>(() => scale.AddDictionary(langCode, existingDictionary));
            }

            [Fact]
            public void CantAddNullLanguage()
            {
                string langCode = null;
                var existingDictionary = new List<string>() { "Beginner", "Expert" };

                var scale = new SkillLevelDescriptiveScale(existingDictionary.Count);

                Should.Throw<ArgumentException>(() => scale.AddDictionary(langCode, existingDictionary));
            }

            [Fact]
            public void AddedExistingDictionaryMustBeOfLengthOfScaleSize()
            {
                var langCode = "en";
                var existingDictionary = new List<string>() { "Beginner", "Expert" };

                var scale = new SkillLevelDescriptiveScale(existingDictionary.Count + 5);

                Should.Throw<ArgumentException>(() => scale.AddDictionary(langCode, existingDictionary));
            }

            [Fact]
            public void AddsGivenDictionary()
            {
                var scale = EnglishScale();
                var polishDictionary = new List<string> { "Początkujący", "Zaawansowany", "Ekspert" };

                scale.AddDictionary("pl", polishDictionary);

                scale[0, "pl"].ShouldBe("Początkujący");
                scale[1, "pl"].ShouldBe("Zaawansowany");
                scale[2, "pl"].ShouldBe("Ekspert");
            }
        }

        public class RemoveLanguageMethod
        {
            [Fact]
            public void CantRemoveLanguageWhichIsNotInScale()
            {
                var scale = EnglishScale();

                Should.Throw<ArgumentException>(() => scale.RemoveDictionary("es"));
            }

            [Fact]
            public void RemovesAccessToSelectedDictionary()
            {
                var scale = EnglishScale();

                scale.RemoveDictionary("en");

                string read;
                Should.Throw<ArgumentException>(() => read = scale[0, "en"]);
            }
        }
        public class AddLevelMethod
        {
            [Fact]
            public void IncreasesScaleSize()
            {
                var scale = EnglishScale();
                scale.AddLevel(2);
                scale.Size.ShouldBe(constructedScaleSize+1);
            }

            [Fact]
            public void ShiftsValuesAfterSelectedIndex()
            {
                var scale = EnglishScale();
                scale.AddLevel(1);

                scale[1, "en"].ShouldBeNullOrEmpty();
                scale[2, "en"].ShouldBe("Advanced");
                scale[3, "en"].ShouldBe("Expert");
            }

            [Fact]
            public void DoesNotChangeValuesBeforeSelectedIndex()
            {
                var scale = EnglishScale();
                scale.AddLevel(1);

                scale[0, "en"].ShouldBe("Begginer");
            }
        }

        public class RemoveLevelMethod
        {
            [Fact]
            public void CantRemoveLevelWhichIsNotInScale()
            {
                var scale = EnglishScale();

                Should.Throw<ArgumentException>(() => scale.RemoveLevel(constructedScaleSize));
                Should.Throw<ArgumentException>(() => scale.RemoveLevel(constructedScaleSize+1));
            }

            [Fact]
            public void RemovingLevelDecreasesTheScaleSize()
            {
                var scale = EnglishScale();

                scale.Size.ShouldBe(constructedScaleSize);
                scale.RemoveLevel(constructedScaleSize-1);
                scale.Size.ShouldBe(constructedScaleSize-1);           
            }

            [Fact]
            public void ShiftsValuesAfterSelectedIndex()
            {
                var scale = EnglishScale();
                scale.RemoveLevel(1);

                scale[1, "en"].ShouldBe("Expert");
            }

            [Fact]
            public void DoesNotChangeValuesBeforeSelectedIndex()
            {
                var scale = EnglishScale();
                scale.RemoveLevel(1);

                scale[0, "en"].ShouldBe("Begginer");
            }
        }

        public class IndexerProperty
        {
            [Fact]
            public void ThrowsExceptionWhenHasNoLanguageAskedFor()
            {
                var scale = EnglishScale();

                string read;
                Should.Throw<ArgumentException>(() => read = scale[1,"es"]);
                Should.Throw<ArgumentException>(() => scale[1, "es"] = "");
            }

            [Fact]
            public void ThrowsExceptionWhenHasNoLevelAskedFor()
            {
                var scale = EnglishScale();

                string read;
                Should.Throw<ArgumentException>(() => read = scale[constructedScaleSize+5, "en"]);
                Should.Throw<ArgumentException>(() => scale[constructedScaleSize + 5, "en"] = "");
            }

            [Fact]
            public void ReturnsValueFromDictionary()
            {
                var scale = EnglishScale();

                scale[0, "en"].ShouldBe("Begginer");
                scale[1, "en"].ShouldBe("Advanced");
                scale[2, "en"].ShouldBe("Expert");
            }

            [Fact]
            public void SetsValuesIntoDictionary()
            {
                var scale = EnglishScale();

                scale[1, "en"] = "Intermediate";
                scale[1, "en"].ShouldBe("Intermediate");
            }
        }

        private static int constructedScaleSize = 3;
        private static SkillLevelDescriptiveScale EmptyScale() { return new SkillLevelDescriptiveScale(constructedScaleSize); }
        private static SkillLevelDescriptiveScale EnglishScale()
        {
            var scale = new SkillLevelDescriptiveScale(constructedScaleSize);
            scale.AddDictionary("en", new List<string> { "Begginer", "Advanced", "Expert" });
            return scale;
        }

    }
}
