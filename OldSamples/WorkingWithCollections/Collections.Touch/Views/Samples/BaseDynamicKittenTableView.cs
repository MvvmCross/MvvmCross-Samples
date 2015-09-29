using System;
using MonoTouch.UIKit;

namespace Collections.Touch
{
    public abstract class BaseDynamicKittenTableView
        : BaseKittenTableView
    {
        private UIBarButtonItem _rightButton;

        public override void ViewDidLoad()
        {
            base.ViewDidLoad();

            _rightButton = new UIBarButtonItem(UIBarButtonSystemItem.Action);
            _rightButton.Clicked += HandleRightButtonClicked;
            NavigationItem.RightBarButtonItem = _rightButton;
        }

        private void HandleRightButtonClicked(object sender, EventArgs e)
        {
            var sheet = new UIActionSheet("Actions");
            sheet.AddButton("Add");
            sheet.AddButton("Kill");
            sheet.Clicked += HandleActionSheetButtonClicked;
            sheet.ShowFrom(_rightButton, true);
        }

        private void HandleActionSheetButtonClicked(object sender, UIButtonEventArgs e)
        {
            switch (e.ButtonIndex)
            {
                case 0:
                    AddKittensPressed();
                    break;
                case 1:
                    KillKittensPressed();
                    break;
            }
        }

        protected abstract void AddKittensPressed();
        protected abstract void KillKittensPressed();
    }
}