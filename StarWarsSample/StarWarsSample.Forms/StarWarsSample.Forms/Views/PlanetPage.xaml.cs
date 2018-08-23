using System.Threading.Tasks;
using MvvmCross.Base;
using MvvmCross.Binding.BindingContext;
using MvvmCross.Forms.Presenters.Attributes;
using MvvmCross.Forms.Views;
using MvvmCross.ViewModels;
using StarWarsSample.Core.MvxInteraction;
using StarWarsSample.Core.ViewModels;
using Xamarin.Forms;

namespace StarWarsSample.Forms.UI.Views
{
    [MvxMasterDetailPagePresentation(MasterDetailPosition.Detail)]
    public partial class PlanetPage : MvxContentPage<PlanetViewModel>
    {
        private bool _showing = false;

        private IMvxInteraction<DestructionAction> _interaction;
        public IMvxInteraction<DestructionAction> Interaction
        {
            get => _interaction;
            set
            {
                if (_interaction != null)
                    _interaction.Requested -= OnInteractionRequested;

                _interaction = value;
                _interaction.Requested += OnInteractionRequested;
            }
        }

        public PlanetPage()
        {
            InitializeComponent();
        }

        protected override void OnViewModelSet()
        {
            base.OnViewModelSet();

            var set = this.CreateBindingSet<PlanetPage, PlanetViewModel>();
            set.Bind(this).For(v => v.Interaction).To(vm => vm.Interaction);
            set.Apply();
        }

        protected override void OnAppearing()
        {
            base.OnAppearing();

            _showing = true;

            AnimateButton();
        }

        protected override void OnDisappearing()
        {
            _showing = false;

            base.OnDisappearing();

            ViewModel.CloseCompletionSource?.TrySetResult(false);
        }

        private async Task AnimateButton()
        {
            while (_showing)
            {
                await ViewExtensions.ScaleTo(Destroy, 1.1d, 600);
                await ViewExtensions.ScaleTo(Destroy, 0.9d, 600);
            }
        }

        private void OnInteractionRequested(object sender, MvxValueEventArgs<DestructionAction> eventArgs)
        {
            animationView.IsVisible = true;
            animationView.OnFinish += (s, e) => eventArgs.Value.OnDestroyed();
            animationView.Play();
        }
    }
}