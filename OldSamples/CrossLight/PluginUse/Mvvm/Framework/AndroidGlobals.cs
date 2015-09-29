using System.Reflection;
using Android.Content;
using Cirrious.CrossCore.Droid;

namespace Mvvm.Framework
{
	public class AndroidGlobals
		: IMvxAndroidGlobals
	{
		private readonly Context _applicationContext;
		private readonly string _namespace;
		
		public AndroidGlobals(Context applicationContext, string theNamespace)
		{
			_applicationContext = applicationContext;
			_namespace = theNamespace;
		}
		
		public virtual string ExecutableNamespace
		{
			get { return _namespace; }
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