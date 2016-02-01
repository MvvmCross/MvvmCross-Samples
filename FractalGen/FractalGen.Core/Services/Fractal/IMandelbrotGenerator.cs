namespace FractalGen.Core.Services.Fractal
{
    public interface IMandelbrotGenerator
    {
        IMandelbrot Generate(int width, int height);
    }
}