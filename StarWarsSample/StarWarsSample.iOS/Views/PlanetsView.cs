using Cirrious.FluentLayouts.Touch;
using MvvmCross.Binding.BindingContext;
using MvvmCross.Platforms.Ios.Presenters.Attributes;
using MvvmCross.Platforms.Ios.Views;
using StarWarsSample.Core.Resources;
using StarWarsSample.Core.ViewModels;
using StarWarsSample.iOS.Sources;
using UIKit;

namespace StarWarsSample.iOS.Views
{
    [MvxTabPresentation(WrapInNavigationController = true, TabName = "Target: Planets", TabIconName = "ic_planets")]
    public class PlanetsView : MvxViewController<PlanetsViewModel>
    {
        private UIImageView _imgBackground;
        private MvxUIRefreshControl _refreshControl;
        private UITableView _tableView;
        private PlanetsTableViewSource _source;

        public PlanetsView()
        {
        }

        public override void ViewDidLoad()
        {
            base.ViewDidLoad();

            Title = Strings.TargetPlanets;

            EdgesForExtendedLayout = UIRectEdge.None;

            View.BackgroundColor = UIColor.Clear;

            _refreshControl = new MvxUIRefreshControl();

            _tableView = new UITableView();
            _tableView.BackgroundColor = UIColor.Clear;
            _tableView.RowHeight = UITableView.AutomaticDimension;
            _tableView.EstimatedRowHeight = 44f;
            _tableView.AddSubview(_refreshControl);

            _imgBackground = new UIImageView(UIImage.FromBundle("Background.jpg"))
            {
                ContentMode = UIViewContentMode.ScaleAspectFill
            };

            _source = new PlanetsTableViewSource(_tableView);
            _tableView.Source = _source;

            View.AddSubviews(_tableView, _imgBackground);
            View.SubviewsDoNotTranslateAutoresizingMaskIntoConstraints();

            View.AddConstraints(
                _imgBackground.AtLeftOf(View),
                _imgBackground.AtTopOf(View),
                _imgBackground.AtBottomOf(View),
                _imgBackground.AtRightOf(View),

                _tableView.AtLeftOf(View),
                _tableView.AtTopOf(View),
                _tableView.AtBottomOf(View),
                _tableView.AtRightOf(View)
            );

            View.BringSubviewToFront(_tableView);

            var set = this.CreateBindingSet<PlanetsView, PlanetsViewModel>();
            set.Bind(this).For("NetworkIndicator").To(vm => vm.FetchPlanetsTask.IsNotCompleted).WithFallback(false);
            set.Bind(_refreshControl).For(r => r.IsRefreshing).To(vm => vm.LoadPlanetsTask.IsNotCompleted).WithFallback(false);
            set.Bind(_refreshControl).For(r => r.RefreshCommand).To(vm => vm.RefreshPlanetsCommand);
            set.Bind(_source).For(v => v.ItemsSource).To(vm => vm.Planets);
            set.Bind(_source).For(v => v.SelectionChangedCommand).To(vm => vm.PlanetSelectedCommand);
            set.Bind(_source).For(v => v.FetchCommand).To(vm => vm.FetchPlanetCommand);
            set.Apply();
        }
    }
}
