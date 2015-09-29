using Cirrious.MvvmCross.ViewModels;
using System.Windows.Input;

namespace Cirrious.Conference.Core.ViewModels
{
    public class AboutViewModel
        : BaseConferenceViewModel
    {
        public ICommand ContactSlodgeCommand
        {
            get
            {
                return
                    new MvxCommand(
                        () =>
                        ComposeEmail("me@slodge.com", "About MvvmCross and the SQL Bits app", "I've got a question"));
            }
        }

        public ICommand MvvmCrossOnGithubCommand
        {
            get
            {
                return
                    new MvxCommand(
                        () =>
                        ShowWebPage("http://github.com/slodge/mvvmcross"));
            }
        }

        public ICommand ShowSqlBitsCommand
        {
            get
            {
                return
                    new MvxCommand(
                        () =>
                        ShowWebPage("http://sqlbits.com"));
            }
        }

        public ICommand MonoTouchCommand
        {
            get
            {
                return
                    new MvxCommand(
                        () =>
                        ShowWebPage("http://ios.xamarin.com"));
            }
        }

        public ICommand MonoDroidCommand
        {
            get
            {
                return
                    new MvxCommand(
                        () =>
                        ShowWebPage("http://android.xamarin.com"));
            }
        }
    }
}