using System.Drawing;
using Cirrious.MvvmCross.Binding.BindingContext;
using Cirrious.MvvmCross.Binding.Touch.Views;
using CrossUI.Touch.Dialog.Elements;
using DialogExamples.Core.ViewModels;
using MonoTouch.CoreGraphics;
using MonoTouch.UIKit;

namespace DialogExamples.Touch.BindableElements
{
    public class CustomViewElement
        : UIViewElement
        , IBindableElement
    {
        public IMvxBindingContext BindingContext { get; set; }

        public CustomViewElement()
            : base("", new SampleView(), false)
        {
            this.CreateBindingContext();
            this.DelayBind(() =>
                {
                    this.CreateBinding().For(me => me.Title).To<ThirdViewModel.Person>(li => li.FirstName).Apply();
                    this.CreateBinding().For(me => me.Subtitle).To<ThirdViewModel.Person>(li => li.LastName).Apply();
                });
        }

        protected override void Dispose(bool disposing)
        {
            if (disposing)
            {
                BindingContext.ClearAllBindings();
            }
            base.Dispose(disposing);
        }

        public virtual object DataContext
        {
            get { return BindingContext.DataContext; }
            set { BindingContext.DataContext = value; }
        }

        private SampleView InnerView
        {
            get { return (base.View) as SampleView; }
        }

        public string Title
        {
            get
            {
                if (InnerView == null) return null; 
                return InnerView.Title;
            }
            set
            {
                if (InnerView == null) return;
                InnerView.Title = value;
            }
        }

        public string Subtitle
        {
            get
            {
                if (InnerView == null) return null;
                return InnerView.Subtitle;
            }
            set
            {
                if (InnerView == null) return;
                InnerView.Subtitle = value;
            }
        }

        public class SampleView : UIView
        {
            public MvxImageView ImageView;
            private string _title;
            private string _subtitle;

            public SampleView()
                : base(new RectangleF(0f, 0f, 450f, 100f))
            {
                this.BackgroundColor = UIColor.Clear;
            }

            public string Title
            {
                get { return _title; }
                set { _title = value; SetNeedsDisplay(); }
            }

            public string Subtitle
            {
                get { return _subtitle; }
                set { _subtitle = value; SetNeedsDisplay(); }
            }

            public override void Draw(System.Drawing.RectangleF rect)
            {
                using (CGContext context = UIGraphics.GetCurrentContext())
                {
                    UIColor.Black.SetColor();

                    var boldFont = UIFont.BoldSystemFontOfSize(14.0f);
                    var regularFont = UIFont.SystemFontOfSize(14.0f);

                    this.DrawString(Title, new RectangleF(4, 2, 320, 20), boldFont);
                    this.DrawString(Subtitle, new RectangleF(54, 22, 450, 20), regularFont);
                }
            }
        }
    }
}