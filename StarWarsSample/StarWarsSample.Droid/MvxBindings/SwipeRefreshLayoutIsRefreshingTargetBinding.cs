using System;
using System.ComponentModel;
using Android.Support.V4.Widget;
using MvvmCross.Binding;
using MvvmCross.Binding.Droid.Target;
using MvvmCross.Platform.Platform;
using MvvmCross.Platform.WeakSubscription;
using Nito.AsyncEx;

namespace StarWarsSample.Droid.MvxBindings
{
    public class SwipeRefreshLayoutIsRefreshingTargetBinding : MvxAndroidTargetBinding
    {
        protected SwipeRefreshLayout SwipeRefreshLayout => (SwipeRefreshLayout)this.Target;

        public SwipeRefreshLayoutIsRefreshingTargetBinding(SwipeRefreshLayout swipeRefreshLayout)
            : base(swipeRefreshLayout)
        {
        }

        public override MvxBindingMode DefaultMode => MvxBindingMode.OneWay;

        public override Type TargetType => typeof(INotifyTaskCompletion);

        protected override void SetValueImpl(object target, object value)
        {
            if (!(value is INotifyTaskCompletion))
            {
                MvxBindingTrace.Trace(MvxTraceLevel.Warning,
                    "Value '{0}' could not be parsed as a valid INotifyTaskCompletion", value);
                return;
            }

            var taskCompletion = (INotifyTaskCompletion)value;
            taskCompletion.WeakSubscribe(HandlePropertyChanged);

            SwipeRefreshLayout.Post(() => SwipeRefreshLayout.Refreshing = taskCompletion.IsNotCompleted);
        }

        private void HandlePropertyChanged(object sender, PropertyChangedEventArgs e)
        {
            if (e.PropertyName == nameof(INotifyTaskCompletion.IsNotCompleted))
            {
                SwipeRefreshLayout.Post(() => SwipeRefreshLayout.Refreshing = ((INotifyTaskCompletion)sender).IsNotCompleted);
            }
        }
    }
}
