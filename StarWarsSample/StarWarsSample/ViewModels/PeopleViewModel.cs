using System;
using System.Threading.Tasks;
using MvvmCross.Core.ViewModels;
using Nito.AsyncEx;
using StarWarsSample.Models;
using StarWarsSample.Services.Interfaces;

namespace StarWarsSample.ViewModels
{
    public class PeopleViewModel : MvxViewModel
    {
        private readonly IPeopleService _peopleService;

        private string _nextPage;

        public PeopleViewModel(IPeopleService peopleService)
        {
            _peopleService = peopleService;

            People = new MvxObservableCollection<Person>();

            PersonSelectedCommand = new MvxCommand<Person>(PersonSelected);
            FetchPeopleCommand = new MvxCommand(
                () =>
            {
                if (!string.IsNullOrEmpty(_nextPage))
                    NotifyTaskCompletion.Create(LoadPeople);
            });
        }

        // MvvmCross Lifecycle
        public override void Start()
        {
            base.Start();

            LoadPeopleTask = NotifyTaskCompletion.Create(LoadPeople);
        }

        // MVVM Properties
        public INotifyTaskCompletion LoadPeopleTask { get; set; }

        public INotifyTaskCompletion FetchPeopleTask { get; set; }

        private MvxObservableCollection<Person> _people;
        public MvxObservableCollection<Person> People
        {
            get
            {
                return _people;
            }
            set
            {
                _people = value;
                RaisePropertyChanged(() => People);
            }
        }

        // MVVM Commands
        public IMvxCommand PersonSelectedCommand { get; set; }

        public IMvxCommand FetchPeopleCommand { get; set; }

        // Private methods
        private async Task LoadPeople()
        {
            var result = await _peopleService.GetPeopleAsync(_nextPage);

            _nextPage = result.Next;

            People.AddRange(result.Results);
        }

        private void PersonSelected(Person selectedPerson)
        {
            ShowViewModel<PersonViewModel>();
        }
    }
}
