using System;
using Android.Content;
using Android.Util;
using Android.Views;
using Android.Widget;

namespace StarWarsSample.Droid.Controls
{
    public class InfoView : RelativeLayout
    {
        private TextView _label;
        private TextView _info;

        public InfoView(Context context, IAttributeSet attrs) : base(context, attrs)
        {
            Init(attrs);
        }

        public string Label
        {
            get => _label.Text;
            set => _label.Text = value;
        }

        public string Info
        {
            get => _info.Text;
            set => _info.Text = value;
        }

        private void Init(IAttributeSet attrs)
        {
            var inflater = LayoutInflater.From(Context);
            var layout = inflater.Inflate(Resource.Layout.control_info_view, this);

            _label = layout.FindViewById<TextView>(Resource.Id.label);
            _info = layout.FindViewById<TextView>(Resource.Id.info);
        }
    }
}
