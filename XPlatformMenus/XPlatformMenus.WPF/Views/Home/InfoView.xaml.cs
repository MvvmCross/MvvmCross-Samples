using XPlatformMenus.Core.ViewModels;

namespace XPlatformMenus.WPF.Views
{
    [MvxRegion("PageContent")]
    public partial class InfoView : BaseView
    {
        public new InfoViewModel ViewModel
        {
            get { return (InfoViewModel)base.ViewModel; }
            set { base.ViewModel = value; }
        }
        public InfoView()
        {
            InitializeComponent();
        }
    }
}
