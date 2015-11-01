using Cirrious.MvvmCross.Localization;

namespace Babel.Touch
{
    public class Setup : MvxTouchSetup
    {
        public Setup(MvxApplicationDelegate applicationDelegate, UIWindow window)
            : base(applicationDelegate, window)
        {
        }

        protected override System.Collections.Generic.List<System.Reflection.Assembly> ValueConverterAssemblies
        {
            get
            {
                var toReturn = base.ValueConverterAssemblies;
                toReturn.Add(typeof(MvxLanguageConverter).Assembly);
                return toReturn;
            }
        }

        protected override Cirrious.MvvmCross.ViewModels.IMvxApplication CreateApp()
        {
            return new Core.App();
        }
    }
}