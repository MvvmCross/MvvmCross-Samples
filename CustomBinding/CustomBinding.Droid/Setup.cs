using Android.Content;
using CustomBinding.Droid.Controls;
using MvvmCross.Binding.Bindings.Target.Construction;
using MvvmCross.Core.ViewModels;
using MvvmCross.Droid.Platform;

namespace CustomBinding.Droid
{
    public class Setup : MvxAndroidSetup
    {
        public Setup(Context applicationContext) : base(applicationContext)
        {
        }

        protected override IMvxApplication CreateApp()
        {
            return new Core.App();
        }

        protected override void FillTargetFactories(IMvxTargetBindingFactoryRegistry registry)
        {
            registry.RegisterFactory(
                new MvxSimplePropertyInfoTargetBindingFactory(
                    typeof(MyViewSpecialBinding),
                    typeof(MyView),
                    "SpecialProperty"));

            registry.RegisterFactory(
                new MvxCustomBindingFactory<AnotherView>(
                    "HitThis",
                    view => new AnotherViewHitBinding(view)));

            base.FillTargetFactories(registry);
        }

        protected override System.Collections.Generic.IDictionary<string, string> ViewNamespaceAbbreviations
        {
            get
            {
                var toReturn = base.ViewNamespaceAbbreviations;
                toReturn["CB"] = "CustomBinding.Droid.Controls";
                return toReturn;
            }
        }
    }
}