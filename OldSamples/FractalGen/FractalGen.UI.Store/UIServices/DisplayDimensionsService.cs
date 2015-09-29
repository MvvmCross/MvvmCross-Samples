using FractalGen.Core.Services.PlatformSpecific;
using Windows.UI.Xaml;

namespace FractalGen.UI.Store.UIServices
{
    public class DisplayDimensionsService : IDisplayDimensionsService
    {
        public DisplayDimensionsService()
        {
            Height = (int) (Window.Current.Bounds.Height);
            Width = (int) (Window.Current.Bounds.Width);
        }

        public int Height { get; set; }
        public int Width { get; set; }
    }
}