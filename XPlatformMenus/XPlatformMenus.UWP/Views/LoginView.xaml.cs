using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Runtime.InteropServices.WindowsRuntime;
using Windows.Foundation;
using Windows.Foundation.Collections;
using Windows.UI.Xaml;
using Windows.UI.Xaml.Controls;
using Windows.UI.Xaml.Controls.Primitives;
using Windows.UI.Xaml.Data;
using Windows.UI.Xaml.Input;
using Windows.UI.Xaml.Media;
using Windows.UI.Xaml.Navigation;
using XPlatformMenus.Core.ViewModels;

namespace XPlatformMenus.UWP.Views
{
	public sealed partial class LoginView
	{
		public new LoginViewModel ViewModel
		{
			get { return (LoginViewModel)base.ViewModel; }
			set { base.ViewModel = value; }
		}

		public LoginView()
		{
			InitializeComponent();
		}
	}
	
}
