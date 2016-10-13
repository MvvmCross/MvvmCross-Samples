using MvvmCross.WindowsUWP.Views;
using XPlatformMenus.Core.ViewModels;

namespace XPlatformMenus.UWP.Views
{
	[MvxRegion("PageContent")]
	public sealed partial class HelpView
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
