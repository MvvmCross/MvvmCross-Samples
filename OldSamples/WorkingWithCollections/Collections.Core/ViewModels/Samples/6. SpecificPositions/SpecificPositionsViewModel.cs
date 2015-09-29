using System.Collections.Generic;
using Collections.Core.ViewModels.Samples.ListItems;

namespace Collections.Core.ViewModels.Samples.SpecificPositions
{
    public class SpecificPositionsViewModel : BaseSampleViewModel
    {
        private List<Kitten> _kittens;

        private Dictionary<string, Kitten> _lookup;

        public SpecificPositionsViewModel()
        {
            var list = new List<Kitten>();
            for (var i = 0; i < 10; i++)
            {
                var kitten = CreateKittenNamed("Kitten " + i);
                list.Add(kitten);
            }
            Kittens = list;
            Lookup = new Dictionary<string, Kitten>
                {
                    {"Kitty", CreateKittenNamed("Kitty")},
                    {"Tom", CreateKittenNamed("Tom")},
                    {"Felix", CreateKittenNamed("Felix")},
                    {"Tiger", CreateKittenNamed("Tiger")},
                    {"Lion", CreateKittenNamed("Lion")},
                    {"Simba", CreateKittenNamed("Simba")},
                };
        }

        public List<Kitten> Kittens
        {
            get { return _kittens; }
            set
            {
                _kittens = value;
                RaisePropertyChanged(() => Kittens);
            }
        }

        public Dictionary<string, Kitten> Lookup
        {
            get { return _lookup; }
            set
            {
                _lookup = value;
                RaisePropertyChanged(() => Lookup);
            }
        }
    }
}