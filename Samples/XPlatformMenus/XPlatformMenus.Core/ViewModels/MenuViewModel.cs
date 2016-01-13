using MvvmCross.Core.ViewModels;


namespace XPlatformMenus.Core.ViewModels
{
	public class MenuViewModel : BaseViewModel
    {
        #region Cross Platform Commands & Handlers

        public IMvxCommand ShowHomeCommand
        {
            get { return new MvxCommand(ShowHomeExecuted); }
        }

        private void ShowHomeExecuted()
        {
            ShowViewModel<HomeViewModel>();
        }

        public IMvxCommand ShowSettingCommand
        {
            get { return new MvxCommand(ShowSettingsExecuted); }
        }

        private void ShowSettingsExecuted()
        {
            ShowViewModel<SettingsViewModel>();
        }

        public IMvxCommand ShowHelpCommand
        {
            get { return new MvxCommand(ShowHelpExecuted); }
        }

        private void ShowHelpExecuted()
        {
            ShowViewModel<HelpAndFeedbackViewModel>();
        }

        #endregion

        #region Android Specific Demos

        public IMvxCommand ShowRecyclerCommand
        {
            get { return new MvxCommand(ShowRecyclerExecuted); }
        }

        private void ShowRecyclerExecuted()
        {
            ShowViewModel<ExampleRecyclerViewModel>();
        }

        public IMvxCommand ShowViewPagerCommand
        {
            get { return new MvxCommand(ShowViewPagerExecuted); }
        }

        private void ShowViewPagerExecuted()
        {
            ShowViewModel<ExampleViewPagerViewModel>();
        }

        #endregion
    }
}