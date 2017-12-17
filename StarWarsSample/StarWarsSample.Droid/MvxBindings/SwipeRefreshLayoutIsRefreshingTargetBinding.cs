using System;
using System.ComponentModel;
using Android.Support.V4.Widget;
using MvvmCross.Binding;
using MvvmCross.Binding.Droid.Target;
using MvvmCross.Core.ViewModels;
using MvvmCross.Platform.Platform;
using MvvmCross.Platform.WeakSubscription;

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

        public override Type TargetType => typeof(MvxNotifyTask);

        protected override void SetValueImpl(object target, object value)
        {
            if (!(value is MvxNotifyTask))
            {
                MvxBindingTrace.Trace(MvxTraceLevel.Warning,
                    "Value '{0}' could not be parsed as a valid INotifyTaskCompletion", value);
                return;
            }

            var taskCompletion = (MvxNotifyTask)value;
            taskCompletion.WeakSubscribe(HandlePropertyChanged);

            SwipeRefreshLayout.Post(() => SwipeRefreshLayout.Refreshing = taskCompletion.IsNotCompleted);
        }

        private void HandlePropertyChanged(object sender, PropertyChangedEventArgs e)
        {
            if (e.PropertyName == nameof(MvxNotifyTask.IsNotCompleted))
            {
                SwipeRefreshLayout.Post(() => SwipeRefreshLayout.Refreshing = ((MvxNotifyTask)sender).IsNotCompleted);
            }
        }
    }
}
