using System;
using Cirrious.FluentLayouts.Touch;
using UIKit;

namespace StarWarsSample.iOS.CustomControls
{
    public class MenuOption : BaseView
    {
        private const float PADDING = 16f;

        public UILabel Label { get; set; }

        public UIView Line { get; set; }

        public MenuOption()
        {
        }

        protected override void CreateViews()
        {
            base.CreateViews();

            Label = new UILabel
            {
                TextColor = UIColor.Red,
                Font = UIFont.SystemFontOfSize(15f, UIFontWeight.Bold)
            };

            Line = new UIView { BackgroundColor = UIColor.LightGray };

            AddSubviews(Label, Line);
            this.SubviewsDoNotTranslateAutoresizingMaskIntoConstraints();
        }

        protected override void CreateConstraints()
        {
            base.CreateConstraints();

            this.AddConstraints(
                Label.AtLeftOf(this, PADDING),
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
