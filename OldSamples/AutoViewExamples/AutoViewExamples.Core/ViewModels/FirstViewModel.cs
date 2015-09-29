using System;
using System.Collections.Generic;
using System.Windows.Input;
using Cirrious.MvvmCross.AutoView;
using Cirrious.MvvmCross.AutoView.Auto;
using Cirrious.MvvmCross.AutoView.Auto.Dialog;
using Cirrious.MvvmCross.AutoView.Auto.List;
using Cirrious.MvvmCross.AutoView.Auto.Menu;
using Cirrious.MvvmCross.AutoView.Interfaces;
using Cirrious.MvvmCross.ViewModels;
using CrossUI.Core.Descriptions;

namespace AutoViewExamples.Core.ViewModels
{
    public class FirstViewModel
        : MvxViewModel
        , IMvxAutoDialogViewModel
    {
        public bool SupportsAutoView(string type)
        {
            switch (type)
            {
                case MvxAutoViewConstants.Dialog:
                    return true;

                default:
                    return false;
            }
        }

        public KeyedDescription GetAutoView(string type)
        {
            switch (type)
            {
                case MvxAutoViewConstants.Dialog:
                    return GetDialogAutoView();

                default:
                    return null;
            }
        }

        private KeyedDescription GetDialogAutoView()
        {
            var auto = new RootAuto(caption: "Children")
            {
                new SectionAuto(header: "Options")
                    {
                        new StringAuto(caption: "Dialog", selectedCommand: () => ShowDialogCommand ) ,
                        new StringAuto(caption: "List", selectedCommand: () => ShowListCommand ) ,
                    },
            };

            return auto.ToElementDescription();
        }

        public ICommand ShowDialogCommand
        {
            get { return new MvxCommand(() => ShowViewModel<AutoDialogViewModel>());}
        }

        public ICommand ShowListCommand
        {
            get { return new MvxCommand(() => ShowViewModel<AutoListViewModel>());}
        }
    }

    public class AutoDialogViewModel 
		: MvxViewModel
        , IMvxAutoDialogViewModel
    {
        public bool SupportsAutoView(string type)
        {
            switch (type)
            {
                case MvxAutoViewConstants.Dialog:
                    return true;

                case MvxAutoViewConstants.Menu:
                    return true;

                default:
                    return false;
            }
        }

        public KeyedDescription GetAutoView(string type)
        {
            switch (type)
            {
                case MvxAutoViewConstants.Dialog:
                    return GetDialogAutoView();

                case MvxAutoViewConstants.Menu:
                    return GetMenuAutoView();

                default:
                    return null;
            }
        }

        private KeyedDescription GetMenuAutoView()
        {
            var auto = new ParentMenuAuto()
                           {
                               new MenuAuto(caption: "Reset",
                                   longCaption: "Reset this thing",
                                   command: () => ResetCommand),
                           };

            return auto.ToParentMenuDescription();
        }

        public ICommand ResetCommand
        {
            get { return new MvxCommand(() =>
                {
                    Name = "Reset";
                    Password = "";
                    IsAvailable = false;
                    IsActive = false;
                    DateOfBirth = new DateTime(2000,1,1,0,0,0, DateTimeKind.Utc);
                    PreferredContactTime = new DateTime(2000, 1, 1, 0, 0, 0, DateTimeKind.Utc);
                }); 
            }
        }


        private KeyedDescription GetDialogAutoView()
        {
            var auto = new RootAuto(caption: "Some Dialog Info")
            {
                new SectionAuto(header: "Strings")
                    {
                        new EntryAuto(caption: "Name", bindingExpression: () => Name),
                        new EntryAuto(caption: "Password", bindingExpression: () => Password) { Password = true },
                    },
                new SectionAuto(header: "Booleans")
                    {
                        new BooleanAuto(caption: "Is available", bindingExpression: () => IsAvailable),
                        new CheckboxAuto(caption: "Is active", bindingExpression: () => IsActive),
                    },
                new SectionAuto(header: "DateTimes")
                    {
                        new DateAuto(caption: "Date of Birth", bindingExpression: () => DateOfBirth),
                        new TimeAuto(caption: "When", bindingExpression: () => PreferredContactTime),
                    },
                new SectionAuto(header: "Debug Info")
                    {
                        new StringAuto(caption: "Name", bindingExpression: () => Name),
                        new StringAuto(caption: "Password", bindingExpression: () => Password),
                        new StringAuto(caption: "Is available", bindingExpression: () => IsAvailable),
                        new StringAuto(caption: "Is active", bindingExpression: () => IsActive),
                        new StringAuto(caption: "Date of Birth", bindingExpression: () => DateOfBirth),
                        new StringAuto(caption: "When", bindingExpression: () => PreferredContactTime),
                    },
            };

            return auto.ToElementDescription();
        }

        private string _name = "Fred";
        public string Name
        {
            get { return _name; }
            set { _name = value; RaisePropertyChanged(() => Name); }
        }

        private bool _isActive;
        public bool IsActive
        {
            get { return _isActive; }
            set { _isActive = value; RaisePropertyChanged(() => IsActive); }
        }

        private bool _isAvailable;
        public bool IsAvailable
        {
            get { return _isAvailable; }
            set { _isAvailable = value; RaisePropertyChanged(() => IsAvailable); }
        }

        private DateTime _dateOfBirth = new DateTime(1972, 7, 13, 0, 0, 0, DateTimeKind.Utc);
        public DateTime DateOfBirth
        {
            get { return _dateOfBirth; }
            set { _dateOfBirth = value; RaisePropertyChanged(() => DateOfBirth); }
        }

        private DateTime _preferredContactTime = new DateTime(2000, 1, 1, 17, 0, 0, 0, DateTimeKind.Utc);
        public DateTime PreferredContactTime
        {
            get { return _preferredContactTime; }
            set { _preferredContactTime = value; RaisePropertyChanged(() => PreferredContactTime); }
        }


        private string _password = "password";
        public string Password
        {
            get { return _password; }
            set { _password = value; RaisePropertyChanged(() => Password); }
        }
    }
    public class Person
    {
        public Person()
        {}

