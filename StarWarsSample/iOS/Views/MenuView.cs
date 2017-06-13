using System;
using Cirrious.FluentLayouts.Touch;
using MvvmCross.Binding.BindingContext;
using MvvmCross.Binding.iOS.Views.Gestures;
using MvvmCross.iOS.Views;
using MvvmCross.iOS.Views.Presenters.Attributes;
using StarWarsSample.iOS.CustomControls;
using StarWarsSample.Resources;
using StarWarsSample.ViewModels;
using TZStackView;
using UIKit;

namespace StarWarsSample.iOS.Views
{
    [MvxTabPresentation(WrapInNavigationController = true, TabName = "Menu", TabIconName = "ic_menu")]
    public class MenuView : MvxViewController<MenuViewModel>
    {
        private StackView _options;

        private MenuOption _optionStatistics, _optionOther1, _optionOther2;

        public MenuView()
        {
        }

        public override void ViewDidLoad()
        {
            base.ViewDidLoad();

            View.BackgroundColor = UIColor.Black;

            Title = Strings.Menu;

            _options = new StackView
            {
                Axis = UILayoutConstraintAxis.Vertical
            };
            _optionStatistics = new MenuOption();
            _optionStatistics.Label.Text = Strings.Statistics;
            _optionOther1 = new MenuOption();
            _optionOther1.Label.Text = Strings.AnotherOption;
            _optionOther2 = new MenuOption();
            _optionOther2.Label.Text = Strings.AnotherOption;

            View.AddSubview(_options);
            View.SubviewsDoNotTranslateAutoresizingMaskIntoConstraints();

            _options.AddArrangedSubview(_optionStatistics);
            _options.AddArrangedSubview(_optionOther1);
            _options.AddArrangedSubview(_optionOther2);

            View.AddConstraints(
                _options.AtLeftOf(View),
                _options.AtTopOf(View),
                _options.AtRightOf(View)
            );

            var set = this.CreateBindingSet<MenuView, MenuViewModel>();
            set.Bind(_optionStatistics.Tap()).For(g => g.Command).To(vm => vm.ShowStatusCommand);
            set.Apply();
        }
    }
}
