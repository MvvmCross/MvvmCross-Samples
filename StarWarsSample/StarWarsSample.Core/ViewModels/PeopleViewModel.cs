using System.Linq;
using System.Threading.Tasks;
using StarWarsSample.Core.Models;
using StarWarsSample.Core.ViewModelResults;
using StarWarsSample.Core.Services.Interfaces;
using MvvmCross.Navigation;
using MvvmCross.ViewModels;
using MvvmCross.Commands;

namespace StarWarsSample.Core.ViewModels
{
    public class PeopleViewModel : BaseViewModel
    {
        private readonly IPeopleService _peopleService;
        private readonly IMvxNavigationService _navigationService;

        private string _nextPage;

        public PeopleViewModel(
            IPeopleService peopleService,
            IMvxNavigationService navigationService)
        {
            _peopleService = peopleService;
            _navigationService = navigationService;

            People = new MvxObservableCollection<Person>();

            PersonSelectedCommand = new MvxAsyncCommand<Person>(PersonSelected);
            FetchPeopleCommand = new MvxCommand(
                () =>
            {
                if (!string.IsNullOrEmpty(_nextPage))
                {
                    FetchPeopleTask = MvxNotifyTask.Create(LoadPeople);
                    RaisePropertyChanged(() => FetchPeopleTask);
                }
            });
            RefreshPeopleCommand = new MvxCommand(RefreshPeople);
        }

        // MvvmCross Lifecycle
        public override Task Initialize()
        {
            LoadPeopleTask = MvxNotifyTask.Create(LoadPeople);

            return base.Initialize();
        }

        // MVVM Properties
        public MvxNotifyTask LoadPeopleTask { get; private set; }

        public MvxNotifyTask FetchPeopleTask { get; private set; }

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
        public IMvxCommand<Person> PersonSelectedCommand { get; private set; }

        public IMvxCommand FetchPeopleCommand { get; private set; }

        public IMvxCommand RefreshPeopleCommand { get; private set; }

        // Private methods
        private async Task LoadPeople()
        {
            var result = await _peopleService.GetPeopleAsync(_nextPage);

            if (string.IsNullOrEmpty(_nextPage))
            {
                People.Clear();
                People.AddRange(result.Results.Where(p => !p.Name.Contains("Vader") && !p.Name.Contains("Anakin")));
            }
            else
            {
                People.AddRange(result.Results.Where(p => !p.Name.Contains("Vader") && !p.Name.Contains("Anakin")));
            }

            _nextPage = result.Next;
        }

        private async Task PersonSelected(Person selectedPerson)
        {
            var result = await _navigationService.Navigate<PersonViewModel, Person, DestructionResult<Person>>(selectedPerson);

            if (result != null && result.Destroyed)
            {
                var person = People.FirstOrDefault(p => p.Name == result.Entity.Name);
                if (person != null)
                    People.Remove(person);
            }
        }

        private void RefreshPeople()
        {
            _nextPage = null;

            LoadPeopleTask = MvxNotifyTask.Create(LoadPeople);
            RaisePropertyChanged(() => LoadPeopleTask);
        }
    }
}
