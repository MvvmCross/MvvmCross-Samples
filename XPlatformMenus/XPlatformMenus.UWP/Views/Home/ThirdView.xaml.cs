using MvvmCross.WindowsUWP.Views;
using XPlatformMenus.Core.ViewModels;

// The Blank Page item template is documented at http://go.microsoft.com/fwlink/?LinkId=234238

namespace XPlatformMenus.UWP.Views
{
    [MvxRegion("PageContent")]
    public sealed partial class ThirdView
    {
        public new ThirdViewModel ViewModel
        {
            get { return (ThirdViewModel)base.ViewModel; }
            set { base.ViewModel = value; }
        }

        public ThirdView()
        {
            InitializeComponent();
            DataContext = ViewModel;
        }
    }
}
