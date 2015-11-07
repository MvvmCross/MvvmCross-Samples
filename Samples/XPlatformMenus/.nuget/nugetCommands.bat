REM Pull in the core packages
nuget install MvvmCross -SolutionDirectory ..\ -Prerelease
nuget install MvvmCross.PortableSupport -SolutionDirectory ..\ -Version 3.5.2-alpha2

REM pull in the Android Support packages
nuget install Xamarin.Android.Support.Design -SolutionDirectory ..\ -Version 22.2.1.0
nuget install Xamarin.Android.Support.v4 -SolutionDirectory ..\ -Version 22.2.1.0
nuget install Xamarin.Android.Support.v7.AppCompat -SolutionDirectory ..\ -Version 22.2.1.0
nuget install Xamarin.Android.Support.v7.RecyclerView -SolutionDirectory ..\ -Version 22.2.1.0

REM Pull in any other dependencies
nuget install MvvmCross.HotTuna.Plugin.Json -SolutionDirectory ..\ -Version 4.0.0-beta4


nuget update ..\XPlatformMenus.sln MvvmCross
nuget update ..\XPlatformMenus.sln MvvmCross.PortableSupport
nuget update ..\XPlatformMenus.sln Xamarin.Android.Support.Design
nuget update ..\XPlatformMenus.sln Xamarin.Android.Support.v4
nuget update ..\XPlatformMenus.sln Xamarin.Android.Support.v7.AppCompat
nuget update ..\XPlatformMenus.sln Xamarin.Android.Support.v7.RecyclerView
nuget update ..\XPlatformMenus.sln MvvmCross.HotTuna.Plugin.Json

PAUSE