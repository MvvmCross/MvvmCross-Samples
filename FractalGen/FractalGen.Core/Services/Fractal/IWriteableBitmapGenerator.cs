namespace FractalGen.Core.Services.Fractal
{
    public interface IWriteableBitmapGenerator
    {
        ISimpleWriteableBitmap Generate(int width, int height);
    }
}