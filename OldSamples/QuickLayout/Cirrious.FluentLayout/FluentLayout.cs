// FluentLayout.cs
// (c) Copyright Cirrious Ltd. http://www.cirrious.com
// MvvmCross is licensed using Microsoft Public License (Ms-PL)
// Contributions and inspirations noted in readme.md and license.txt
// 
// Project Lead - Stuart Lodge, @slodge, me@slodge.com

using System;
using System.Collections.Generic;
using MonoTouch.Foundation;
using MonoTouch.UIKit;

namespace Cirrious.FluentLayouts.Touch
{
    public class FluentLayout
    {
        public FluentLayout(
            UIView view,
            NSLayoutAttribute attribute,
            NSLayoutRelation relation,
            NSObject secondItem,
            NSLayoutAttribute secondAttribute)
        {
            View = view;
            Attribute = attribute;
            Relation = relation;
            SecondItem = secondItem;
            SecondAttribute = secondAttribute;
            Multiplier = 1f;
        }

        public FluentLayout(UIView view,
                            NSLayoutAttribute attribute,
                            NSLayoutRelation relation,
                            float constant = 0f)
        {
            View = view;
            Attribute = attribute;
            Relation = relation;
            Multiplier = 1f;
            Constant = constant;
        }

        public UIView View { get; private set; }
        public NSLayoutAttribute Attribute { get; private set; }
        public NSLayoutRelation Relation { get; private set; }
        public NSObject SecondItem { get; private set; }
        public NSLayoutAttribute SecondAttribute { get; private set; }
        public float Multiplier { get; private set; }
        public float Constant { get; private set; }
        public float Priority { get; private set; }

        public FluentLayout Plus(float constant)
        {
            Constant += constant;
            return this;
        }

        public FluentLayout Minus(float constant)
        {
            Constant -= constant;
            return this;
        }

        public FluentLayout WithMultiplier(float multiplier)
        {
            Multiplier = multiplier;
            return this;
        }

        public FluentLayout SetPriority(float priority)
        {
            Priority = priority;
            return this;
        }

        public FluentLayout SetPriority(UILayoutPriority priority)
        {
            Priority = (float) priority;
            return this;
        }

        public FluentLayout LeftOf(NSObject view2)
        {
            return SetSecondItem(view2, NSLayoutAttribute.Left);
        }

        public FluentLayout RightOf(NSObject view2)
        {
            return SetSecondItem(view2, NSLayoutAttribute.Right);
        }

        public FluentLayout TopOf(NSObject view2)
        {
            return SetSecondItem(view2, NSLayoutAttribute.Top);
        }

        public FluentLayout BottomOf(NSObject view2)
        {
            return SetSecondItem(view2, NSLayoutAttribute.Bottom);
        }

        public FluentLayout BaselineOf(NSObject view2)
        {
            return SetSecondItem(view2, NSLayoutAttribute.Baseline);
        }

        public FluentLayout TrailingOf(NSObject view2)
        {
            return SetSecondItem(view2, NSLayoutAttribute.Trailing);
        }

        public FluentLayout LeadingOf(NSObject view2)
        {
            return SetSecondItem(view2, NSLayoutAttribute.Leading);
        }

        public FluentLayout CenterXOf(NSObject view2)
        {
            return SetSecondItem(view2, NSLayoutAttribute.CenterX);
        }

        public FluentLayout CenterYOf(NSObject view2)
        {
            return SetSecondItem(view2, NSLayoutAttribute.CenterY);
        }

        public FluentLayout HeightOf(NSObject view2)
        {
            return SetSecondItem(view2, NSLayoutAttribute.Height);
        }

        public FluentLayout WidthOf(NSObject view2)
        {
            return SetSecondItem(view2, NSLayoutAttribute.Width);
        }

        private FluentLayout SetSecondItem(NSObject view2, NSLayoutAttribute attribute2)
        {
            ThrowIfSecondItemAlreadySet();
            SecondAttribute = attribute2;
            SecondItem = view2;
            return this;
        }

        private void ThrowIfSecondItemAlreadySet()
        {
            if (SecondItem != null)
                throw new Exception("You cannot set the second item in a layout relation more than once");
        }

        public IEnumerable<NSLayoutConstraint> ToLayoutConstraints()
        {
            yield return NSLayoutConstraint.Create(
                View,
                Attribute,
                Relation,
                SecondItem,
                SecondAttribute,
                Multiplier,
                Constant);
        }
    }
}