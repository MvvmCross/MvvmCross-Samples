using MvvmCross.Core.ViewModels;
using MvvmCross.Platform;
using MvvmCross.Plugins.Messenger;
using XPlatformMenus.Core.Messages;

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
            //basically we are resetting the stack
            //ShowViewModel<HomeViewModel>();
            var messenger = Mvx.Resolve<IMvxMessenger>();
            messenger.Publish<PopToRootMessage>(new PopToRootMessage(this));
        }
    }
}