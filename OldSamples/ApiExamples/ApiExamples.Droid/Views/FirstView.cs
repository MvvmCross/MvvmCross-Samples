using Android.App;
using Android.OS;
using Cirrious.CrossCore.Converters;
using Cirrious.MvvmCross.Droid.Views;

namespace ApiExamples.Droid.Views
{
    [Activity(Label = "Api examples")]
    public class FirstView : MvxActivity
    {
        protected override void OnCreate(Bundle bundle)
        {
            base.OnCreate(bundle);
            SetContentView(Resource.Layout.FirstView);
        }
    }

    [Activity(NoHistory = true)]
    public class DateTimeView : MvxActivity
    {
        protected override void OnCreate(Bundle bundle)
           {
            base.OnCreate(bundle);
            SetContentView(Resource.Layout.Test_Date);
        }
    }

    [Activity(NoHistory = true)]
    public class TimeView : MvxActivity
    {
        protected override void OnCreate(Bundle bundle)
        {
            base.OnCreate(bundle);
            SetContentView(Resource.Layout.Test_Time);
        }
    }

    [Activity(NoHistory = true)]
    public class SpinnerView : MvxActivity
    {
        protected override void OnCreate(Bundle bundle)
        {
            base.OnCreate(bundle);
            SetContentView(Resource.Layout.Test_Spinner);
        }
    }

    [Activity(NoHistory = true)]
    public class ListView : MvxActivity
    {
        protected override void OnCreate(Bundle bundle)
        {
            base.OnCreate(bundle);
            SetContentView(Resource.Layout.Test_List);
        }
    }

    [Activity(NoHistory = true)]
    public class LinearLayoutView : MvxActivity
    {
        protected override void OnCreate(Bundle bundle)
        {
            base.OnCreate(bundle);
            SetContentView(Resource.Layout.Test_LinearLayout);
        }
    }

    [Activity(NoHistory = true)]
    public class FrameView : MvxActivity
    {
        protected override void OnCreate(Bundle bundle)
        {
            base.OnCreate(bundle);
            SetContentView(Resource.Layout.Test_Frame);
        }
    }

    [Activity(NoHistory = true)]
    public class RelativeView : MvxActivity
    {
        protected override void OnCreate(Bundle bundle)
        {
            base.OnCreate(bundle);
            SetContentView(Resource.Layout.Test_Relative);
        }
    }

    [Activity(NoHistory = true)]
    public class TextView : MvxActivity
    {
        protected override void OnCreate(Bundle bundle)
        {
            base.OnCreate(bundle);
            SetContentView(Resource.Layout.Test_Text);
        }
    }

    [Activity(NoHistory = true)]
    public class SeekView : MvxActivity
    {
        protected override void OnCreate(Bundle bundle)
        {
            base.OnCreate(bundle);
            SetContentView(Resource.Layout.Test_Seek);
        }
    }

    [Activity(NoHistory = true)]
    public class ContainsSubView : MvxActivity
    {
        protected override void OnCreate(Bundle bundle)
        {
            base.OnCreate(bundle);
            SetContentView(Resource.Layout.Test_ContainsSub);
        }
    }

    [Activity(NoHistory = true)]
    public class ConvertThisView : MvxActivity
    {
        protected override void OnCreate(Bundle bundle)
        {
            base.OnCreate(bundle);
            SetContentView(Resource.Layout.Test_ConvertThis);
        }
    }

    [Activity(NoHistory = true)]
    public class ObservableCollectionView : MvxActivity
    {
        protected override void OnCreate(Bundle bundle)
        {
            base.OnCreate(bundle);
            SetContentView(Resource.Layout.Test_ObservableCollection);
        }
    }

    [Activity(NoHistory = true)]
    public class ObservableDictionaryView : MvxActivity
    {
        protected override void OnCreate(Bundle bundle)
        {
            base.OnCreate(bundle);
            SetContentView(Resource.Layout.Test_ObservableDictionary);
        }
    }

    [Activity(NoHistory = true)]
    public class WithErrorsView : MvxActivity
    {
        protected override void OnCreate(Bundle bundle)
        {
            base.OnCreate(bundle);
            SetContentView(Resource.Layout.Test_WithErrors);
        }
    }

    [Activity(NoHistory = true)]
    public class IfView : MvxActivity
    {
        protected override void OnCreate(Bundle bundle)
        {
            base.OnCreate(bundle);
            SetContentView(Resource.Layout.Test_If);
        }
    }

    [Activity(NoHistory = true)]
    public class MathsView : MvxActivity
    {
        protected override void OnCreate(Bundle bundle)
        {
            base.OnCreate(bundle);
            SetContentView(Resource.Layout.Test_Maths);
        }
    }

    [Activity(NoHistory = true)]
    public class RadioGroupView : MvxActivity
    {
        protected override void OnCreate(Bundle bundle)
        {
            base.OnCreate(bundle);
            SetContentView(Resource.Layout.Test_RadioGroup);
        }
    }

    public class ErrorExistsValueConverter : MvxValueConverter
    {
        public override object Convert(object value, System.Type targetType, object parameter, System.Globalization.CultureInfo culture)
        {
            return (value != null);
        }
    }

    [Activity(NoHistory = true)]
    public class RatingBarView : MvxActivity
    {
        protected override void OnCreate(Bundle bundle)
        {
            base.OnCreate(bundle);
            SetContentView(Resource.Layout.Test_RatingBar);
        }
    }

    [Activity(NoHistory = true)]
    public class CommandView : MvxActivity
    {
        protected override void OnCreate(Bundle bundle)
        {
            base.OnCreate(bundle);
            SetContentView(Resource.Layout.Test_Command);
        }
    }
}