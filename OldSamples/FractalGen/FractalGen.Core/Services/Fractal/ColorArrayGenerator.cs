using System;
using System.Collections.Generic;
using Cirrious.CrossCore.UI;

namespace FractalGen.Core.Services.Fractal
{
    public class ColorArrayGenerator : IColorArrayGenerator
    {
        private readonly List<Action> _colorActions;
        private readonly IHSVConverter _converter;
        private readonly Random _random = new Random();
        private List<MvxColor> _colors;

        public ColorArrayGenerator(IHSVConverter converter)
        {
            _converter = converter;
            _colorActions = new List<Action>
                {
                    () => ColorArrayHSVGeneric(0, 360, 1.00, 1.0),
                    () => ColorArrayHSVGeneric(0, 360, 0.60, 1.0),
                    () => ColorArrayHSVGeneric(0, 360, 1.00, 0.75),
                    () => ColorArrayHSVGeneric(0, 360, 0.60, 0.75),
                    () => ColorArrayHSVGeneric(0, 180, 1.00, 1.0),
                    () => ColorArrayHSVGeneric(0, 180, 0.60, 1.0),
                    () => ColorArrayHSVGeneric(0, 180, 1.00, 0.75),
                    () => ColorArrayHSVGeneric(0, 180, 0.60, 0.75),
                    () => ColorArrayHSVGeneric(180, 360, 1.00, 1.0),
                    () => ColorArrayHSVGeneric(180, 360, 0.60, 1.0),
                    () => ColorArrayHSVGeneric(180, 360, 1.00, 0.75),
                    () => ColorArrayHSVGeneric(180, 360, 0.60, 0.75),
                    ColorArrayOne,
                    ColorArrayTwo,
                    ColorArrayThree,
                    ColorArrayFour,
                    ColorArrayFive,
                    ColorArraySix,
                    () => ColorArrayGeneric(1, 0, 0),
                    () => ColorArrayGeneric(0, 1, 0),
                    () => ColorArrayGeneric(0, 0, 1),
                    () => ColorArrayGeneric(1, 0, 0.5),
                    () => ColorArrayGeneric(0, 1.0, 0.5),
                    () => ColorArrayGeneric(0.5, 1, 0),
                    () => ColorArrayGeneric(0, 1, 0.5),
                    () => ColorArrayGeneric(0.5, 0, 1),
                    () => ColorArrayGeneric(0, 0.5, 1),
                };
        }

        public List<MvxColor> NextColorArray()
        {
            var which = _random.Next(_colorActions.Count);
            _colorActions[which]();

            var reverse = _random.Next(2) == 1;
            if (reverse)
                _colors.Reverse();

            return _colors;
        }

        private void ColorArrayHSVGeneric(double startH, double endH, double s, double v)
        {
            _colors = new List<MvxColor>();
            double increment = (endH - startH)/500;
            for (int i = 0; i < 500; i++)
                _colors.Add(FromHSV(i*increment + startH, s, v));
        }

        private MvxColor FromHSV(double h, double s, double v)
        {
            // see http://www.tech-faq.com/hsv.html
            int r, g, b;
            _converter.HsvToRgb(h, s, v, out r, out g, out b);
            return new MvxColor(255, (byte) (r), (byte) (g), (byte) (b));
        }

        private void ColorArrayOne()
        {
            _colors = new List<MvxColor>();
            for (int i = 0; i < 128; i++)
                _colors.Add(new MvxColor((byte) (255 - (i*2)), (byte) (255 - (i*2)), 0));
            //for (int i = 0; i < 128; i++)
            //    _colors.Add(new MvxColor((byte)(i * 2), (byte)(i * 2), 0));
        }

        private void ColorArrayTwo()
        {
            _colors = new List<MvxColor>();
            byte red = 0;
            byte green = 0;
            byte blue = 0;

            // red to yellow
            red = 255;
            for (int i = 0; i < 64; i++)
            {
                _colors.Add(new MvxColor(red, green, blue));
                green = (byte) (green + 4);
            }

            green = 255;
            for (int i = 0; i < 64; i++)
            {
                _colors.Add(new MvxColor(red, green, blue));
                red = (byte) (red - 4);
            }
            red = 0;

            green = 255;
            for (int i = 0; i < 64; i++)
            {
                _colors.Add(new MvxColor(red, green, blue));
                blue = (byte) (blue + 4);
            }

            blue = 255;
            for (int i = 0; i < 64; i++)
            {
                _colors.Add(new MvxColor(red, green, blue));
                green = (byte) (green - 4);
            }
        }

        private void ColorArrayThree()
        {
            _colors = new List<MvxColor>();
            byte red = 0;
            byte green = 0;
            byte blue = 0;

            red = 0;
            for (int i = 0; i < 64; i++)
            {
                _colors.Add(new MvxColor(red, green, blue));
                red = (byte) (red + 4);
            }

            red = 255;
            for (int i = 0; i < 64; i++)
            {
                _colors.Add(new MvxColor(red, green, blue));
                blue = (byte) (blue + 4);
            }
            red = 255;
            blue = 255;

            for (int i = 0; i < 64; i++)
            {
                _colors.Add(new MvxColor(red, green, blue));
                blue = (byte) (blue - 4);
                green = (byte) (green + 4);
            }
            green = 255;
            blue = 0;

            for (int i = 0; i < 64; i++)
            {
                _colors.Add(new MvxColor(red, green, blue));
                blue = (byte) (blue + 4);
            }
        }

        private void ColorArrayFour()
        {
            _colors = new List<MvxColor>();
            for (int i = 0; i < 128; i++)
                _colors.Add(new MvxColor((byte) (255 - (i*2)), 0, (byte) (255 - (i*2))));
            //for (int i = 0; i < 128; i++)
            //    _colors.Add(new MvxColor((byte)(i * 2), 0, (byte)(i * 2)));
        }

        private void ColorArrayFive()
        {
            _colors = new List<MvxColor>();
            for (int i = 0; i < 128; i++)
                _colors.Add(new MvxColor(0, (byte) (255 - (i*2)), (byte) (255 - (i*2))));
            //for (int i = 0; i < 128; i++)
            //    _colors.Add(new MvxColor(0, (byte) (i*2), (byte) (i*2)));
        }

        private void ColorArraySix()
        {
            _colors = new List<MvxColor>();
            for (int i = 0; i < 128; i++)
                _colors.Add(new MvxColor((byte) (255 - (i*2)), (byte) (255 - (i*2)), (byte) (255 - (i*2))));
            //for (int i = 0; i < 128; i++)
            //    _colors.Add(new MvxColor((byte)(i * 2), (byte)(i * 2), (byte)(i * 2)));
        }

        private void ColorArrayGeneric(double red, double green, double blue)
        {
            _colors = new List<MvxColor>();
            for (int i = 0; i < 128; i++)
                _colors.Add(new MvxColor((byte) (red*(255 - (i*2))), (byte) (green*(255 - (i*2))),
                                         (byte) (blue*(255 - (i*2)))));
            //for (int i = 0; i < 128; i++)
            //    _colors.Add(new MvxColor((byte)(red * i * 2), (byte)(green * i * 2), (byte)(blue * i * 2)));
        }
    }
}