using MvvmCross.Platforms.Uap.Views;

namespace TipCalc.UWP
{
    public sealed partial class App
    {
        public App()
        {
            InitializeComponent();
        }
    }

    public abstract class TipCalcApp : MvxApplication<Setup, Core.App>
    {
    }
}