using XPlatformMenus.Core.ViewModels;

namespace XPlatformMenus.WPF.Views
{
    [MvxRegion("PageContent")]
    public partial class ThirdView : BaseView
    {
        public new ThirdViewModel ViewModel
        {
            get { return (ThirdViewModel)base.ViewModel; }
            set { base.ViewModel = value; }
        }

        public ThirdView()
        {
            InitializeComponent();
        }
    }
}
