using MvvmCross.Platforms.Wpf.Presenters.Attributes;
using MvvmCross.Platforms.Wpf.Views;
using TwitterSearch.Core.ViewModels;

namespace TwitterSearch.UI.Wpf.Views
{
    /// <summary>
    /// Interaction logic for TwitterView.xaml
    /// </summary>
    [MvxContentPresentation(WindowIdentifier = "Detail", StackNavigation = false)]
    public partial class TwitterView : MvxWpfView<TwitterViewModel>
    {
        public TwitterView()
        {
            InitializeComponent();
        }
    }
}