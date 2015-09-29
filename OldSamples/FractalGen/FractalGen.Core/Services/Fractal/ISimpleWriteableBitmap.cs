using Cirrious.CrossCore.UI;

namespace FractalGen.Core.Services.Fractal
{
    public interface ISimpleWriteableBitmap
    {
        int[] Pixels { get; }
        int Height { get; }
        int Width { get; }
        ISimpleWriteableBitmap Clone();
        void FillRectangle(int fromX, int fromY, int toX, int toY, MvxColor color);
    }
}