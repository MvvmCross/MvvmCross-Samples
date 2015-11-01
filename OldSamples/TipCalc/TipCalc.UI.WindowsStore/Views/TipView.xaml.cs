using TipCalc.Core.ViewModels;

namespace TipCalc.UI.WindowsStore.Views
{
    public sealed partial class TipView : TipCalc.UI.WindowsStore.Common.LayoutAwarePage
    {
        public new TipViewModel ViewModel
        {
            get { return (TipViewModel)base.ViewModel; }
            set { base.ViewModel = value; }
        }

        public TipView()
        {
            this.InitializeComponent();
        }
    }
}
