using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using MonoTouch.Foundation;
using MonoTouch.UIKit;
using System.Collections.Specialized;

namespace Tutorial.UI.Touch
{
    [Preserve]
    public class LinkerIncludePlease
    {
        public void IncludeStuff()
        {
			UITextField textField = null;
			textField.Text = textField.Text + "";

			UIButton button = null;
			button.TouchUpInside += (sender,  e) => {};

			INotifyCollectionChanged c = null;
			c.CollectionChanged += (sender, e) => {};
        }
    }
}
