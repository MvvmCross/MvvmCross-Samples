using Tutorial.Core.ViewModels.Lessons;
using Tutorial.UI.WinRT.Common;

// The Basic Page item template is documented at http://go.microsoft.com/fwlink/?LinkId=234237

namespace Tutorial.UI.WinRT.Views.Lessons
{
    public abstract class BaseTipView
        : LayoutAwarePage
    {
        public new TipViewModel ViewModel
        {
            get { return (TipViewModel)base.ViewModel; }
            set { base.ViewModel = value; }
        }
    }

    /// <summary>
    /// A basic page that provides characteristics common to most applications.
    /// </summary>
    public sealed partial class TipView : BaseTipView
    {
        public TipView()
        {
            this.InitializeComponent();
        }
    }
}