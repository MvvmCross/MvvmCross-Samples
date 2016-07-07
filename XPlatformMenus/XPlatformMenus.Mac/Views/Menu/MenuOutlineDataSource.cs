using System;
using System.Collections.Generic;
using AppKit;
using Foundation;

namespace XPlatformMenus.Mac.Views
{
	public class MenuOutlineDataSource : NSOutlineViewDataSource
	{
		public List<MenuObj> MenuObjs = new List<MenuObj>();

		public MenuOutlineDataSource()
		{
		}

		public override nint GetChildrenCount(NSOutlineView outlineView, NSObject item)
		{
			if (item == null)
			{
				return MenuObjs.Count;
			}
			else
			{
				return ((MenuObj)item).MenuObjs.Count;
			}
		}

		public override NSObject GetChild(NSOutlineView outlineView, nint childIndex, NSObject item)
		{
			if (item == null)
			{
				return MenuObjs[Convert.ToInt32(childIndex)];
			}
			else
			{
				return ((MenuObj)item).MenuObjs[Convert.ToInt32(childIndex)];
			}
		}

		public override bool ItemExpandable(NSOutlineView outlineView, NSObject item)
		{
			if (item == null)
			{
				return MenuObjs[0].IsMenuObjGroup;
			}
			else
			{
				return ((MenuObj)item).IsMenuObjGroup;
			}
		}
	}
}

