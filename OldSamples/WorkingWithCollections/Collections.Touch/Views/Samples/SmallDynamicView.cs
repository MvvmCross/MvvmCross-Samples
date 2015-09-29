using Collections.Core.ViewModels.Samples.SmallDynamic;

namespace Collections.Touch
{
    public class SmallDynamicView : BaseDynamicKittenTableView
    {
        public SmallDynamicView()
        {
            Title = "Small Dynamic";
        }

		public SmallDynamicViewModel DynamicViewModel
		{
			get
			{
				return base.ViewModel as SmallDynamicViewModel;
			}
		}

        protected override void AddKittensPressed()
        {
			DynamicViewModel.AddKittenCommand.Execute(null);
        }

        protected override void KillKittensPressed()
        {
			DynamicViewModel.KillKittensCommand.Execute(null);
        }
    }
}