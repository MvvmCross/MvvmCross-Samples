// AdvancedFluentLayoutExtensions.cs
// (c) Copyright Cirrious Ltd. http://www.cirrious.com
// MvvmCross is licensed using Microsoft Public License (Ms-PL)
// Contributions and inspirations noted in readme.md and license.txt
// 
// Project Lead - Stuart Lodge, @slodge, me@slodge.com

using System.Collections.Generic;
using MonoTouch.UIKit;

namespace Cirrious.FluentLayouts.Touch
{
    public static class AdvancedFluentLayoutExtensions
    {
        public static FluentLayout AtTopOf(this UIView view, UIView parentView, float margin = 0f)
        {
            return view.Top().EqualTo().TopOf(parentView).Plus(margin);
        }

        public static FluentLayout AtLeftOf(this UIView view, UIView parentView, float margin = 0f)
        {
            return view.Left().EqualTo().LeftOf(parentView).Plus(margin);
        }

        public static FluentLayout AtRightOf(this UIView view, UIView parentView, float margin = 0f)
        {
            return view.Right().EqualTo().RightOf(parentView).Minus(margin);
        }

        public static FluentLayout AtBottomOf(this UIView view, UIView parentView, float margin = 0f)
        {
            return view.Bottom().EqualTo().BottomOf(parentView).Minus(margin);
        }

        public static FluentLayout Below(this UIView view, UIView previous, float margin = 0f)
        {
            return view.Top().EqualTo().BottomOf(previous).Plus(margin);
        }

        public static FluentLayout Above(this UIView view, UIView previous, float margin = 0f)
        {
            return view.Bottom().EqualTo().TopOf(previous).Minus(margin);
        }

        public static FluentLayout WithSameLeft(this UIView view, UIView previous)
        {
            return view.Left().EqualTo().LeftOf(previous);
        }

        public static FluentLayout WithSameTop(this UIView view, UIView previous)
        {
            return view.Top().EqualTo().TopOf(previous);
        }

        public static FluentLayout WithSameCenterX(this UIView view, UIView previous)
        {
            return view.CenterX().EqualTo().CenterXOf(previous);
        }

        public static FluentLayout WithSameCenterY(this UIView view, UIView previous)
        {
            return view.CenterY().EqualTo().CenterYOf(previous);
        }

        public static FluentLayout WithSameRight(this UIView view, UIView previous)
        {
            return view.Right().EqualTo().RightOf(previous);
        }

        public static FluentLayout WithSameWidth(this UIView view, UIView previous)
        {
            return view.Width().EqualTo().WidthOf(previous);
        }

        public static FluentLayout WithSameBottom(this UIView view, UIView previous)
        {
            return view.Bottom().EqualTo().BottomOf(previous);
        }

        public static FluentLayout WithRelativeWidth(this UIView view, UIView previous, float scale = 1.0f)
        {
            return view.Width().EqualTo().WidthOf(previous).WithMultiplier(scale);
        }

        public static FluentLayout WithSameHeight(this UIView view, UIView previous)
        {
            return view.Height().EqualTo().HeightOf(previous);
        }

        public static FluentLayout WithRelativeHeight(this UIView view, UIView previous, float scale = 1.0f)
        {
            return view.Height().EqualTo().HeightOf(previous).WithMultiplier(scale);
        }

        public static FluentLayout ToRightOf(this UIView view, UIView previous, float margin = 0f)
        {
            return view.Left().EqualTo().RightOf(previous).Plus(margin);
        }

        public static FluentLayout ToLeftOf(this UIView view, UIView previous, float margin = 0f)
        {
            return view.Right().EqualTo().LeftOf(previous).Minus(margin);
        }

        public static IEnumerable<FluentLayout> FullWidthOf(this UIView view, UIView parent, float margin = 0f)
        {
            yield return view.Left().EqualTo().LeftOf(parent).Plus(margin);
            yield return view.Right().EqualTo().RightOf(parent).Minus(margin);
        }

        public static IEnumerable<FluentLayout> FullHeightOf(this UIView view, UIView parent, float margin = 0f)
        {
            yield return view.Top().EqualTo().TopOf(parent).Plus(margin);
            yield return view.Bottom().EqualTo().BottomOf(parent).Minus(margin);
        }

        public static IEnumerable<FluentLayout> VerticalStackPanelConstraints(this UIView parentView, Margins margins,
                                                                              params UIView[] views)
        {
            margins = margins ?? new Margins();

            UIView previous = null;
            foreach (var view in views)
            {
                yield return view.Left().EqualTo().LeftOf(parentView).Plus(margins.Left);
                yield return view.Width().EqualTo().WidthOf(parentView).Minus(margins.Right + margins.Left);
                if (previous != null)
                    yield return view.Top().EqualTo().BottomOf(previous).Plus(margins.VSpacing);
                else
                    yield return view.Top().EqualTo().TopOf(parentView).Plus(margins.Top);
                previous = view;
            }
            if (parentView is UIScrollView)
                yield return previous.Bottom().EqualTo().BottomOf(parentView).Minus(margins.Bottom);
        }
    }
}