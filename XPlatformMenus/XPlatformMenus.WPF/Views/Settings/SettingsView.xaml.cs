using XPlatformMenus.Core.ViewModels;

namespace XPlatformMenus.WPF.Views
{
    [MvxRegion("PageContent")]
    public partial class SettingsView : BaseView
    {
        public new SettingsViewModel ViewModel
        {
            get { return (SettingsViewModel)base.ViewModel; }
            set { base.ViewModel = value; }
        }

        public SettingsView()
        {
            InitializeComponent();
        }
    }
}
