using System.Reflection;
using Android.Content;
using Cirrious.CrossCore.Droid;

namespace CrossLight.Framework
{
    public class AndroidGlobals
        : IMvxAndroidGlobals
    {
        private readonly Context _applicationContext;

        public AndroidGlobals(Context applicationContext)
        {
            _applicationContext = applicationContext;
        }

        public virtual string ExecutableNamespace
        {
            get { return "CrossLight"; }
        }

        public virtual Assembly ExecutableAssembly
        {
            get { return GetType().Assembly; }
        }

        public Context ApplicationContext
        {
            get { return _applicationContext; }
        }
    }
}