using Cirrious.MvvmCross.WindowsCommon.Views;
using TipCalc.Core.ViewModels;
using TipCalc.UI.WindowsCommon.Common;
using Windows.UI.Xaml.Navigation;

namespace TipCalc.UI.WindowsCommon.Views
{
    public sealed partial class TipView : MvxWindowsPage
    {
        public new TipViewModel ViewModel
        {
            get { return (TipViewModel)base.ViewModel; }
            set { base.ViewModel = value; }
        }
        
        private NavigationHelper navigationHelper;
        private ObservableDictionary defaultViewModel = new ObservableDictionary();

        public TipView()
        {
            this.InitializeComponent();

            this.navigationHelper = new NavigationHelper(this);
        }

        public NavigationHelper NavigationHelper
        {
            get { return this.navigationHelper; }
        }

        public ObservableDictionary DefaultViewModel
        {
            get { return this.defaultViewModel; }
        }

        protected override void OnNavigatedTo(NavigationEventArgs e)
        {
            base.OnNavigatedTo(e);
            this.navigationHelper.OnNavigatedTo(e);
        }

        protected override void OnNavigatedFrom(NavigationEventArgs e)
        {
            base.OnNavigatedFrom(e);
            this.navigationHelper.OnNavigatedFrom(e);
        }
    }
}
