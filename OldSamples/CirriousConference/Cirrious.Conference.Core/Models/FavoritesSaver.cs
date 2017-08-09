using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using MvvmCross.Platform.Platform;
using MvvmCross.Platform;
using MvvmCross.Platform.Exceptions;
using MvvmCross.Plugins.File;

namespace Cirrious.Conference.Core.Models
{
    public class FavoritesSaver
    {
        private List<string> _toSave;

        public void RequestAsyncSave(List<string> toSave)
        {
            lock (this)
            {
                var wasNull = _toSave == null;
                _toSave = toSave;
                if (wasNull)
                    Task.Factory.StartNew(() => DoSave());
            }
        }

        private void DoSave()
        {
            try
            {
                List<string> toSave;
                lock (this)
                {
                    toSave = _toSave;
                    _toSave = null;
                }

                if (toSave == null)
                    return; // nothing to do

                var jsonConvert = Mvx.Resolve<IMvxJsonConverter>();
                var json = jsonConvert.SerializeObject(toSave);
                var fileService = Mvx.Resolve<IMvxFileStore>();
                fileService.WriteFile(Constants.FavoritesFileName, json);
            }
            catch (Exception exception)
            {
                Trace.Error("Failed to save favorites: {0}", exception.ToLongString());
            }
        }
    }
}