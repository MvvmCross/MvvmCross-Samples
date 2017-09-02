using System.Collections.Generic;
using System.Linq;
using Collections.Core.ViewModels.Samples.Expandable;
using MvvmCross.Core.Navigation;

[assembly: MvxNavigation(typeof(ExpandableViewModel), nameof(ExpandableViewModel))]
namespace Collections.Core.ViewModels.Samples.Expandable
{
    public class ExpandableViewModel : BaseSampleViewModel
    {
        private List<KittenGroup> _kittenGroups;

        public ExpandableViewModel()
        {
            KittenGroups = CreateKittenGroups(10).ToList();
        }

        public List<KittenGroup> KittenGroups
        {
            get { return _kittenGroups; }
            set { SetProperty(ref _kittenGroups, value); }
        }
    }
}
