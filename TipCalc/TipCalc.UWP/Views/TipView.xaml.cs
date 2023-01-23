using MvvmCross.Platforms.WinUi.Views;
using MvvmCross.ViewModels;
using TipCalc.Core.ViewModels;

namespace TipCalc.WinUI3.Views
{
    [MvxViewFor(typeof(TipViewModel))]
    public sealed partial class TipView : MvxWindowsPage
    {
        public TipView()
        {
            InitializeComponent();
        }
    }
}
