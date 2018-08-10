using MvvmCross.Forms.Views;
using MvvmCross.Forms.Presenters.Attributes;
using StarWarsSample.Core.ViewModels;

namespace StarWarsSample.Forms
{
    [MvxMasterDetailPagePresentation(MasterDetailPosition.Root, WrapInNavigationPage = false)]
    public partial class MainPage : MvxMasterDetailPage<MainViewModel>
    {
        private bool _firstTime = true;

        public MainPage()
        {
            InitializeComponent();
        }

        protected override void OnAppearing()
        {
            if (_firstTime)
            {
                ViewModel.ShowMenuViewModelCommand.Execute(null);
                ViewModel.ShowPlanetsViewModelCommand.Execute(null);

                _firstTime = false;
            }

            base.OnAppearing();
        }
    }
}
