using System;
using MvvmCross.Core.ViewModels;
using MvvmCross.Platform.Platform;
using StarWarsSample.Models;

namespace StarWarsSample.ViewModels
{
    public class PersonViewModel : BaseViewModel
    {
        private readonly IMvxJsonConverter _jsonConverter;

        public PersonViewModel(IMvxJsonConverter jsonConverter)
        {
            _jsonConverter = jsonConverter;
        }

        public void Init(string serializedPerson)
        {
            Person = _jsonConverter.DeserializeObject<Person>(serializedPerson);
        }

        public Person Person { get; set; }
    }
}
