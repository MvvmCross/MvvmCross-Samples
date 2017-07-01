# StarWars Sample!

This is a comprehensive sample that showcases some MvvmCross features and integrations with some other components.

It is currently available for Android and iOS. MacOS and UWP versions are planned as well.

Checkout the "Artwork" folder to look at the designs for those platforms.

## Features

### Shared (Core and all platforms)
- MvxCommands
- [MvxInteraction](https://www.mvvmcross.com/documentation/fundamentals/mvxinteraction)
- `INotifyTaskCompletion` from [Async.Ex](https://github.com/StephenCleary/AsyncEx) (note: use version 3.0.1 or latest with NetStandard)
- Localization through .resx files
- [IMvxNavigationService](https://www.mvvmcross.com/documentation/fundamentals/navigation)
- [Color plugin](https://www.mvvmcross.com/documentation/plugins/color)
- [Visibility plugin](https://www.mvvmcross.com/documentation/plugins/visibility)
- Super simple REST client
- Infinite lists
- Charts from [OxyPlot](http://www.oxyplot.org/)

### Android
- Support packages
- Fragments (also MvxFragmentsPresenter)
- `DrawerLayout`, `CoordinatorLayout`, `CollapsingToolbarLayout`, `MvxRecyclerView`, `MvxSwipeRefreshLayout`
- Custom MvxBindings
- Custom controls
- Infinite lists
- [Lottie animations](https://github.com/martijn00/LottieXamarin)
- DataBinding in .axml and .cs

### iOS
- [MvxIosViewPresenter](https://www.mvvmcross.com/documentation/platform/ios-view-presenter) (tabs)
- `MvxUIRefreshControl`, `MvxTableViewCell`, `MvxSimpleTableViewSource`
- Custom MvxBindings
- Custom controls
- Coded UIs using [FluentLayout](https://github.com/FluentLayout/Cirrious.FluentLayout)
- Infinite lists
- [Lottie animations](https://github.com/martijn00/LottieXamarin)
- DataBinding in .cs
