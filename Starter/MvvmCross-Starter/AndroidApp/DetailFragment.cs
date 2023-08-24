using Android.Runtime;
using Android.Views;
using AndroidX.Activity;
using Core.ViewModels;
using MvvmCross.Platforms.Android.Binding.BindingContext;
using MvvmCross.Platforms.Android.Presenters.Attributes;
using MvvmCross.Platforms.Android.Views.Fragments;

namespace AndroidApp;

[MvxFragmentPresentation(FragmentContentId = Resource.Id.fragment_container)]
[Register("starter.DetailFragment")]
public class DetailFragment : MvxFragment<DetailViewModel>
{
    public override View OnCreateView(LayoutInflater inflater, ViewGroup? container, Bundle? savedInstanceState)
    {
        base.OnCreateView(inflater, container, savedInstanceState);
        return this.BindingInflate(Resource.Layout.fragment_detail, container, false);
    }

    public override void OnCreate(Bundle savedInstanceState)
    {
        base.OnCreate(savedInstanceState);

        RequireActivity().OnBackPressedDispatcher
            .AddCallback(this, new OnBackPressed(() => ViewModel?.CloseCommand.Execute()));
    }

    private sealed class OnBackPressed : OnBackPressedCallback
    {
        private readonly Action _onBackPressed;

        public OnBackPressed(Action onBackPressed) : base(true) => _onBackPressed = onBackPressed;

        public override void HandleOnBackPressed() => _onBackPressed();
    }
}