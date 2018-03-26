using MvvmCross.Uwp.Attributes;
using XPlatformMenus.Core.ViewModels;

namespace XPlatformMenus.UWP.Views
{
    [MvxRegionPresentation("PageContent")]
    public sealed partial class HomeView
	{
		public new HomeViewModel ViewModel
		{
			get { return (HomeViewModel)base.ViewModel; }
			set { base.ViewModel = value; }
		}

		public HomeView()
		{
			InitializeComponent();
            DataContext = ViewModel;
		}
    }
}
