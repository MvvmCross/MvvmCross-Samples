using System.Collections.Generic;
using Cirrious.MvvmCross.ViewModels;
using Collections.Core.ViewModels.Samples.ListItems;

namespace Collections.Core.ViewModels.Samples
{
    public class BaseSampleViewModel : MvxViewModel
    {
        private readonly DogGenerator _dogGenerator = new DogGenerator();
        private readonly KittenGenerator _kittenGenerator = new KittenGenerator();

        protected Kitten CreateKitten()
        {
            return _kittenGenerator.CreateNewKitten();
        }

        protected Kitten CreateKittenNamed(string name)
        {
            var kitten = CreateKitten();
            kitten.Name = name;
            return kitten;
        }

        protected IEnumerable<Kitten> CreateKittens(int count)
        {
            for (var i = 0; i < count; i++)
            {
                yield return CreateKitten();
            }
        }

        protected Dog CreateDog()
        {
            return _dogGenerator.CreateNewDog();
        }

        protected IEnumerable<Dog> CreateDogs(int count)
        {
            for (var i = 0; i < count; i++)
            {
                yield return CreateDog();
            }
        }
    }
}