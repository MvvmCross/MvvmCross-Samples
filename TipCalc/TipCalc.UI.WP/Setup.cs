using Microsoft.Phone.Controls;
using MvvmCross.Core.ViewModels;
using MvvmCross.WindowsPhone.Platform;

namespace TipCalc.UI.WP
{
    public class Setup : MvxPhoneSetup
    {
        public Setup(PhoneApplicationFrame rootFrame)
            : base(rootFrame)
        {
        }

        protected override IMvxApplication CreateApp()
        {
            return new Core.App();
        }
    }
}
