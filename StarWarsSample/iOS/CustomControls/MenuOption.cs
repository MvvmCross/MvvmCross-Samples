using System;
using Cirrious.FluentLayouts.Touch;
using UIKit;

namespace StarWarsSample.iOS.CustomControls
{
    public class MenuOption : BaseView
    {
        private const float PADDING = 16f;
        private const float IMAGE_SIZE = 22f;

        public UIImageView Image { get; set; }

        public UILabel Label { get; set; }

        public UIView Line { get; set; }

        public MenuOption()
        {
        }

        protected override void CreateViews()
        {
            base.CreateViews();

            Image = new UIImageView();

            Label = new UILabel
            {
                TextColor = UIColor.Red,
                Font = UIFont.SystemFontOfSize(15f, UIFontWeight.Bold)
            };

            Line = new UIView { BackgroundColor = UIColor.LightGray };

            AddSubviews(Image, Label, Line);
            this.SubviewsDoNotTranslateAutoresizingMaskIntoConstraints();
        }

        protected override void CreateConstraints()
        {
            base.CreateConstraints();

            this.AddConstraints(
                Image.AtLeftOf(this, PADDING),
                Image.WithSameCenterY(this),
                Image.Width().EqualTo(IMAGE_SIZE),
                Image.Height().EqualTo(IMAGE_SIZE),

                Label.ToRightOf(Image, PADDING / 2),
                Label.AtTopOf(this, PADDING),
                Label.AtRightOf(this, PADDING),

                Line.Below(Label, PADDING),
                Line.AtLeftOf(this, PADDING),
                Line.AtRightOf(this),
                Line.AtBottomOf(this),
                Line.Height().EqualTo(.5f)
            );
        }
    }
}
