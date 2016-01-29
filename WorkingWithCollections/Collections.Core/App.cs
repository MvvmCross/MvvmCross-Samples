using Collections.Core.ViewModels;
using MvvmCross.Core.ViewModels;

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