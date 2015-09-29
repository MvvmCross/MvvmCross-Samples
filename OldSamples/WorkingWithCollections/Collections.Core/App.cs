using Cirrious.CrossCore;
using Cirrious.MvvmCross.ViewModels;
using Collections.Core.ViewModels;

namespace Collections.Core
{
    public class App
        : MvxApplication
    {
        public override void Initialize()
        {
            RegisterAppStart<MainMenuViewModel>();
        }
    }
}