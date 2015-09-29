// UIViewAndLayoutAttribute.cs
// (c) Copyright Cirrious Ltd. http://www.cirrious.com
// MvvmCross is licensed using Microsoft Public License (Ms-PL)
// Contributions and inspirations noted in readme.md and license.txt
// 
// Project Lead - Stuart Lodge, @slodge, me@slodge.com

using MonoTouch.UIKit;

namespace Cirrious.FluentLayouts.Touch
{
    public class UIViewAndLayoutAttribute
    {
        public UIViewAndLayoutAttribute(UIView view, NSLayoutAttribute attribute)
        {
            Attribute = attribute;
            View = view;
        }

        public UIView View { get; private set; }
        public NSLayoutAttribute Attribute { get; private set; }

        public FluentLayout EqualTo(float constant = 0f)
        {
            return new FluentLayout(View, Attribute, NSLayoutRelation.Equal, constant);
        }

        public FluentLayout GreaterThanOrEqualTo(float constant = 0f)
        {
            return new FluentLayout(View, Attribute, NSLayoutRelation.GreaterThanOrEqual, constant);
        }

        public FluentLayout LessThanOrEqualTo(float constant = 0f)
        {
            return new FluentLayout(View, Attribute, NSLayoutRelation.LessThanOrEqual, constant);
        }
    }
}