using Cirrious.FluentLayouts.Touch;
using MvvmCross.iOS.Views;
using MvvmCross.iOS.Views.Presenters.Attributes;
using StarWarsSample.iOS.CustomViews;
using StarWarsSample.ViewModels;
using UIKit;

namespace StarWarsSample.iOS.Views
{
    [MvxChildPresentation]
    public class PersonView : MvxViewController<PersonViewModel>
    {
        private UIScrollView _scrollView;
        private UIView _contentView;
        private TwitterCoverImageView _twitterCoverImageView;

        public PersonView()
        {
        }

        public override void ViewDidLoad()
        {
            base.ViewDidLoad();

            _scrollView = new UIScrollView();

            _twitterCoverImageView = new TwitterCoverImageView
            {
                CoverViewHeight = 80f,
                BackgroundColor = UIColor.Clear,
                Image = UIImage.FromBundle("ic_vader"),
                ScrollView = _scrollView
            };
            _scrollView.AddSubview(_twitterCoverImageView);

            _contentView = new UIView { BackgroundColor = UIColor.White };

            View.AddSubviews(_scrollView);
            View.SubviewsDoNotTranslateAutoresizingMaskIntoConstraints();

            _scrollView.AddSubview(_contentView);
            _scrollView.SubviewsDoNotTranslateAutoresizingMaskIntoConstraints();

            View.AddConstraints(
                _scrollView.AtLeftOf(View),
                _scrollView.AtTopOf(View),
                _scrollView.AtRightOf(View),
                _scrollView.AtBottomOf(View)
            );

            _scrollView.AddConstraints(
                _contentView.AtTopOf(_scrollView, 80f),
                _contentView.AtLeftOf(_scrollView),
                _contentView.AtRightOf(_scrollView),
                _contentView.AtBottomOf(_scrollView),

                _contentView.Height().EqualTo(1000f)
            );

            View.AddConstraints(
                _contentView.WithSameWidth(View)
            );
        }

        public override void ViewWillAppear(bool animated)
        {
            base.ViewWillAppear(animated);

            NavigationController.SetNavigationBarHidden(true, false);
        }

        public override void ViewWillDisappear(bool animated)
        {
            base.ViewWillDisappear(animated);

            NavigationController.SetNavigationBarHidden(false, false);
        }
    }
}
