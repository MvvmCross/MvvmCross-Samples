using XPlatformMenus.Core.ViewModels;

namespace XPlatformMenus.WPF.Views
{
    [MvxRegion("PageContent")]
    public partial class LoginView : BaseView
    {
        public new LoginViewModel ViewModel
        {
            get { return (LoginViewModel)base.ViewModel; }
            set { base.ViewModel = value; }
        }

        public LoginView()
        {
            InitializeComponent();
        }
    }
}
