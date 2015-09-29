using System;
using Android.App;
using Cirrious.CrossCore.Core;

namespace Mvvm.Framework
{
    public class AndroidTopActivity
        : ITopActivity
        , IMvxMainThreadDispatcher
    {
        public Activity Activity { get; set; }

        public IMvxMainThreadDispatcher Dispatcher
        {
            get { return this; }
        }

        public bool RequestMainThreadAction(Action action)
        {
            var activity = Activity;
            if (activity == null)
                return false;

            activity.RunOnUiThread(action);
            return true;
        }
    }
}