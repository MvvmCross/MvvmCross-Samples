using Tutorial.Core.ViewModels.Lessons;
using Tutorial.UI.WinRT.Common;

// The Basic Page item template is documented at http://go.microsoft.com/fwlink/?LinkId=234237

namespace Tutorial.UI.WinRT.Views.Lessons
{
    /// <summary>
    /// A basic page that provides characteristics common to most applications.
    /// </summary>
    public sealed partial class SimpleTextPropertyView : LayoutAwarePage
    {
        public new SimpleTextPropertyViewModel ViewModel
        {
            get { return (SimpleTextPropertyViewModel)base.ViewModel; }
            set { base.ViewModel = value; }
        }

        public SimpleTextPropertyView()
        {
            this.InitializeComponent();
        }
    }
}