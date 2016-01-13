using System;
using System.Diagnostics;
using System.Runtime.CompilerServices;
using MvvmCross.Platform.Platform;
using MvvmCross.Platform;

namespace XPlatformMenus.Touch
{
    public class DebugTrace : IMvxTrace
    {
        public void Trace(MvxTraceLevel level, string tag, Func<string> message)
        {
            Debug.WriteLine(tag + ":" + level + ":" + message());
        }

        public void Trace(MvxTraceLevel level, string tag, string message)
        {
            Debug.WriteLine(tag + ":" + level + ":" + message);
        }

        public void Trace(MvxTraceLevel level, string tag, string message, params object[] args)
        {
            try
            {
                Debug.WriteLine(string.Format(tag + ":" + level + ":" + message, args));
            }
            catch (FormatException)
            {
                Trace(MvxTraceLevel.Error, tag, "Exception during trace of {0} {1}", level, message);
            }
        }
    }

    public static class Trc
    {
        public static void Mn(string message = "", [CallerMemberName] string callerName = "")
        {
            Mvx.Trace(string.Format("[{0}] - {1}", callerName, message));
        }
    } 
}
