using MvvmCross.Forms.Presenters.Attributes;
using MvvmCross.Forms.Views;
using StarWarsSample.Core.ViewModels;

namespace StarWarsSample.Forms.UI.Views
{
    [MvxMasterDetailPagePresentation(MasterDetailPosition.Detail, NoHistory = false)]
	public partial class PersonPage : MvxContentPage<PersonViewModel>
	{
		public PersonPage ()
		{
			InitializeComponent ();
		}
	}
}