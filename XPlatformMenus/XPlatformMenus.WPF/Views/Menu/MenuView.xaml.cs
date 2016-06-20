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
    /// Interaction logic for MenuView.xaml
    /// </summary>
    public partial class MenuView : BaseView
    {
        public new MenuViewModel ViewModel
        {
            get { return (MenuViewModel)base.ViewModel; }
            set { base.ViewModel = value; }
        }

        public MenuView()
        {
            InitializeComponent();
        }
    }
}
