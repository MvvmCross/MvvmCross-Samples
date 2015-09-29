using Cirrious.Conference.Core.Interfaces;
using System.Collections.ObjectModel;

namespace Cirrious.Conference.Core.Models.Helpers
{
#warning Not Used

    public class OurObservableCollection<TKey>
        : ObservableCollection<TKey>
          , IObservableCollection<TKey>
    {
    }
}