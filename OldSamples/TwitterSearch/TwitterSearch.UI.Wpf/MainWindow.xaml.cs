using MvvmCross.Platforms.Wpf.Presenters.Attributes;
using MvvmCross.Platforms.Wpf.Views;
using System.Windows;

namespace TwitterSearch.UI.Wpf
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : MvxWindow
    {
        public MainWindow()
        {
            InitializeComponent();
        }

        public void PresentInRegion(FrameworkElement frameworkElement, MvxContentPresentationAttribute attribute)
        {
            switch (attribute.WindowIdentifier)
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