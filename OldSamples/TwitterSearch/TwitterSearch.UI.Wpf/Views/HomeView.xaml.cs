using MvvmCross.Platforms.Wpf.Views;
using TwitterSearch.Core.ViewModels;

namespace TwitterSearch.UI.Wpf.Views
{
    /// <summary>
    /// Interaction logic for HomeView.xaml
    /// </summary>
    public partial class HomeView : MvxWpfView<HomeViewModel>
    {
        public HomeView()
        {
            InitializeComponent();
        }
    }
}