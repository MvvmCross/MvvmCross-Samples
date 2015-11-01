using Android.App;
using Cirrious.MvvmCross.Binding.BindingContext;
using Cirrious.MvvmCross.Dialog.Droid.Views;
using CrossUI.Droid.Dialog.Elements;

namespace ValueConversion.UI.Droid.Views
{
    /*
    [Activity]
    public class DatesView : MvxActivity
    {
        protected override void OnViewModelSet()
        {
            SetContentView(Resource.Layout.View_Dates);
        }
    }
     */
    [Activity]
    public class DatesView : MvxDialogActivity
    {
        protected override void OnViewModelSet()
        {
            this.Root = new RootElement("Experiment")
                {
                    new Section("Now")
                        {
                            new StringElement("Today").Bind(this, "Value TheDate"),
                            new StringElement("Today Ago").Bind(this, "Value TheDate, Converter=TimeAgo"),
                        },
                    new Section("Before")
                        {
                            new StringElement("Old").Bind(this, "Value OldDate"),
                            new StringElement("Old Ago").Bind(this, "Value OldDate, Converter=TimeAgo"),
                            new StringElement("V Old").Bind(this, "Value VeryOldDate"),
                            new StringElement("V Old Ago").Bind(this, "Value VeryOldDate, Converter=TimeAgo"),
                        },
                };
        }
    }
}