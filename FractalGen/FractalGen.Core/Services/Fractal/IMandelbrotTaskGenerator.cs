using System;

namespace FractalGen.Core.Services.Fractal
{
    public interface IMandelbrotTaskGenerator
    {
        IMandelbrotTask Generate(int width, int height, Action<ISimpleWriteableBitmap> copyOutAction);
    }
}