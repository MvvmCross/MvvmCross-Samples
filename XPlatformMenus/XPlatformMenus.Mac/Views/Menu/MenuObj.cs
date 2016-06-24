using System;
using System.Collections.Generic;
using Foundation;

namespace XPlatformMenus.Mac.Views
{
	public class MenuObj : NSObject
	{
		public List<MenuObj> MenuObjs = new List<MenuObj>();

		public string Title { get; set; }
		public bool IsMenuObjGroup
		{
			get { return (MenuObjs.Count > 0); }
		}
		public MenuObj(string title)
		{
			Title = title;
		}
	}
}

