using Core.ViewModels;
using MvvmCross.Platforms.Ios.Binding;
using MvvmCross.Platforms.Ios.Presenters.Attributes;
using MvvmCross.Platforms.Ios.Views;

namespace iOSApp;

[MvxRootPresentation(WrapInNavigationController = true)]
public sealed class MainViewController : MvxViewController<MainViewModel>
{
    private UILabel? _helloLabel;
    private UITextField? _helloEdit;
    private UIButton? _clicksButton;
    private UIButton? _navigateButton;

    public override void LoadView()
    {
        base.LoadView();

        View.BackgroundColor = UIColor.White;
        Title = "Hello MvvmCross";

        _helloLabel = new UILabel
        {
            TranslatesAutoresizingMaskIntoConstraints = false,
            TextColor = UIColor.Black
        };
        
        Add(_helloLabel);

        _helloLabel.TopAnchor.ConstraintEqualTo(View.SafeAreaLayoutGuide.TopAnchor, 16).Active = true;
        _helloLabel.LeadingAnchor.ConstraintEqualTo(View.SafeAreaLayoutGuide.LeadingAnchor, 16).Active = true;
        _helloLabel.TrailingAnchor.ConstraintEqualTo(View.SafeAreaLayoutGuide.TrailingAnchor, -16).Active = true;

        _helloEdit = new UITextField
        {
            TranslatesAutoresizingMaskIntoConstraints = false,
            Placeholder = "Enter text",
            TextColor = UIColor.Black
        };
        
        Add(_helloEdit);

        _helloEdit.TopAnchor.ConstraintEqualTo(_helloLabel.BottomAnchor, 16).Active = true;
        _helloEdit.LeadingAnchor.ConstraintEqualTo(_helloLabel.LeadingAnchor).Active = true;
        _helloEdit.TrailingAnchor.ConstraintEqualTo(_helloLabel.TrailingAnchor).Active = true;

        _clicksButton = new UIButton
        {
            TranslatesAutoresizingMaskIntoConstraints = false
        };
        _clicksButton.SetTitleColor(UIColor.SystemBlue, UIControlState.Normal);
        
        Add(_clicksButton);

        _clicksButton.TopAnchor.ConstraintEqualTo(_helloEdit.BottomAnchor, 32).Active = true;
        _clicksButton.LeadingAnchor.ConstraintEqualTo(_helloEdit.LeadingAnchor).Active = true;
        _clicksButton.TrailingAnchor.ConstraintEqualTo(_helloEdit.TrailingAnchor).Active = true;
        
        _navigateButton = new UIButton
        {
            TranslatesAutoresizingMaskIntoConstraints = false
        };
        _navigateButton.SetTitleColor(UIColor.SystemBlue, UIControlState.Normal);
        
        Add(_navigateButton);

        _navigateButton.TopAnchor.ConstraintEqualTo(_clicksButton.BottomAnchor, 32).Active = true;
        _navigateButton.LeadingAnchor.ConstraintEqualTo(_helloEdit.LeadingAnchor).Active = true;
        _navigateButton.TrailingAnchor.ConstraintEqualTo(_helloEdit.TrailingAnchor).Active = true;
    }

    public override void ViewDidLoad()
    {
        base.ViewDidLoad();

        using var set = CreateBindingSet();
        set.Bind(_helloLabel).To(vm => vm.Hello);
        set.Bind(_helloEdit).To(vm => vm.Hello);
        set.Bind(_clicksButton).For(v => v.BindTouchUpInside()).To(vm => vm.ClickCommand);
        set.Bind(_clicksButton).For(v => v.BindTitle()).To(vm => vm.ClickText);
        set.Bind(_navigateButton).For(v => v.BindTouchUpInside()).To(vm => vm.NavigateCommand);
        set.Bind(_navigateButton).For(v => v.BindTitle()).To(vm => vm.NavigateText);
    }
}