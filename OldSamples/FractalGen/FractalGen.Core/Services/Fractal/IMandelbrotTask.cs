namespace FractalGen.Core.Services.Fractal
{
    public interface IMandelbrotTask
    {
        IMandelbrot Mandelbrot { get; }
        bool CancelFlag { get; }
        bool CopyFlag { get; }
        void Cancel();
        void RequestCopy();
        void CopyComplete(ISimpleWriteableBitmap bitmap);
        void ProcessAsync();
    }
}