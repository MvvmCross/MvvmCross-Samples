using System.Collections.Generic;
using Collections.Core.ViewModels.Samples.ListItems;

namespace Collections.Core.ViewModels.Samples.MultipleListItemTypes
{
    public class PolymorphicListItemTypesViewModel : BaseSampleViewModel
    {
        private List<Animal> _animals;

        public PolymorphicListItemTypesViewModel()
        {
            var animals = new List<Animal>();
            for (var i = 0; i < 10; i++)
            {
                animals.Add(i%2 == 0 ? CreateDog() : (Animal) CreateKitten());
            }
            Animals = animals;
        }

        public List<Animal> Animals
        {
            get { return _animals; }
            set
            {
                _animals = value;
                RaisePropertyChanged(() => Animals);
            }
        }
    }
}