using System;
using Cirrious.FluentLayouts.Touch;
using MvvmCross.Binding.BindingContext;
using StarWarsSample.Models;
using UIKit;

namespace StarWarsSample.iOS.Views.Cells
{
    public class PeopleTableViewCell : BaseTableViewCell
    {
        private UILabel _lblName;

        public PeopleTableViewCell(IntPtr handle) : base(handle)
        {
        }

        protected override void CreateView()
        {
            base.CreateView();

            _lblName = new UILabel
            {
                TextColor = UIColor.Red
            };

            BackgroundColor = UIColor.Clear;
            //ContentView.BackgroundColor = UIColor.Clear;
            ContentView.AddSubview(_lblName);
            ContentView.SubviewsDoNotTranslateAutoresizingMaskIntoConstraints();

            this.DelayBind(
                () =>
            {
                var set = this.CreateBindingSet<PeopleTableViewCell, Person>();
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
                //_lblName.WithSameCenterY(ContentView),
                _lblName.AtRightOf(ContentView, 9f)
            );
        }
    }
}
