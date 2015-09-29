using Android.App;
using Cirrious.CrossCore.Droid.Platform;

namespace NoBinding.Framework
{
    public interface ITopActivity
        : IMvxAndroidCurrentTopActivity
    {
        new Activity Activity { get; set; }        
    }
}