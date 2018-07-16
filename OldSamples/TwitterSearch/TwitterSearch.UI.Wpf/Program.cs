using System;

namespace TwitterSearch.UI.Wpf
{
    public class Program
    {
        [STAThread]
        public static void Main()
        {
            var app = new App();
            // if Call InitializeComponent to ensure any App.Xaml resources are loaded
            //app.InitializeComponent();
            var ourWindow = new MainWindow();
            var presenter = new MultiRegionPresenter(ourWindow);
            var setup = new Setup();
            setup.PlatformInitialize(app.Dispatcher, presenter);
            setup.InitializePrimary();
            setup.InitializeSecondary();
            app.MainWindow.Show();
            app.Run();
        }
    }
}