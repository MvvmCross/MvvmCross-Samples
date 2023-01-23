using MvvmCross.Platforms.WinUi.Views;

namespace TipCalc.WinUI3
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