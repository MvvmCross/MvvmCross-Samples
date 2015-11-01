using System.Windows;
using Collections.Core.ViewModels.Samples.ListItems;

namespace Collections.WP.Views.Samples.PolymorhphicListItemTypes
{
    public class AnimalTemplateSelector : BaseDataTemplateSelector
    {
        public DataTemplate KittenTemplate { get; set; }

        public DataTemplate DogTemplate { get; set; }

        public override DataTemplate SelectTemplate(
            object item, DependencyObject container)
        {
            if (item is Kitten)
                return KittenTemplate;
            else if (item is Dog)
                return DogTemplate;

            return base.SelectTemplate(item, container);
        }
    }
}