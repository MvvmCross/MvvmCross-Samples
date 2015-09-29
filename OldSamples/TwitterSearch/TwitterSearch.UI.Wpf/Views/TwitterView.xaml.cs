using Cirrious.MvvmCross.Wpf.Views;
using TwitterSearch.Core.ViewModels;

namespace TwitterSearch.UI.Wpf.Views
{
    /// <summary>
    /// Interaction logic for TwitterView.xaml
    /// </summary>
    [Region("Detail")]
    public partial class TwitterView : MvxWpfView
    {
        public TwitterView()
        {
            InitializeComponent();
        }

        public new TwitterViewModel ViewModel
        {
            get { return base.ViewModel as TwitterViewModel; }
            set { base.ViewModel = value; }
        }
    }
}