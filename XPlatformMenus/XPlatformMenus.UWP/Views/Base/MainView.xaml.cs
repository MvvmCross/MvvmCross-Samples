using Windows.Foundation;
using Windows.UI.Xaml;
using Windows.UI.Xaml.Controls;
using XPlatformMenus.Core.ViewModels;

namespace XPlatformMenus.UWP.Views
{
	public sealed partial class MainView
	{
		public new MainViewModel ViewModel
		{
			get { return (MainViewModel)base.ViewModel; }
			set { base.ViewModel = value; }
		}

		public MainView()
		{
			InitializeComponent();
		}

		private void MainView_OnLoaded(object sender, RoutedEventArgs e)
		{
			ViewModel.ShowMenu();            
		}

        public void PopToRoot()
        {
            var frame = PageContent;
            while (frame.CanGoBack)
            {
                frame.GoBack();
            }
        }

		#region SplitView

		public Rect TogglePaneButtonRect
		{
			get;
			private set;
		}

		/// <summary>
		/// An event to notify listeners when the hamburger button may occlude other content in the app.
		/// The custom "PageHeader" user control is using this.
		/// </summary>
		public event TypedEventHandler<MainView, Rect> TogglePaneButtonRectChanged;

		/// <summary>
		/// Public method to allow pages to open SplitView's pane.
		/// Used for custom app shortcuts like navigating left from page's left-most item
		/// </summary>
		public void OpenNavePane()
		{
			TogglePaneButton.IsChecked = true;
			//NavPaneDivider.Visibility = Visibility.Visible;
		}

		/// <summary>
		/// Hides divider when nav pane is closed.
		/// </summary>
		/// <param name="sender"></param>
		/// <param name="args"></param>
		private void RootSplitView_PaneClosed(SplitView sender, object args)
		{
			//NavPaneDivider.Visibility = Visibility.Collapsed;
		}

		/// <summary>
		/// Callback when the SplitView's Pane is toggled closed.  When the Pane is not visible
		/// then the floating hamburger may be occluding other content in the app unless it is aware.
		/// </summary>
		/// <param name="sender"></param>
		/// <param name="e"></param>
		private void TogglePaneButton_Unchecked(object sender, RoutedEventArgs e)
		{
			CheckTogglePaneButtonSizeChanged();
		}

		/// <summary>
		/// Callback when the SplitView's Pane is toggled opened.
		/// Restores divider's visibility and ensures that margins around the floating hamburger are correctly set.
		/// </summary>
		/// <param name="sender"></param>
		/// <param name="e"></param>
		private void TogglePaneButton_Checked(object sender, RoutedEventArgs e)
		{
			//NavPaneDivider.Visibility = Visibility.Visible;
			CheckTogglePaneButtonSizeChanged();
		}

		/// <summary>
		/// Check for the conditions where the navigation pane does not occupy the space under the floating
		/// hamburger button and trigger the event.
		/// </summary>
		private void CheckTogglePaneButtonSizeChanged()
		{
			if (RootSplitView.DisplayMode == SplitViewDisplayMode.Inline ||
				RootSplitView.DisplayMode == SplitViewDisplayMode.Overlay)
			{
				var transform = TogglePaneButton.TransformToVisual(this);
				var rect = transform.TransformBounds(new Rect(0, 0, TogglePaneButton.ActualWidth, TogglePaneButton.ActualHeight));
				TogglePaneButtonRect = rect;
			}
			else
			{
				TogglePaneButtonRect = new Rect();
			}

			var handler = TogglePaneButtonRectChanged;
			if (handler != null)
			{
				// handler(this, this.TogglePaneButtonRect);
				handler.DynamicInvoke(this, TogglePaneButtonRect);
			}
		}

		#endregion
	}
}
