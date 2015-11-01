namespace Cirrious.Conference.Core.ViewModels
{
    public class SponsorsViewModel
        : BaseSponsorsViewModel
    {
        public SponsorsViewModel()
        {
            LoadFrom(Service.Sponsors.Values);
        }
    }
}