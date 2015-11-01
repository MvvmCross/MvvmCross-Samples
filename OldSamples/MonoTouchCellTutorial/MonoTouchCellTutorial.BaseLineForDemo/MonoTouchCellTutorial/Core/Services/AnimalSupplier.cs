using MonoTouchCellTutorial.Core.Models.Dogs;
using MonoTouchCellTutorial.Core.Models.Kittens;
using MonoTouchCellTutorial.Core.Interfaces;

namespace MonoTouchCellTutorial.Core.Services
{
    public class AnimalSupplier : IAnimalSupplier 
    {
        private readonly KittenGenerator _kittenGenerator = new KittenGenerator();
        private readonly DogGenerator _dogGenerator = new DogGenerator();

		public int KittenPrice { get { return 10; } }

		public int DogPrice { get { return 50; } }

        public Kitten BuyKitten()
        {
            return _kittenGenerator.CreateNewKitten();
        }

		public Dog BuyDog()
        {
            return _dogGenerator.CreateNewDog();
        }
    }
}