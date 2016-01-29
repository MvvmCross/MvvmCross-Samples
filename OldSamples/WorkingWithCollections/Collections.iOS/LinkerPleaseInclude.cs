using System.Collections.ObjectModel;

namespace Collections.Touch
{
    public class LinkerPleaseInclude
    {
        public void IncludeCollectionChanged()
        {
            var collection = new ObservableCollection<string>();
            collection.CollectionChanged += (sender, args) => { };
        }
    }
}