using System.Threading.Tasks;
using MvvmCross.Core.ViewModels;
using Nito.AsyncEx;
using StarWarsSample.Models;
using StarWarsSample.Services.Interfaces;

namespace StarWarsSample.ViewModels
{
    public class MainViewModel : MvxViewModel
    {
        private readonly IPeopleService _peopleService;

        public MainViewModel(IPeopleService peopleService)
        {
            _peopleService = peopleService;
        }

        // MvvmCross Lifecycle
        public override void Start()
        {
            base.Start();

            LoadPersonTask = NotifyTaskCompletion.Create(GetPerson);
        }

        // MVVM Properties
        public INotifyTaskCompletion LoadPersonTask { get; set; }

        private Person _person;
        public Person Person
        {
            get
            {
                return _person;
            }
            set
            {
                _person = value;
                RaisePropertyChanged(() => Person);
            }
        }

        // MVVM Commands

        // Private methods
        private async Task GetPerson()
        {
            Person = await _peopleService.GetPersonAsync();
        }
    }
}
