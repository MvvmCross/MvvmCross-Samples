using Windows.UI.ViewManagement;

namespace StarWarsSample.Forms.UWP
{    
    public sealed partial class MainPage
    {
        public MainPage()
        {
            InitializeComponent();

            var titleBar = ApplicationView.GetForCurrentView().TitleBar;

            titleBar.ForegroundColor = Windows.UI.Colors.White;
            titleBar.BackgroundColor = Windows.UI.Colors.Black;
            titleBar.ButtonForegroundColor = Windows.UI.Colors.White;
            titleBar.ButtonBackgroundColor = Windows.UI.Colors.Black;
            titleBar.ButtonHoverBackgroundColor = Windows.UI.Colors.Red;
            titleBar.ButtonHoverForegroundColor = Windows.UI.Colors.White;
        }
    }
}