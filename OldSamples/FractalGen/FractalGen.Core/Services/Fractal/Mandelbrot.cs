using System;
using System.Collections.Generic;
using Cirrious.CrossCore.UI;

namespace FractalGen.Core.Services.Fractal
{
    public class Mandelbrot : IMandelbrot
    {
        private const double ITERATION_MAX = 150.0;

        private readonly int BASE_HEIGHT;
        private readonly int BASE_WIDTH;
        private readonly double FINISH_SCALE = 1;

        private readonly ISimpleWriteableBitmap _bitmap;

        private readonly List<MvxColor> _colorArray;

        private readonly double _xmax;
        private readonly double _xmin;
        private readonly double _ymax;
        private readonly double _ymin;
        private double HEIGHT;
        private double SCALE_DOWN = 256;
        private double SCALE_UP = 256;
        private double WIDTH;

        private double _s;
        private double _x;
        private double _xIncrement;
        private double _yIncrement;

        public Mandelbrot(Limits limits, List<MvxColor> colorArray, ISimpleWriteableBitmap bitmap)
        {
            BASE_HEIGHT = bitmap.Height;
            BASE_WIDTH = bitmap.Width;
            _bitmap = bitmap;
            _xmax = limits.XMax;
            _xmin = limits.XMin;
            _ymax = limits.YMax;
            _ymin = limits.YMin;
            _colorArray = colorArray;
            SCALE_DOWN = 8;
            SCALE_UP = 8;
            FINISH_SCALE = 1;
            NextLevel();
        }

        public ISimpleWriteableBitmap Bitmap
        {
            get { return _bitmap; }
        }

        public bool IsScaleComplete
        {
            get
            {
                return
                    IsLineComplete &&
                    SCALE_UP <= FINISH_SCALE;
            }
        }

        public bool IsLineComplete
        {
            get { return _s >= WIDTH; }
        }

        public void NextLine()
        {
            if (IsLineComplete)
            {
                NextLevel();
                return;
            }

            double y = _ymin;

            for (int z = 0; z < HEIGHT; z++)
            {
                double x1 = 0.0;
                double y1 = 0.0;
                double looper = 0.0;
                while (looper < ITERATION_MAX && x1*x1 + y1*y1 < 4)
                {
                    looper = looper + 1.0;
                    double xx = (x1*x1) - (y1*y1) + _x;
                    y1 = 2*x1*y1 + y;
                    x1 = xx;
                }

                // Get the percent of where the looper stopped
                double perc = looper/(ITERATION_MAX);

                // Get that part of a _colors.Count - 1 scale
                var val = (int) Math.Floor(perc*(_colorArray.Count - 1));

                // Use that number to set the color
                SetPixel(_s, z, _colorArray[val]);
                y = _yIncrement + y;
            }
            _x = _x + _xIncrement;
            _s = _s + 1;
        }

        private void NextLevel()
        {
            if (SCALE_UP <= FINISH_SCALE)
            {
                return;
            }

            SCALE_DOWN = SCALE_DOWN/8;
            SCALE_UP = SCALE_UP/8;

            WIDTH = BASE_WIDTH/SCALE_DOWN;
            HEIGHT = BASE_HEIGHT/SCALE_DOWN;

            _xIncrement = (_xmax - _xmin)/WIDTH;
            _yIncrement = (_ymax - _ymin)/HEIGHT;

            _x = _xmin;
            _s = 0;
        }

        private void SetPixel(double x, double y, MvxColor color)
        {
            _bitmap.FillRectangle((int) (x*SCALE_UP), (int) (y*SCALE_UP), (int) ((x + 1)*SCALE_UP),
                                  (int) ((y + 1)*SCALE_UP), color);
        }
    }
}