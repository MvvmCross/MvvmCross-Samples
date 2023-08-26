using Core.ViewModels;
using MvvmCross.Platforms.Ios.Views;

namespace iOSApp.Views;

public sealed class DetailViewController : MvxViewController<DetailViewModel>
{
    private UILabel? _detailLabel;

    public override void LoadView()
    {
        base.LoadView();

        View.BackgroundColor = UIColor.White;
        Title = "Details";

        _detailLabel = new UILabel
        {
            TranslatesAutoresizingMaskIntoConstraints = false,
            TextColor = UIColor.Black
        };
        
        Add(_detailLabel);

        _detailLabel.TopAnchor.ConstraintEqualTo(View.SafeAreaLayoutGuide.TopAnchor, 16).Active = true;
        _detailLabel.LeadingAnchor.ConstraintEqualTo(View.SafeAreaLayoutGuide.LeadingAnchor).Active = true;
        _detailLabel.TrailingAnchor.ConstraintEqualTo(View.SafeAreaLayoutGuide.TrailingAnchor).Active = true;
    }

    public override void ViewDidLoad()
    {
        base.ViewDidLoad();

        using var set = CreateBindingSet();
        set.Bind(_detailLabel).To(vm => vm.DetailText);
    }
}