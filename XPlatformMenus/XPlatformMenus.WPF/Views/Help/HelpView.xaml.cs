using XPlatformMenus.Core.ViewModels;

namespace XPlatformMenus.WPF.Views
{
    [MvxRegion("PageContent")]
    public partial class HelpView : BaseView
    {
        public new HelpAndFeedbackViewModel ViewModel
        {
            get { return (HelpAndFeedbackViewModel)base.ViewModel; }
            set { base.ViewModel = value; }
        }

        public HelpView()
        {
            InitializeComponent();
        }
    }
}
