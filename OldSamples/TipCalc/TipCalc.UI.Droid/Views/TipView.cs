using Android.App;
using Cirrious.MvvmCross.Droid.Views;
using TipCalc.Core.ViewModels;
namespace TipCalc.UI.Droid.Views
{
    [Activity(Label = "Tip", MainLauncher = true)]
    public class TipView : MvxActivity
    {
        public new TipViewModel ViewModel
        {
            get { return (TipViewModel)base.ViewModel; }
            set { base.ViewModel = value; }
        }        protected override void OnViewModelSet()
        {
            SetContentView(Resource.Layout.View_Tip);
        }
    }
}