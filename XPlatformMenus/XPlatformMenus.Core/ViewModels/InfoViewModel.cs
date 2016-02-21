namespace XPlatformMenus.Core.ViewModels
{
	public class InfoViewModel : BaseViewModel
    {
        public InfoViewModel()
        {
            Info = "This is info for you...";
        }

	    public string Info { get; private set; }
    }
}