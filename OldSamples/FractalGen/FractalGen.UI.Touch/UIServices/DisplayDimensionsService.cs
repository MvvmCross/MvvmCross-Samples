using FractalGen.Core.Services.PlatformSpecific;

namespace FractalGen.UI.Touch.UIServices
{
    public class DisplayDimensionsService : IDisplayDimensionsService
    {
        public DisplayDimensionsService()
        {
			if (AppDelegate.IsPhone)
			{
				Height = 640;
				// should do more here really...
				Width = 1156;
			}
			else
			{
				Height = 1536;
				Width = 2048;
        	}
		}

        public int Height { get; set; }
        public int Width { get; set; }
    }
}