using MvvmCross.Localization;
using MvvmCross.ViewModels;

namespace Babel.Core.ViewModels
{
    public abstract class BaseViewModel : MvxViewModel
    {
        public IMvxLanguageBinder TextSource
        {
            get { return new MvxLanguageBinder(Constants.GeneralNamespace, GetType().Name); }
        }
    }
}
