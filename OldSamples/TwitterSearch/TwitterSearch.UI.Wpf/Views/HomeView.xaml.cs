using Cirrious.MvvmCross.Wpf.Views;
using TwitterSearch.Core.ViewModels;

namespace TwitterSearch.UI.Wpf.Views
{
    /// <summary>
    /// Interaction logic for HomeView.xaml
    /// </summary>
    public partial class HomeView : MvxWpfView
    {
        public HomeView()
        {
            InitializeComponent();
        }

        public new HomeViewModel ViewModel
        {
            get { return base.ViewModel as HomeViewModel; }
            set { base.ViewModel = value; }
        }
    }
}