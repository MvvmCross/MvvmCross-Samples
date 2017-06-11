using System;
using Cirrious.FluentLayouts.Touch;
using MvvmCross.Binding.BindingContext;
using StarWarsSample.Models;
using UIKit;

namespace StarWarsSample.iOS.Views.Cells
{
    public class PlanetTableViewCell : BaseTableViewCell
    {
        private UILabel _lblName;

        public PlanetTableViewCell(IntPtr handle) : base(handle)
        {
        }

        protected override void CreateView()
        {
            base.CreateView();

            _lblName = new UILabel
            {
                TextColor = UIColor.Red,
                Font = UIFont.SystemFontOfSize(15f, UIFontWeight.Semibold)
            };

            BackgroundColor = UIColor.Clear;
            ContentView.AddSubview(_lblName);
            ContentView.SubviewsDoNotTranslateAutoresizingMaskIntoConstraints();

            this.DelayBind(
                () =>
                {
                    var set = this.CreateBindingSet<PlanetTableViewCell, Person>();
                    set.Bind(_lblName).To(vm => vm.Name);
                    set.Apply();
                });
        }

        protected override void CreateConstraints()
        {
            base.CreateConstraints();

            ContentView.AddConstraints(
                _lblName.AtLeftOf(ContentView, 9f),
                _lblName.AtTopOf(ContentView),
                _lblName.AtBottomOf(ContentView),
                _lblName.AtRightOf(ContentView, 9f)
            );
        }
    }
}
