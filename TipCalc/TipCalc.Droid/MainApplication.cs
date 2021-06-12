using System;
using Android.App;
using Android.Runtime;
using MvvmCross.Platforms.Android.Views;
using TipCalc.Core;

namespace TipCalc.UI.Droid
{
    [Application]
    public class MainApplication : MvxAndroidApplication<Setup, App>
    {
        public MainApplication(IntPtr javaReference, JniHandleOwnership transfer)
            : base(javaReference, transfer)
        {
        }
    }
}
