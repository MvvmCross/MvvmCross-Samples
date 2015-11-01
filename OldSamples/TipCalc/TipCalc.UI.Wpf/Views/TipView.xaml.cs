using Cirrious.MvvmCross.Wpf.Views;
using TipCalc.Core.ViewModels;

namespace TipCalc.UI.Wpf.Views
{
    public partial class TipView : MvxWpfView
    {
        public new TipViewModel ViewModel
        {
            get { return (TipViewModel)base.ViewModel; }
            set { base.ViewModel = value; }
        }

        public TipView()
        {
            InitializeComponent();
        }
    }
}