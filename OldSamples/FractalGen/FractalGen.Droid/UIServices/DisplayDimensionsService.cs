using FractalGen.Core.Services.PlatformSpecific;

namespace FractalGen.UI.Droid.UIServices
{
    public class DisplayDimensionsService : IDisplayDimensionsService
    {
        public DisplayDimensionsService()
        {
            Height = Width = 600;
        }

        public int Height { get; set; }
        public int Width { get; set; }
    }
}