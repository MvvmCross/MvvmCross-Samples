using Tutorial.Core.ViewModels.Lessons;

// The Basic Page item template is documented at http://go.microsoft.com/fwlink/?LinkId=234237

namespace Tutorial.UI.WinRT.Views.Lessons
{
    /// <summary>
    /// A basic page that provides characteristics common to most applications.
    /// </summary>
    public sealed partial class CompositeView : Tutorial.UI.WinRT.Common.LayoutAwarePage
    {
        public new CompositeViewModel ViewModel { get; set; }

        public CompositeView()
        {
            this.InitializeComponent();
        }
    }
}