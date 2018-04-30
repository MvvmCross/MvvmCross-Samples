using System;
using System.Collections.Generic;
using System.Diagnostics;

using Accelerate;
using CoreGraphics;
using Foundation;
using UIKit;

namespace StarWarsSample.iOS.CustomControls
{
    public class TwitterCoverImageView : UIImageView
    {
        public static readonly nfloat DefaultCoverViewHeight = 160;

        private UIScrollView scrollView;
        private UIView topView;

        public TwitterCoverImageView()
        {
            Initialize(null);
        }

        public TwitterCoverImageView(UIView topView)
        {
            Initialize(topView);
        }

        public TwitterCoverImageView(CGRect frame)
            : base(frame)
        {
            Initialize(null);
        }

        public TwitterCoverImageView(CGRect frame, UIView topView)
            : base(frame)
        {
            Initialize(topView);
        }

        private void Initialize(UIView top)
        {
            topView = top;
            CoverViewHeight = DefaultCoverViewHeight;
            ContentMode = UIViewContentMode.ScaleAspectFill;
            ClipsToBounds = true;
        }

        public nfloat CoverViewHeight { get; set; }

        public UIScrollView ScrollView
        {
            get { return scrollView; }
            set
            {
                if (ScrollView != null)
                {
                    ScrollView.RemoveObserver(this, "contentOffset");
                }
                scrollView = value;
                ScrollView.AddObserver(this, "contentOffset", NSKeyValueObservingOptions.New, IntPtr.Zero);
            }
        }

        public override UIImage Image
        {
            get { return base.Image; }
            set
            {
                base.Image = value;
            }
        }

        public override void LayoutSubviews()
        {
            base.LayoutSubviews();

            var windowWidth = ((AppDelegate)UIApplication.SharedApplication.Delegate).Window.Bounds.Width;

            if (ScrollView.ContentOffset.Y < 0)
            {
                var offset = -ScrollView.ContentOffset.Y;

                nfloat topViewHeight = 0;
                if (topView != null)
                {
                    topView.Frame = new CGRect(0, -offset, windowWidth, topView.Bounds.Size.Height);
                    topViewHeight = topView.Bounds.Size.Height;
                }
                Frame = new CGRect(-offset, -offset + topViewHeight, windowWidth + offset * 2, CoverViewHeight + offset);
            }
            else
            {
                nfloat topViewHeight = 0;
                if (topView != null)
                {
                    topView.Frame = new CGRect(0, 0, windowWidth, topView.Bounds.Size.Height);
                    topViewHeight = topView.Bounds.Size.Height;
                }
                Frame = new CGRect(0, topViewHeight, windowWidth, CoverViewHeight);
            }
        }

        public override void RemoveFromSuperview()
        {
            ScrollView.RemoveObserver(this, "contentOffset");
            if (topView != null)
            {
                topView.RemoveFromSuperview();
            }

            base.RemoveFromSuperview();
        }

        public override void ObserveValue(NSString keyPath, NSObject ofObject, NSDictionary change, IntPtr context)
        {
            SetNeedsLayout();
        }
    }
}
