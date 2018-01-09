using MvvmCross.Uwp.Attributes;
using XPlatformMenus.Core.ViewModels;

// The Blank Page item template is documented at http://go.microsoft.com/fwlink/?LinkId=234238

namespace XPlatformMenus.UWP.Views
{
    [MvxRegionPresentation("PageContent")]
    public sealed partial class InfoView
    {
        public new InfoViewModel ViewModel
        {
            get { return (InfoViewModel)base.ViewModel; }
            set { base.ViewModel = value; }
        }

        public InfoView()
        {
            InitializeComponent();
            DataContext = ViewModel;
        }
    }
}
