using System;
using Cirrious.FluentLayouts.Touch;
using MvvmCross.Binding.BindingContext;
using MvvmCross.iOS.Views;
using MvvmCross.iOS.Views.Presenters.Attributes;
using StarWarsSample.iOS.Sources;
using StarWarsSample.Resources;
using StarWarsSample.ViewModels;
using UIKit;

namespace StarWarsSample.iOS.Views
{
    [MvxTabPresentation(WrapInNavigationController = true, TabName = "Target: People", TabIconName = "ic_people")]
    public class PeopleView : MvxViewController<PeopleViewModel>
    {
        private UIImageView _imgBackground;
        private UITableView _tableView;
        private PeopleTableSource _source;

        public override void ViewDidLoad()
        {
            base.ViewDidLoad();

            Title = Strings.TargetPeople;

            EdgesForExtendedLayout = UIRectEdge.None;

            View.BackgroundColor = UIColor.Clear;

            _tableView = new UITableView();
            _tableView.BackgroundColor = UIColor.Clear;
            _tableView.RowHeight = UITableView.AutomaticDimension;
            _tableView.EstimatedRowHeight = 44f;

            _imgBackground = new UIImageView(UIImage.FromBundle("Background.jpg"))
            {
                ContentMode = UIViewContentMode.ScaleAspectFill
            };

            _source = new PeopleTableSource(_tableView);
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

            var set = this.CreateBindingSet<PeopleView, PeopleViewModel>();
            set.Bind(this).For("NetworkIndicator").To(vm => vm.LoadPeopleTask.IsNotCompleted).WithFallback(false);
            set.Bind(this).For("NetworkIndicator").To(vm => vm.FetchPeopleTask.IsNotCompleted).WithFallback(false);
            set.Bind(_source).For(v => v.ItemsSource).To(vm => vm.People);
            set.Bind(_source).For(v => v.SelectionChangedCommand).To(vm => vm.PersonSelectedCommand);
            set.Bind(_source).For(v => v.FetchCommand).To(vm => vm.FetchPeopleCommand);
            set.Apply();
        }
    }
}
