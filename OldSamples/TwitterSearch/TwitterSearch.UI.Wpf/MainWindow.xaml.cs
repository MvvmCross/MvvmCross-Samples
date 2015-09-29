using System.Windows;

namespace TwitterSearch.UI.Wpf
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        public MainWindow()
        {
            InitializeComponent();
        }

        public void PresentInRegion(FrameworkElement frameworkElement, string regionName)
        {
            switch (regionName)
            {
                case "Detail":
                    RightHandColumn.Children.Clear();
                    RightHandColumn.Children.Add(frameworkElement);
                    break;

                default:
                    LeftHandColumn.Children.Clear();
                    LeftHandColumn.Children.Add(frameworkElement);
                    break;
            }
        }
    }
}