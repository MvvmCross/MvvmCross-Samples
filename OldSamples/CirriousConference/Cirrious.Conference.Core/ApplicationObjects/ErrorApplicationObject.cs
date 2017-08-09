using Cirrious.Conference.Core.Interfaces;
using System;
using MvvmCross.Platform.Core;

namespace Cirrious.Conference.Core.ApplicationObjects
{
    public class ErrorApplicationObject
        : MvxMainThreadDispatchingObject
          , IErrorReporter
          , IErrorSource
    {
        public void ReportError(string error)
        {
            if (ErrorReported == null)
                return;

            InvokeOnMainThread(() =>
                                   {
                                       var handler = ErrorReported;
                                       if (handler != null)
                                           handler(this, new ErrorEventArgs(error));
                                   });
        }

        public event EventHandler<ErrorEventArgs> ErrorReported;
    }
}