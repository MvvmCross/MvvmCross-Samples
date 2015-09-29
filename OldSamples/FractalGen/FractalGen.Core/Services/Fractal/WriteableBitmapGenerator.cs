namespace FractalGen.Core.Services.Fractal
{
    public class WriteableBitmapGenerator : IWriteableBitmapGenerator
    {
        public ISimpleWriteableBitmap Generate(int width, int height)
        {
            return new SimpleWriteableBitmap(width, height);
        }
    }
}