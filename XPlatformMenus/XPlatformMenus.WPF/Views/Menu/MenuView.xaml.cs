using XPlatformMenus.Core.ViewModels;

namespace XPlatformMenus.WPF.Views
{
    [MvxRegion("MenuContent")]
    public partial class MenuView : BaseView
    {
        public new MenuViewModel ViewModel
        {
            get { return (MenuViewModel)base.ViewModel; }
            set { base.ViewModel = value; }
        }

        public MenuView()
        {
            InitializeComponent();
        }
    }
}
