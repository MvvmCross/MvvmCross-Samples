using ValueConversion.Core.ViewModels;
using MvvmCross.Core.ViewModels;

namespace ValueConversion.Core
{
    public class App : MvxApplication
    {
        public override void Initialize()
        {
            RegisterAppStart<HomeViewModel>();
        }
    }
}