        public Person(string name, string job)
        {
            Name = name;
            Job = job;
        }
        public string Name { get; set; }
        public string Job { get; set; }
    }
    public class AutoListViewModel
            : MvxViewModel
            , IMvxAutoListViewModel
    {
        public bool SupportsAutoView(string type)
        {
            switch (type)
            {
                case MvxAutoViewConstants.List:
                    return true;

                case MvxAutoViewConstants.Menu:
                    return true;

                default:
                    return false;
            }
        }

        public KeyedDescription GetAutoView(string type)
        {
            switch (type)
            {
                case MvxAutoViewConstants.List:
                    return GetListAutoView();

                case MvxAutoViewConstants.Menu:
                    return GetMenuAutoView();

                default:
                    return null;
            }
        }

        private KeyedDescription GetMenuAutoView()
        {
            var auto = new ParentMenuAuto()
                           {
                               new MenuAuto(caption: "Close",
                                   longCaption: "Close this list",
                                   command: () => CloseCommand),
                           };

            return auto.ToParentMenuDescription();
        }

        public ICommand CloseCommand
        {
            get
            {
                return new MvxCommand(() =>
                    {
                        Close(this);
                    });
            }
        }

        private List<Person> _people = new List<Person>()
            {
                new Person("Bob", "Builder"),
                new Person("Thomas", "Tank Engine"),
                new Person("Gordon", "Gopher"),
                new Person("Roger", "Rocketeer"),
                new Person("Ben", "Flowerpot man"),
                new Person("Bill", "Another flowerpot man"),
                new Person("Muffin", "Mule"),
                new Person("Sooty", "Sweep"),
                new Person("Ben", "Big"),
                new Person("Jess", "Cat"),
                new Person("Stuart", "Dogsbody"),                
            };
        public List<Person> People
        {
            get { return _people; }
            set { _people = value; RaisePropertyChanged(() => People); }
        }
        
        public ICommand PersonSelectedCommand
        {
            get { return new MvxCommand<Person>(person => ShowViewModel<PersonViewModel>(person));}
        }

        private KeyedDescription GetListAutoView()
        {
            var list = new ListAuto(key: "General",
                                    itemsSource: () => People,
                                    selectedCommand: () => PersonSelectedCommand);

            list.DefaultLayout = new ListLayoutAuto<Person>(key: "General",
                                                    layoutName: "TitleAndSubTitle")
                                     {
                                         new BindingAuto<Person>("Title", c => c.Name),
                                         new BindingAuto<Person>("SubTitle", c => c.Job)
                                     };

            return list.ToDescription();
        }
    }

    public class PersonViewModel
        : MvxViewModel
        , IMvxAutoDialogViewModel
    {
        public Person Person { get; private set; }

        public void Init(Person person)
        {
            Person = person;
        }

        public bool SupportsAutoView(string type)
        {
            switch (type)
            {
                case MvxAutoViewConstants.Dialog:
                    return true;

                default:
                    return false;
            }
        }

        public KeyedDescription GetAutoView(string type)
        {
            switch (type)
            {
                case MvxAutoViewConstants.Dialog:
                    return GetDialogAutoView();

                default:
                    return null;
            }
        }

        private KeyedDescription GetDialogAutoView()
        {
            var auto = new RootAuto(caption: "The Person")
            {
                new SectionAuto(header: "Name")
                    {
                        new EntryAuto(caption: "Name", bindingExpression: () => Person.Name),
                        new EntryAuto(caption: "Job", bindingExpression: () => Person.Job),
                    },
            };

            return auto.ToElementDescription();
        }
    }
}
