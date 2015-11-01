using System;
using Android.Graphics;
using Cirrious.MvvmCross.Binding;
using Cirrious.MvvmCross.Binding.Droid.Target;

namespace CustomBinding.Droid.Controls
{
    public class AnotherViewHitBinding
        : MvxAndroidTargetBinding
    {
        protected AnotherView AnotherView
        {
            get { return (AnotherView)Target; }
        }

        private string _currentValue;

        public AnotherViewHitBinding(AnotherView anotherView)
            : base(anotherView)
        {
            anotherView.UnusualNameChanged  += OnUnusualNameChanged;
        }

        private void OnUnusualNameChanged(object sender, EventArgs eventArgs)
        {
            var value = AnotherView.GetHitValue();
            if (value == _currentValue)
                return;
            _currentValue = value;
            FireValueChanged(value);
        }

        protected override void SetValueImpl(object target, object value)
        {
            var stringValue = (string)value;
            var anotherView = (AnotherView)target;
            
            if (anotherView == null)
            {
                // this can happen - we are using WeakReferences in the base class
                return;
            }

            if (_currentValue == stringValue)
                return;

            _currentValue = stringValue;
            anotherView.HitMe(stringValue);
            if (stringValue != null)
            {
                var color = stringValue.Length%2 == 0 ? Color.DarkBlue : Color.DarkRed;
                AnotherView.SetTextColor(color);
            }
        }

        protected override void Dispose(bool isDisposing)
        {
            if (isDisposing)
            {
                var anotherView = AnotherView;
                if (anotherView != null)
                    anotherView.UnusualNameChanged -= OnUnusualNameChanged;
            }
            base.Dispose(isDisposing);
        }

        public override Type TargetType
        {
            get { return typeof(string); }
        }

        public override MvxBindingMode DefaultMode
        {
            get { return MvxBindingMode.TwoWay; }
        }
    }
}