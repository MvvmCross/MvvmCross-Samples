using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Navigation;
using System.Windows.Shapes;
using XPlatformMenus.Core.ViewModels;

namespace XPlatformMenus.WPF.Views
{
    /// <summary>
    /// Interaction logic for HelpView.xaml
    /// </summary>
    public partial class HelpView : BaseView
    {
        public new HelpAndFeedbackViewModel ViewModel
        {
            get { return (HelpAndFeedbackViewModel)base.ViewModel; }
            set { base.ViewModel = value; }
        }

        public HelpView()
        {
            InitializeComponent();
        }
    }
}
