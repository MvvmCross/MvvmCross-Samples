using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using DailyDilbert.Core.ViewModels;
using Windows.Foundation;
using Windows.Foundation.Collections;
using Windows.UI.Xaml;
using Windows.UI.Xaml.Controls;
using Windows.UI.Xaml.Controls.Primitives;
using Windows.UI.Xaml.Data;
using Windows.UI.Xaml.Input;
using Windows.UI.Xaml.Media;
using Windows.UI.Xaml.Navigation;

// The Items Page item template is documented at http://go.microsoft.com/fwlink/?LinkId=234233

namespace DailyDilbert.Store.Views
{
    /// <summary>
    /// A page that displays a collection of item previews.  In the Split Application this page
    /// is used to display and select one of the available groups.
    /// </summary>
    public sealed partial class ListView : DailyDilbert.Store.Common.LayoutAwarePage
    {
        public ListView()
        {
            this.InitializeComponent();
        }

        private void ItemGridView_OnItemClick(object sender, ItemClickEventArgs e)
        {
            // ideally this would be done using a behavior...
            ((ListViewModel)ViewModel).ItemSelectedCommand.Execute(e.ClickedItem);
        }
    }
}
