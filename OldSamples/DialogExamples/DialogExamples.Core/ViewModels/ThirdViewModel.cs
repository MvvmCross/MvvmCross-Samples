using System.Collections.Generic;
using System.Windows.Input;
using Cirrious.MvvmCross.ViewModels;

namespace DialogExamples.Core.ViewModels
{
    public class ThirdViewModel
        : MvxViewModel
    {
        public ICommand ShortListCommand
        {
            get
            {
                return new MvxCommand(() =>
                    {
                        People = new List<Person>()
                            {
                                new Person()
                                    {
                                        FirstName = "Fred",
                                        LastName = "Flint"
                                    },
                                new Person()
                                    {
                                        FirstName = "Barney",
                                        LastName = "Rubble"
                                    },
                            };
                    });
            }
        }

        public ICommand LongListCommand
        {
            get
            {
                return new MvxCommand(() =>
                    {
                        People = new List<Person>()
                            {
                                new Person()
                                    {
                                        FirstName = "Bob",
                                        LastName = "Builder"
                                    },
                                new Person()
                                    {
                                        FirstName = "Thomas",
                                        LastName = "Tank-Engine"
                                    },
                                new Person()
                                    {
                                        FirstName = "Billy",
                                        LastName = "Kid"
                                    },
                                new Person()
                                    {
                                        FirstName = "Woody",
                                        LastName = "Roundup"
                                    },
                                new Person()
                                    {
                                        FirstName = "Buzz",
                                        LastName = "Lightyear"
                                    },
                                new Person()
                                    {
                                        FirstName = "Captain",
                                        LastName = "Kirk"
                                    },
                                new Person()
                                    {
                                        FirstName = "Jemima",
                                        LastName = "Puddleduck"
                                    },
                                new Person()
                                    {
                                        FirstName = "Quick",
                                        LastName = "Basic"
                                    },
                                new Person()
                                    {
                                        FirstName = "Turbo",
                                        LastName = "Pascal"
                                    },
                            };
                    });
            }
        }

        public class Person
        {
            public string FirstName { get; set; }
            public string LastName { get; set; }
        }

        private List<Person> _people;
        public List<Person> People 
        {   
            get { return _people; }
            set { _people = value; RaisePropertyChanged(() => People); }
        }
    }
}