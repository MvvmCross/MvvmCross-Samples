using Cirrious.MvvmCross.ViewModels;
using Tutorial.Core.ViewModels;

namespace Tutorial.Core
{
    public class App
        : MvxApplication
    {
        public App()
        {
            RegisterAppStart<MainMenuViewModel>();
        }
    }
}