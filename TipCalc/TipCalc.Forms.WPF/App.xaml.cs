using MvvmCross.Core;
using MvvmCross.Forms.Platforms.Wpf.Core;
using TipCalc.Forms.UI;

namespace TipCalc.Forms.WPF
{
    /// <summary>
    /// Interaction logic for App.xaml
    /// </summary>
    public partial class App
    {
        protected override void RegisterSetup()
        {
            this.RegisterSetupType<MvxFormsWpfSetup<App, FormsApp>>();
        }
    }
}