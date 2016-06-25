using System;
using AppKit;

namespace XPlatformMenus.Mac.Views
{
	public class MenuOutlineDelegate : NSOutlineViewDelegate
	{
		private const string CellIdentifier = "MenuCell";

		private MenuOutlineDataSource DataSource;

		public MenuOutlineDelegate(MenuOutlineDataSource dataSource)
		{
			DataSource = dataSource;
		}

		public override bool IsGroupItem(NSOutlineView outlineView, Foundation.NSObject item)
		{
			return false;
		}
		/*
		public override NSView GetView(NSOutlineView outlineView, NSTableColumn tableColumn, Foundation.NSObject item)
		{
			NSTextView view = (NSTextView)outlineView.MakeView(
				CellIdentifier, this);
			if (view == null)
			{
				view = new NSTextView();
				view.Identifier = CellIdentifier;
				view.BackgroundColor = NSColor.Clear;
				view.Selectable = true;
				view.Editable = false;
			}

			var menuObj = item as MenuObj;
			view.Value = menuObj.Title;
			return view;
		}
		*/
	}
}

