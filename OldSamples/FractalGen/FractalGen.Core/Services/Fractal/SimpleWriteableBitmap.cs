using System;
using Cirrious.CrossCore.UI;

namespace FractalGen.Core.Services.Fractal
{
    public class SimpleWriteableBitmap : ISimpleWriteableBitmap
    {
        public SimpleWriteableBitmap(int baseWidth, int baseHeight)
        {
            Height = baseHeight;
            Width = baseWidth;
            Pixels = new int[baseWidth*baseHeight];
        }

        public int Height { get; private set; }
        public int Width { get; private set; }
        public int[] Pixels { get; private set; }

        public ISimpleWriteableBitmap Clone()
        {
            var bitmap = new SimpleWriteableBitmap(Width, Height);
            Array.Copy(Pixels, bitmap.Pixels, Pixels.Length);
            return bitmap;
        }

        public void FillRectangle(int fromX, int fromY, int toX, int toY, MvxColor color)
        {
            for (var y = fromY; y < toY; y++)
            {
                var offset = y*Width;
                for (var x = fromX; x < toX; x++)
                {
                    Pixels[x + offset] = color.ARGB;
                }
            }
        }
    }
}