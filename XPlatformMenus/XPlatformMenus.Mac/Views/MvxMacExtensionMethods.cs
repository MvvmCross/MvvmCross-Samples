using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using AppKit;
using Foundation;

namespace XPlatformMenus.Mac.Views
{
    public static class MvxMacExtensionMethods
    {
        public static bool HasRegionAttribute(this Type view)
        {
            var attributes = view
                .GetCustomAttributes(typeof(MvxRegionAttribute), true);
            return attributes.Any();
        }

        public static string GetRegionName(this Type view)
        {
            var attributes = view
                .GetCustomAttributes(typeof(MvxRegionAttribute), true);

            if (!attributes.Any())
                throw new InvalidOperationException("The MvxMacView has no region attribute");

            return ((MvxRegionAttribute)attributes.First()).Name;
        }

		public static void SwapSubView(this NSView containerView, NSView targetView)
		{
			// we could add spacing to this 

			while (containerView.Subviews.Any())
			{
				containerView.Subviews[0].RemoveFromSuperview();
			}
			containerView.RemoveConstraints(containerView.Constraints);

			targetView.TranslatesAutoresizingMaskIntoConstraints = false;
			containerView.AddSubview(targetView);
			NSDictionary views = NSDictionary.FromObjectAndKey(targetView, new NSString("target"));
			containerView.AddConstraints(NSLayoutConstraint.FromVisualFormat(
				"H:|[target]|", NSLayoutFormatOptions.None, null, views));
			containerView.AddConstraints(NSLayoutConstraint.FromVisualFormat(
				"V:|[target]|", NSLayoutFormatOptions.None, null, views));
		}
    }
}
