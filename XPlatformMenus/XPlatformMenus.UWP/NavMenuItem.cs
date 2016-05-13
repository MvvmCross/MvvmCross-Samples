using System.Windows.Input;
using Windows.UI.Xaml.Controls;

namespace XPlatformMenus.UWP
{
	/// <summary>
	/// Data to represent an item in the nav menu.
	/// </summary>
	public class NavMenuItem
	{
		public string Label { get; set; }
		public Symbol Symbol { get; set; }
		public char SymbolAsChar
		{
			get
			{
				return (char)Symbol;
			}
		}

		public ICommand Command { get; set; }
		public object Parameters { get; set; }
	}
}
