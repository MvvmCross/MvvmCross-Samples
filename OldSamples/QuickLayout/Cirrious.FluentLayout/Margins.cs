// Margins.cs
// (c) Copyright Cirrious Ltd. http://www.cirrious.com
// MvvmCross is licensed using Microsoft Public License (Ms-PL)
// Contributions and inspirations noted in readme.md and license.txt
// 
// Project Lead - Stuart Lodge, @slodge, me@slodge.com

namespace Cirrious.FluentLayouts.Touch
{
    public class Margins
    {
        public float Top { get; set; }
        public float Bottom { get; set; }
        public float Left { get; set; }
        public float Right { get; set; }
        public float VSpacing { get; set; }
        public float HSpacing { get; set; }

        public Margins()
        {
        }

        public Margins(float all)
        {
            Top = all;
            Bottom = all;
            Right = all;
            Left = all;
            VSpacing = all;
            HSpacing = all;
        }

        public Margins(float allHorizontal, float allVertical)
        {
            Top = allVertical;
            Bottom = allVertical;
            Right = allHorizontal;
            Left = allHorizontal;
            VSpacing = allVertical;
            HSpacing = allHorizontal;
        }

        public Margins(float left, float top, float right, float bottom, float hspacing, float vspacing)
        {
            Top = top;
            Bottom = bottom;
            Right = right;
            Left = left;
            VSpacing = vspacing;
            HSpacing = hspacing;
        }
    }
}