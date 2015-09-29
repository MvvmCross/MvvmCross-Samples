using System.Collections.Generic;
using Collections.Core.ViewModels.Samples.ListItems;

namespace Collections.Core.ViewModels.Samples.LargeDynamic
{
    public class MockDataRepository
    {
        private readonly List<Kitten> _kittens;

        public MockDataRepository()
        {
            _kittens = new List<Kitten>();
            var generator = new KittenGenerator();
            for (int i = 0; i < 100; i++)
            {
                _kittens.Add(generator.CreateNewKitten());
            }
        }

        public int GetCount()
        {
            return _kittens.Count;
        }

        public Kitten GetKitten(int i)
        {
            return _kittens[i];
        }

        public void Append(Kitten kitten)
        {
            _kittens.Add(kitten);
        }

        public void DeleteAt(int i)
        {
            _kittens.RemoveAt(i);
        }
    }
}