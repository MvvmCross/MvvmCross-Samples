using MvvmCross.Core.ViewModels;

namespace XPlatformMenus.Core.ViewModels
{
	public class ThirdViewModel : BaseViewModel
    {
     
        private MvxCommand saveAndCloseCommand;

        public MvxCommand SaveAndCloseCommand
        {
            get
            {
                saveAndCloseCommand = saveAndCloseCommand ?? new MvxCommand(DoSaveAndClose);
                return saveAndCloseCommand;
            }
        }

        private void DoSaveAndClose()
        {
            Close(this);
        }


    }
}