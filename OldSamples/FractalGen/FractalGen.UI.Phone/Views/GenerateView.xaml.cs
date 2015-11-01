using System;
using System.ComponentModel;
using System.Windows.Navigation;
using Cirrious.MvvmCross.WindowsPhone.Views;
using FractalGen.Core.ViewModels;
using Microsoft.Phone.Shell;

namespace FractalGen.UI.Phone.Views
{
    // NOTE - the non-bindable app bar here is easy to workaround - but not done here in order to 
    //       minimise code dependencies
    public partial class GenerateView : MvxPhonePage
    {
        private bool _initialized;

        public GenerateView()
        {
            InitializeComponent();
        }

        private GenerateViewModel GenerateViewModel
        {
            get { return ((GenerateViewModel) ViewModel); }
        }

        protected override void OnNavigatedTo(NavigationEventArgs e)
        {
            base.OnNavigatedTo(e);
            if (!_initialized)
            {
                GenerateViewModel.PropertyChanged += OnPropertyChanged;
                _initialized = true;
                // fire off a new fractal request
                GenerateViewModel.RestartCommand.Execute(null);
            }
            UpdateAppBar();
        }

        private void OnPropertyChanged(object sender, PropertyChangedEventArgs propertyChangedEventArgs)
        {
            if (propertyChangedEventArgs.PropertyName == "AutoPlay")
                UpdateAppBar();
        }

        private void UpdateAppBar()
        {
            ((ApplicationBarIconButton) ApplicationBar.Buttons[1]).IconUri
                = GenerateViewModel.AutoPlay
                      ? new Uri("/Assets/appbar.timer.off.png", UriKind.Relative)
                      : new Uri("/Assets/appbar.timer.png", UriKind.Relative);
        }

        private void RefreshButton_OnClick(object sender, EventArgs e)
        {
            GenerateViewModel.RestartCommand.Execute(null);
        }

        private void RestartButton_OnClick(object sender, EventArgs e)
        {
            GenerateViewModel.AutoPlay = !GenerateViewModel.AutoPlay;
        }
    }
}