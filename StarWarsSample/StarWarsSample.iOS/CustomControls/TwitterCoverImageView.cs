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
        //private List<UIImage> blurredImages;

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
            //blurredImages = new List<UIImage>(20);
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
                //PrepareForBlurImages();
            }
        }

        public override void LayoutSubviews()
        {
            base.LayoutSubviews();

            if (ScrollView.ContentOffset.Y < 0)
            {
                var offset = -ScrollView.ContentOffset.Y;

                nfloat topViewHeight = 0;
                if (topView != null)
                {
                    topView.Frame = new CGRect(0, -offset, 320, topView.Bounds.Size.Height);
                    topViewHeight = topView.Bounds.Size.Height;
                }
                Frame = new CGRect(-offset, -offset + topViewHeight, 320 + offset * 2, CoverViewHeight + offset);

                //int index = (int)offset / 10;
                //if (index < 0)
                //{
                //    index = 0;
                //}
                //else if (index >= blurredImages.Count)
                //{
                //    index = blurredImages.Count - 1;
                //}
                //var image = blurredImages[index];
                //if (Image != image)
                //{
                //    base.Image = image;
                //}
            }
            else
            {
                nfloat topViewHeight = 0;
                if (topView != null)
                {
                    topView.Frame = new CGRect(0, 0, 320, topView.Bounds.Size.Height);
                    topViewHeight = topView.Bounds.Size.Height;
                }
                Frame = new CGRect(0, topViewHeight, 320, CoverViewHeight);

                //var image = blurredImages[0];
                //if (Image != image)
                //{
                //    base.Image = image;
                //}
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

        /*
        private void PrepareForBlurImages()
        {
            blurredImages.Clear();
            float num = 0.1f;
            blurredImages.Add(Image);
            for (int i = 0; i < 20; i++)
            {
                blurredImages.Add(Blur(Image, num));
                num += 0.04f;
            }
        }
        */

        /*
        private static UIImage Blur(UIImage image, float blurRadius)
        {
            if (image.Size.Width < 1 || image.Size.Height < 1)
            {
                Debug.WriteLine(@"*** error: invalid size:({0} x {1}). Both dimensions must be >= 1: {2}", image.Size.Width, image.Size.Height, image);
                return null;
            }
            if (image.CGImage == null)
            {
                Debug.WriteLine(@"*** error: image must be backed by a CGImage: {0}", image);
                return null;
            }

            if (blurRadius < 0f || blurRadius > 1f)
            {
                blurRadius = 0.5f;
            }
            var inputRadius = blurRadius * UIScreen.MainScreen.Scale;
            var boxSize = (uint)(inputRadius * 40);
            boxSize = boxSize - (boxSize % 2) + 1;

            var imageRect = new CGRect(CGPoint.Empty, image.Size);

            UIImage effectImage;
            UIGraphics.BeginImageContextWithOptions(image.Size, false, UIScreen.MainScreen.Scale);
            {
                var contextIn = UIGraphics.GetCurrentContext();
                //              contextIn.ScaleCTM(1.0f, -1.0f);
                //              contextIn.TranslateCTM(0, -image.Size.Height);
                contextIn.DrawImage(imageRect, image.CGImage);
                var effectInContext = contextIn.AsBitmapContext();

                var effectInBuffer = new vImageBuffer
                {
                    Data = effectInContext.Data,
                    Width = (int)effectInContext.Width,
                    Height = (int)effectInContext.Height,
                    BytesPerRow = (int)effectInContext.BytesPerRow
                };

                UIGraphics.BeginImageContextWithOptions(image.Size, false, UIScreen.MainScreen.Scale);
                {
                    var effectOutContext = UIGraphics.GetCurrentContext().AsBitmapContext();
                    var effectOutBuffer = new vImageBuffer
                    {
                        Data = effectOutContext.Data,
                        Width = (int)effectOutContext.Width,
                        Height = (int)effectOutContext.Height,
                        BytesPerRow = (int)effectOutContext.BytesPerRow
                    };

                    vImage.BoxConvolveARGB8888(ref effectInBuffer, ref effectOutBuffer, IntPtr.Zero, 0, 0, boxSize, boxSize, Pixel8888.Zero, vImageFlags.EdgeExtend);
                    vImage.BoxConvolveARGB8888(ref effectOutBuffer, ref effectInBuffer, IntPtr.Zero, 0, 0, boxSize, boxSize, Pixel8888.Zero, vImageFlags.EdgeExtend);
                    vImage.BoxConvolveARGB8888(ref effectInBuffer, ref effectOutBuffer, IntPtr.Zero, 0, 0, boxSize, boxSize, Pixel8888.Zero, vImageFlags.EdgeExtend);

                    effectImage = UIGraphics.GetImageFromCurrentImageContext();

                    UIGraphics.EndImageContext();
                }

                UIGraphics.EndImageContext();
            }

            // Setup up output context
            UIImage outputImage;
            UIGraphics.BeginImageContextWithOptions(image.Size, false, UIScreen.MainScreen.Scale);
            {
                var outputContext = UIGraphics.GetCurrentContext();
                //              outputContext.ScaleCTM(1, -1);
                //              outputContext.TranslateCTM(0, -image.Size.Height);

                // Draw base image
                outputContext.SaveState();
                outputContext.DrawImage(imageRect, effectImage.CGImage);
                outputContext.RestoreState();

                outputImage = UIGraphics.GetImageFromCurrentImageContext();

                UIGraphics.EndImageContext();
            }

            return outputImage;
        }
        */
    }
}
