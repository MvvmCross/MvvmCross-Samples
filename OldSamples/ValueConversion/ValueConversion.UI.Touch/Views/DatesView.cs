using ValueConversion.Core.ViewModels;
using Cirrious.MvvmCross.Touch.Views;
using Cirrious.MvvmCross.Binding.BindingContext;

namespace ValueConversion.UI.Touch
{
    public partial class DatesView : MvxViewController
    {
        public DatesView() : base("DatesView", null)
        {
        }

        public override void ViewDidLoad()
        {
            base.ViewDidLoad();

            this.CreateBinding(TheDateLabel).To<DatesViewModel>(vm => vm.TheDate).WithConversion("TimeAgo").Apply();
            this.CreateBinding(OldDateLabel).To<DatesViewModel>(vm => vm.OldDate).WithConversion("TimeAgo").Apply();
            this.CreateBinding(VeryOldDateLabel)
                .To<DatesViewModel>(vm => vm.VeryOldDate)
                .WithConversion("TimeAgo")
                .Apply();

            this.CreateBinding(SimpleDateLabel).To<DatesViewModel>(vm => vm.TheDate).Apply();
            this.CreateBinding(SimpleOldDateLabel).To<DatesViewModel>(vm => vm.OldDate).Apply();
            this.CreateBinding(SimpleVeryOldDateLabel).To<DatesViewModel>(vm => vm.VeryOldDate).Apply();
        }
    }
}