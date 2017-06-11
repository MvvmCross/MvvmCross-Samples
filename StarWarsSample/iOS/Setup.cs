using MvvmCross.Binding.Bindings.Target.Construction;
using MvvmCross.Core.ViewModels;
using MvvmCross.iOS.Platform;
using MvvmCross.iOS.Views.Presenters;
using MvvmCross.Platform;
using StarWarsSample.iOS.MvxBindings;
using SwarWarsSample;
using UIKit;

namespace StarWarsSample.iOS
{
    public class Setup : MvxIosSetup
    {
        public Setup(MvxApplicationDelegate applicationDelegate, UIWindow window)
            : base(applicationDelegate, window)
        {
        }

        public Setup(MvxApplicationDelegate applicationDelegate, IMvxIosViewPresenter presenter)
            : base(applicationDelegate, presenter)
        {
        }

        protected override IMvxApplication CreateApp()
        {
            return new App();
        }

        public override void InitializePrimary()
        {
            base.InitializePrimary();
        }

        protected override void InitializeLastChance()
        {
            base.InitializeLastChance();

            var registry = Mvx.Resolve<IMvxTargetBindingFactoryRegistry>();
            registry.RegisterFactory(new MvxCustomBindingFactory<UIViewController>("NetworkIndicator", (viewController) => new NetworkIndicatorTargetBinding(viewController)));
        }
    }
}
