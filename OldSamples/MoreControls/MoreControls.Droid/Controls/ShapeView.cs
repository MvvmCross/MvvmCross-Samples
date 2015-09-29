using System;
using Android.Content;
using Android.Graphics;
using Android.Util;
using Android.Views;
using Cirrious.MvvmCross.Binding.Droid.Views;
using MoreControls.Core.ViewModels;

namespace MoreControls.Droid.Controls
{
    public class ShapeView : View
    {
        private Shape _shape;

        public ShapeView(Context context, IAttributeSet attrs) :
            base(context, attrs)
        {
            Initialize();
        }

        public ShapeView(Context context, IAttributeSet attrs, int defStyle) :
            base(context, attrs, defStyle)
        {
            Initialize();
        }

        private void Initialize()
        {
        }

        public Shape Shape
        {
            get { return _shape; }
            set { _shape = value; Invalidate(); }
        }

        protected override void OnDraw(Android.Graphics.Canvas canvas)
        {
            var rect = new RectF(0, 0, 300, 300);
            switch (Shape)
            {
                case Shape.Circle:
                    canvas.DrawOval(rect, new Paint() { Color = Color.CornflowerBlue });
                    break;
                case Shape.Square:
                    canvas.DrawRect(rect, new Paint() { Color = Color.Crimson });
                    break;
                case Shape.Triangle:

                    var path = new Path();
                    path.MoveTo(rect.CenterX(), rect.Top);
                    path.LineTo(rect.Left, rect.Bottom);
                    path.LineTo(rect.Right, rect.Bottom);
                    path.Close();
                    var paint = new Paint() {Color = Color.Crimson};
                    paint.Color = Color.Gold;
                    paint.SetStyle(Paint.Style.Fill);
                    canvas.DrawPath(path, paint);
                    break;
                default:
                    throw new ArgumentOutOfRangeException();
            }
        }
    }
}