using MvvmCross.Forms.Views;
using MvvmCross.Forms.Presenters.Attributes;
using StarWarsSample.Core.ViewModels;

namespace StarWarsSample.Forms
{
    [MvxMasterDetailPagePresentation(MasterDetailPosition.Root, WrapInNavigationPage = false)]
	public partial class MainPage : MvxMasterDetailPage<MainViewModel>
	{
		public MainPage()
		{
			InitializeComponent();
		}

        protected override void OnAppearing()
        {
            ViewModel.ShowPlanetsViewModelCommand.Execute(null);
            ViewModel.ShowMenuViewModelCommand.Execute(null);

            base.OnAppearing();
        }
	}
}
