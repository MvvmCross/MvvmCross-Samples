using System;
using System.Collections.Generic;
using System.Text;

namespace XPlatformMenusTabs.iOS.Interfaces
{
    public interface ITabBarPresenterHost
    {
        ITabBarPresenter TabBarPresenter { get; set; }
    }
}
