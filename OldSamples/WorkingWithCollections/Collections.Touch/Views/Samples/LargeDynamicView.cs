using Collections.Core.ViewModels.Samples.LargeDynamic;

namespace Collections.Touch
{
    public class LargeDynamicView : BaseDynamicKittenTableView
    {
        public LargeDynamicView()
        {
            Title = "Large Dynamic";
        }

		public LargeDynamicViewModel DynamicViewModel
		{
			get
			{
				return base.ViewModel as LargeDynamicViewModel;
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