using System;
using Cirrious.FluentLayouts.Touch;
using CoreAnimation;
using MvvmCross.iOS.Views;
using StarWarsSample.iOS.CustomViews;
using StarWarsSample.ViewModels;
using UIKit;

namespace StarWarsSample.iOS.Views
{
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

            //objc_setAssociatedObject(_scrollView.Handle, coverViewKey.Handle, coverView.Handle, AssociationPolicy.RETAIN);

            //return twitterCoverImageView;


            //_scrollView.Scrolled += ScrollView_Scrolled;
            _contentView = new UIView { BackgroundColor = UIColor.White };
            //_header = new UIView { BackgroundColor = UIColor.Blue };

            //_lblHeader = new UILabel { Text = "ASDad", TextColor = UIColor.Green };

            View.AddSubviews(_scrollView);
            View.SubviewsDoNotTranslateAutoresizingMaskIntoConstraints();

            //_header.AddSubviews(_lblHeader);
            //_header.SubviewsDoNotTranslateAutoresizingMaskIntoConstraints();

            _scrollView.AddSubview(_contentView);
            _scrollView.SubviewsDoNotTranslateAutoresizingMaskIntoConstraints();

            View.AddConstraints(
                _scrollView.AtLeftOf(View),
                _scrollView.AtTopOf(View),
                _scrollView.AtRightOf(View),
                _scrollView.AtBottomOf(View)

            //_header.AtLeftOf(View),
            //_header.AtTopOf(View),
            //_header.AtRightOf(View),
            //_header.Height().EqualTo(107f)
            );

            //_header.AddConstraints(
            //    _lblHeader.WithSameCenterX(_header),
            //    _lblHeader.AtTopOf(_header, 104f),

            //    _imgBack.AtLeftOf(_header),
            //    _imgBack.AtTopOf(_header),
            //    _imgBack.AtRightOf(_header),
            //    _imgBack.AtBottomOf(_header)
            //);

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

        //private void ScrollView_Scrolled(object sender, EventArgs e)
        //{
        //    var offset = _scrollView.ContentOffset.Y;

        //    var avatarTransform = CATransform3D.Identity;

        //    var headerTransform = CATransform3D.Identity;

        //    // PULL DOWN -----------------

        //    if (offset < 0)
        //    {

        //        var headerScaleFactor = -(offset) / _header.Bounds.Height;

        //        var headerSizevariation = ((_header.Bounds.Height * (1f + headerScaleFactor)) - _header.Bounds.Height) / 2f;

        //        headerTransform = headerTransform.Translate(0, headerSizevariation, 0);

        //        headerTransform = headerTransform.Scale(1f + headerScaleFactor, 1f + headerScaleFactor, 0);

        //        _header.Layer.Transform = headerTransform;

        //    }

        //    // SCROLL UP/DOWN ------------

        //    else
        //    {

        //        // Header -----------

        //        headerTransform = headerTransform.Translate(0, Math.Max(-OFFSET_HEADER_STOP, (float)-offset), 0);

        //        //  ------------ Label

        //        var labelTransform = CATransform3D.MakeTranslation(0, Math.Max((float)-DISTANCE_W_LABEL_HEADER, (float)(OFFSET_B_LBL_HEADER - offset)), 0);


        //        _lblHeader.Layer.Transform = labelTransform;

        //        //  ------------ Blur

        //        //headerBlurImageView?.alpha = min(1.0, (offset - offset_B_LabelHeader) / distance_W_LabelHeader)

        //        // Avatar -----------

        //        //var avatarScaleFactor = (Math.Min(offset_HeaderStop, offset)) / avatarImage.bounds.height / 1.4 // Slow down the animation


        //        //var avatarSizeVariation = ((avatarImage.bounds.height * (1.0 + avatarScaleFactor)) - avatarImage.bounds.height) / 2.0


        //        //avatarTransform = CATransform3DTranslate(avatarTransform, 0, avatarSizeVariation, 0)


        //        //avatarTransform = CATransform3DScale(avatarTransform, 1.0 - avatarScaleFactor, 1.0 - avatarScaleFactor, 0)



        //        if (offset <= OFFSET_HEADER_STOP)
        //        {

        //            //if avatarImage.layer.zPosition < header.layer.zPosition{
        //            //header.layer.zPosition = 0


        //            //}

        //        }
        //        else
        //        {
        //            //if avatarImage.layer.zPosition >= header.layer.zPosition{
        //            //header.layer.zPosition = 2


        //            //}
        //        }
        //    }

        //    // Apply Transformations

        //    _header.Layer.Transform = headerTransform;
        //    //avatarImage.layer.transform = avatarTransform
        //}
    }
}
