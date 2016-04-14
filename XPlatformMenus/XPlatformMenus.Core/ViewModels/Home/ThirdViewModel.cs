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

        public MvxPresentationHint PopToRootHint { get; set; }

        private void DoSaveAndClose()
        {
            //do whatever work one would do to 'save', and send a message to pop to root    
            // MvxPanelHintType.ActivePanel
            //Close(this);
            //ShowViewModel<HomeViewModel>();
            ChangePresentation(PopToRootHint);
        }
    }
}