namespace XPlatformMenus.Core.ViewModels
{
    public class ExampleViewPagerViewModel : BaseVm
    {
        public RecyclerViewModel Recycler { get; private set; }

        public ExampleViewPagerViewModel()
        {
            Recycler = new RecyclerViewModel();
        }
    }
}