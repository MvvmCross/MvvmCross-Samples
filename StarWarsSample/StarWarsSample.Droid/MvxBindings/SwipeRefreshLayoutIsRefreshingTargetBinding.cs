﻿using System;
using System.ComponentModel;
using AndroidX.SwipeRefreshLayout.Widget;
using Microsoft.Extensions.Logging;
using MvvmCross.Binding;
using MvvmCross.Logging;
using MvvmCross.Platforms.Android.Binding.Target;
using MvvmCross.ViewModels;
using MvvmCross.WeakSubscription;
using StarWarsSample.Core;

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
                Logs.Instance.Log(LogLevel.Trace, "Value '"+value+"' could not be parsed as a valid INotifyTaskCompletion");
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