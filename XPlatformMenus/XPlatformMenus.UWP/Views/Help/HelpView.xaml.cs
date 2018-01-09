using MvvmCross.Uwp.Attributes;
using XPlatformMenus.Core.ViewModels;

namespace XPlatformMenus.UWP.Views
{
    [MvxRegionPresentation("PageContent")]
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
