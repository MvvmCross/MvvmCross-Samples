using System;

namespace FractalGen.Core.Services.Fractal
{
    public class MandelbrotTaskGenerator : IMandelbrotTaskGenerator
    {
        private readonly IMandelbrotGenerator _mandelbrotGenerator;

        public MandelbrotTaskGenerator(IMandelbrotGenerator mandelbrotGenerator)
        {
            _mandelbrotGenerator = mandelbrotGenerator;
        }

        public IMandelbrotTask Generate(int width, int height, Action<ISimpleWriteableBitmap> copyOutAction)
        {
            var currentMandelbrot = _mandelbrotGenerator.Generate(width, height);
            return new MandelbrotTask(currentMandelbrot, copyOutAction);
        }
    }
}