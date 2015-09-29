using System;
using System.Reflection;
using Cirrious.MvvmCross.Binding;
using Cirrious.MvvmCross.Binding.Bindings.Target;

namespace CustomBinding.Droid.Controls
{
    public class MyViewSpecialBinding : MvxPropertyInfoTargetBinding<MyView>
    {
        public MyViewSpecialBinding(object target, PropertyInfo targetPropertyInfo)
            : base(target, targetPropertyInfo)
        {
            var myView = View;
            myView.UnusualNameChanged += OnUnusualNameChanged;
        }

        private void OnUnusualNameChanged(object sender, EventArgs eventArgs)
        {
            FireValueChanged(View.Text);
        }

        public override MvxBindingMode DefaultMode
        {
            get { return MvxBindingMode.TwoWay; }
        }

        protected override void Dispose(bool isDisposing)
        {
            base.Dispose(isDisposing);
            if (isDisposing)
            {
                var myView = View;
                if (myView != null)
                {
                    myView.UnusualNameChanged -= OnUnusualNameChanged;
                }
            }
        }
    }
}