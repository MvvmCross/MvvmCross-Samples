namespace XPlatformMenus.Core.ViewModels
{
    public class HomeViewModel : BaseVm
    {
        public HomeViewModel() 
        {
            Recycler = new RecyclerViewModel();
        }

        /// <summary>Gets the recycler.</summary>
        /// <value>The recycler.</value>
        public RecyclerViewModel Recycler { get; private set; }
    }
}