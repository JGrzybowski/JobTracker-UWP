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
            Address = new Address { City = "London", Country = "Great Britain", Line1 = "Imaginary Street 13", Line2 = "", ZipCode = "SW1A 2AB" },
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
            },
            Jobs = new JobSection
            {
                Items = new SectionItemsCollection<JobItem>
                {
                    new JobItem()
                    {
                        Name = "First Job",
                        TimePeriod = new Period() {From= new DateTime(1996,6,14), To=new DateTime(2001,11,2), DatesPartsVisibility=TimeUnit.Full },
                        Translations= new TranslationCollection<JobTranslation>
                        {
                            new JobTranslation(SupportedLanguages.English) {CompanyName = "Creatures Inc.", Position="Door Conservator", Responsibilities="Cleaning the portal-doors." },
                            new JobTranslation(SupportedLanguages.Polish) {CompanyName = "Potworki i sp.", Position="Konserwator Drzwi", Responsibilities="Czyszczenie drzwi-portali" }
                        }
                    }
                }
            },
            Projects = new ProjectSection
            {
                Items = new SectionItemsCollection<ProjectItem>
                {
                    new ProjectItem
                    {
                        Name = "JobTracker",
                        TimePeriod = new Period() {From = new DateTime(2015,03,01), TillNow= true, DatesPartsVisibility=TimeUnit.MonthAndYear},
                        Translations = new TranslationCollection<ProjectTranslation>
                        {
                            new ProjectTranslation(SupportedLanguages.English) {Name = "JobTracker", Description = "Program allowing to create and customize CV, also tracks all your job applications. Designed as Windows Universal Application." },
                            new ProjectTranslation(SupportedLanguages.Polish) {Name = "JobTracker", Description = "Program pomagający tworzyć CV oraz pozwalający śledzić własne poszukiwania i próby zdobycia pracy." }
                        }
                    }
                }
            }
        };
    }
}
