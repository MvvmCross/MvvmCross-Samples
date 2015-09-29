using System;
using System.Windows.Input;
using Cirrious.MvvmCross.Plugins.Messenger;
using Cirrious.MvvmCross.ViewModels;
using FractalGen.Core.Messages;
using FractalGen.Core.Services.Fractal;
using FractalGen.Core.Services.PlatformSpecific;

namespace FractalGen.Core.ViewModels
{
    public class GenerateViewModel : MvxViewModel
    {
        private static readonly TimeSpan AutoPlayTimeout = TimeSpan.FromSeconds(5.0);

        private readonly IDisplayDimensionsService _displayDimensionsService;
        private readonly IMandelbrotTaskGenerator _mandelbrotTaskGenerator;
        private readonly MvxSubscriptionToken _mvxSubscriptionToken;
        private bool _autoPlay;
        private ISimpleWriteableBitmap _bitmap;

        private IMandelbrotTask _currentTask;
        private DateTime _whenLastActiveUtc = DateTime.MinValue;

        public GenerateViewModel(IMvxMessenger messenger, IDisplayDimensionsService displayDimensionsService,
                                 IMandelbrotTaskGenerator mandelbrotTaskGenerator)
        {
            _displayDimensionsService = displayDimensionsService;
            _mandelbrotTaskGenerator = mandelbrotTaskGenerator;
            _mvxSubscriptionToken = messenger.SubscribeOnMainThread<TickMessage>(OnTick);
            _autoPlay = true;
        }

        public ISimpleWriteableBitmap Bitmap
        {
            get { return _bitmap; }
            set
            {
                _bitmap = value;
                RaisePropertyChanged(() => Bitmap);
            }
        }

        public bool AutoPlay
        {
            get { return _autoPlay; }
            set
            {
                _autoPlay = value;
                RaisePropertyChanged(() => AutoPlay);
            }
        }

        public ICommand RestartCommand
        {
            get { return new MvxCommand(DoRestart); }
        }

        private void DoRestart()
        {
            if (_currentTask != null)
            {
                _currentTask.Cancel();
            }

            _currentTask = _mandelbrotTaskGenerator.Generate(_displayDimensionsService.Width,
                                                             _displayDimensionsService.Height,
                                                             (bitmap) => Bitmap = bitmap);
            _currentTask.ProcessAsync();
        }

        private void OnTick(TickMessage obj)
        {
            if (_currentTask != null
                && !_currentTask.Mandelbrot.IsScaleComplete)
            {
                _whenLastActiveUtc = DateTime.UtcNow;
                _currentTask.RequestCopy();
            }

            if (AutoPlay)
            {
                if (DateTime.UtcNow - _whenLastActiveUtc > AutoPlayTimeout)
                    DoRestart();
            }
        }
    }
}