using MvvmCross.Uwp.Attributes;
using XPlatformMenus.Core.ViewModels;

// The Blank Page item template is documented at http://go.microsoft.com/fwlink/?LinkId=234238

namespace XPlatformMenus.UWP.Views
{
    [MvxRegionPresentation("PageContent")]
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
