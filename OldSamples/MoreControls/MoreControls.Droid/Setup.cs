using Android.Content;
using System.Collections.Generic;
using MvvmCross.Droid.Platform;
using MvvmCross.Core.ViewModels;

namespace MoreControls.Droid
{
    public class Setup : MvxAndroidSetup
    {
        public Setup(Context applicationContext) : base(applicationContext)
        {
        }

        protected override IMvxApplication CreateApp()
        {
            return new Core.App();
        }

        protected override IDictionary<string, string> ViewNamespaceAbbreviations
        {
            get
            {
                var toReturn = base.ViewNamespaceAbbreviations;
                toReturn["MC"] = "MoreControls.Droid.Controls";
                return toReturn;
            }
        }
    }
}