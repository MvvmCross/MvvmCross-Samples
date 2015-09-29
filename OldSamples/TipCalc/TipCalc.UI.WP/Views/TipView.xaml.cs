using Cirrious.MvvmCross.WindowsPhone.Views;
using TipCalc.Core.ViewModels;

namespace TipCalc.UI.WP.Views
{
    public partial class TipView : MvxPhonePage
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