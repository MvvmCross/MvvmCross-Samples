using Cirrious.MvvmCross.ViewModels;
using ValueConversion.Core.ViewModels;

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