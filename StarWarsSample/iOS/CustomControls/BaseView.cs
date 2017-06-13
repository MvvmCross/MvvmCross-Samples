using System;
using UIKit;

namespace StarWarsSample.iOS.CustomControls
{
    public class BaseView : UIView
    {
        private bool _didSetupConstraints;

        public BaseView()
        {
            RunLifecycle();
        }

        protected void RunLifecycle()
        {
            CreateViews();

            SetNeedsUpdateConstraints();
        }

        protected virtual void CreateViews()
        {

        }

        public override sealed void UpdateConstraints()
        {
            if (!_didSetupConstraints)
            {
                CreateConstraints();

                _didSetupConstraints = true;
            }
            base.UpdateConstraints();
        }

        protected virtual void CreateConstraints()
        {

        }
    }
}
