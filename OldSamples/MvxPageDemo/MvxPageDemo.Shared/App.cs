using Cirrious.MvvmCross.ViewModels;
using MvxPageDemo.ViewModels;

namespace MvxPageDemo.Shared
{
    public class App : MvxApplication
    {
        public App()
        {
        }

        public override void Initialize()
        {
            base.Initialize();
            //Start
            RegisterAppStart<StartViewModel>();
        }
    }
}