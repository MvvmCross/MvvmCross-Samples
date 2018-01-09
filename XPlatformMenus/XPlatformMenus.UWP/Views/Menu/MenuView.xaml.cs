using System.Collections.Generic;
using Windows.UI.Xaml.Automation;
using Windows.UI.Xaml.Controls;
using Windows.UI.Xaml.Navigation;
using XPlatformMenus.Core.ViewModels;
using XPlatformMenus.UWP.Controls;
using MvvmCross.Uwp.Attributes;

namespace XPlatformMenus.UWP.Views
{
    [MvxRegionPresentation("MenuContent")]
    public sealed partial class MenuView
	{
		public new MenuViewModel ViewModel
		{
			get { return (MenuViewModel)base.ViewModel; }
			set { base.ViewModel = value; }
		}

		public MenuView()
		{
			InitializeComponent();
		}

		protected override void OnNavigatedTo(NavigationEventArgs e)
		{
			base.OnNavigatedTo(e);

			NavMenuList.ItemsSource = new List<NavMenuItem>(
				new[]
				{
					new NavMenuItem
					{
						Symbol = Symbol.Home,
						Label = "Home",
						Command = ViewModel.ShowHomeCommand
					},
					new NavMenuItem
					{
						Symbol = Symbol.Help,
						Label = "Help",
						Command = ViewModel.ShowHelpCommand
					},
					new NavMenuItem
					{
						Symbol = Symbol.Setting,
						Label = "Settings",
						Command = ViewModel.ShowSettingCommand
					}
				});
		}

		/// <summary>
		/// Navigate to the Page for the selected <paramref name="listViewItem"/>.
		/// </summary>
		/// <param name="sender"></param>
		/// <param name="listViewItem"></param>
		private void NavMenuList_ItemInvoked(object sender, ListViewItem listViewItem)
		{
			var item = (NavMenuItem)((NavMenuListView)sender).ItemFromContainer(listViewItem);
			item?.Command?.Execute(item.Parameters);
		}

		/// <summary>
		/// Enable accessibility on each nav menu item by setting the AutomationProperties.Name on each container
		/// using the associated Label of each item.
		/// </summary>
		/// <param name="sender"></param>
		/// <param name="args"></param>
		private void NavMenuItemContainerContentChanging(ListViewBase sender, ContainerContentChangingEventArgs args)
		{
			if (!args.InRecycleQueue && args.Item != null && args.Item is NavMenuItem)
			{
				args.ItemContainer.SetValue(AutomationProperties.NameProperty, ((NavMenuItem)args.Item).Label);
			}
			else
			{
				args.ItemContainer.ClearValue(AutomationProperties.NameProperty);
			}
		}
	}
}
