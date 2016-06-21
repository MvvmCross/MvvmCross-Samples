using System.Windows;
using XPlatformMenus.Core.ViewModels;

namespace XPlatformMenus.WPF.Views
{
    /// <summary>
    /// Interaction logic for MainView.xaml
    /// </summary>
    public partial class MainView : BaseView
    {
        public new MainViewModel ViewModel
        {
            get { return (MainViewModel)base.ViewModel; }
            set { base.ViewModel = value; }
        }

        public MainView()
        {
            InitializeComponent();
        }

        private void MainView_Loaded(object sender, RoutedEventArgs e)
        {
            ViewModel.ShowMenu();
        }

        public void PopToRoot()
        {
            var frame = PageContent;
            while (frame.CanGoBack)
            {
                frame.GoBack();
            }
        }

        private void TogglePaneButton_Unchecked(object sender, RoutedEventArgs e)
        {

        }

        private void TogglePaneButton_Checked(object sender, RoutedEventArgs e)
        {

        }


    }
}
