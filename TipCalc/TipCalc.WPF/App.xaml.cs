using MvvmCross.Core;
using MvvmCross.Platforms.Wpf.Views;

namespace TipCalc.WPF
{
    public partial class App : MvxApplication
    {
        protected override void RegisterSetup()
        {
            this.RegisterSetupType<Setup>();
        }
    }
}
