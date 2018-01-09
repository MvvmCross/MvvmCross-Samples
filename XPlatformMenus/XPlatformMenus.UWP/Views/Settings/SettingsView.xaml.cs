using MvvmCross.Uwp.Attributes;
using XPlatformMenus.Core.ViewModels;

namespace XPlatformMenus.UWP.Views
{
    [MvxRegionPresentation("PageContent")]
    public sealed partial class SettingsView
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
