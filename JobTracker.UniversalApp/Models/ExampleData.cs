using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using JobTracker.Models;
using JobTracker.Models.CV;
using System.Collections.ObjectModel;
using JobTracker.UniversalApp.Models;

namespace JobTracker.Models
{
    public static class ExampleData
    {
        public static User ExampleUser = new User()
        {
            Address = new Address { City = "London", Country = "Great Britain", Line1 = "Imaginary Street 13", Line2="", ZipCode = "SW1A 2AB" },
            DateOfBirth = new DateTime(1985, 09, 26),
            Email = "johndoe@example.com",
            FirstName = "John",
            LastName = "Doe",
            Phone = "+1 555 555 555",
            Fax = "",
            Education = new EducationSection
            {
                Items = new SectionItemsCollection<EducationItem>
                {
                    new EducationItem() {
                        Name = "Hogwards",
                        Level = EducationLevel.HighSchool, TimePeriod = new Period() { From = new DateTime (2000,09,01), To = new DateTime(2004,05,20), DatesPartsVisibility=TimeUnit.Years},
                        Translations = new TranslationCollection<EducationTranslation>
                        {
                            new EducationTranslation(SupportedLanguages.English) { Domain = "Magic", SchoolName = "Hogwarts"},
                            new EducationTranslation(SupportedLanguages.Polish) { Domain = "Magia", SchoolName = "Hogwart" }
                        }
                    },
                    new EducationItem() {
                        Name = "Collage",
                        Level = EducationLevel.Bsc, TimePeriod = new Period() { From = new DateTime(2004,10,01), To = new DateTime(2008,06,30), DatesPartsVisibility= TimeUnit.Months },
                        Translations = new TranslationCollection<EducationTranslation>
                        {
                            new EducationTranslation (SupportedLanguages.English) { Domain = "Metaphysics", SchoolName = "Oxford University"},
                            new EducationTranslation (SupportedLanguages.Polish) { Domain = "Metafizyka", SchoolName = "Uniwersytet Oxfordzki" }
                        }
                    }
                }
            }
        };
    }
}
