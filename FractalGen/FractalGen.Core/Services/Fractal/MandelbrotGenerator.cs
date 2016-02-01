namespace FractalGen.Core.Services.Fractal
{
    public class MandelbrotGenerator : IMandelbrotGenerator
    {
        private readonly IColorArrayGenerator _colorArrayGenerator;
        private readonly IInterestingPointGenerator _pointGenerator;
        private readonly IWriteableBitmapGenerator _writeableBitmapGenerator;

        public MandelbrotGenerator(IInterestingPointGenerator pointGenerator, IColorArrayGenerator colorArrayGenerator,
                                   IWriteableBitmapGenerator writeableBitmapGenerator)
        {
            _writeableBitmapGenerator = writeableBitmapGenerator;
            _pointGenerator = pointGenerator;
            _colorArrayGenerator = colorArrayGenerator;
        }

        public IMandelbrot Generate(int width, int height)
        {
            var limits = _pointGenerator.Generate();
            var colors = _colorArrayGenerator.NextColorArray();
            var bitmap = _writeableBitmapGenerator.Generate(width, height);

            return new Mandelbrot(limits, colors, bitmap);
        }
    }
}