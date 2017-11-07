MvvmCross-Samples
==========

👀 Check out [mvvmcross.com](https://www.mvvmcross.com) to get started with MvvmCross 👀

MvvmCross is a cross-platform MVVM framework. It enables developers to create apps using the MVVM pattern on *Xamarin.iOS, Xamarin.Android, Xamarin.Mac, Xamarin.Forms, Universal Windows Platform (UWP) and Windows Presentation Framework (WPF)*. This allows for better code sharing by allowing you to share behavior and business logic between platforms.

Among the features MvvmCross provides are:

- ViewModel to View bindings using own customizable binding engine, which allows you to create own binding definitions for own custom views
- ViewModel to ViewModel navigation, helps you share behavior on how and when to navigate
- Inversion of Control through Dependency Injection and Property Injection
- Plugin framework, which lets you plug-in cool stuff like GPS Location, Localization, Sensors, Binding Extensions and a huge selection of 3rd party community plug-ins

MvvmCross is extendable by you. We strive to let as much code be configurable and overridable, to let the developer decide how they want to use the framework. However, the framework is very usable without doing anything.

<hr />

See the official [MvvmCross blog](https://www.mvvmcross.com/blog/) for the latest news!


## Filing issues

We strive to keep the GitHub issues list for bugs, features and other important project management tasks. If you have questions please see the [Questions & support section below](#questions--support).

The best way to get your bug fixed is to be as detailed as you can be about the problem.
Providing a minimal git repository with a project showing how to reproduce the problem is ideal. Here are a couple of questions you can answer before filing a bug.

1. Did you try find your answer in the [documentation](https://www.mvvmcross.com)
2. Did you include a snippet of the broken code in the issue?
3. Can you reproduce the problem in a brand new project?
4. What are the _*EXACT*_ steps to reproduce this problem?
5. What platform(s) are you experiencing the problem on?

Remember GitHub issues support [markdown](http://github.github.com/github-flavored-markdown/). When filing bugs please make sure you check the formatting of the issue before clicking submit.

## Contributing code

We are happy to receive Pull Requests adding new features and solving bugs. As for new features, please contact us before doing major work. To ensure you are not working on something that will be rejected due to not fitting into the roadmap or ideal of the framework.

### Git setup

Since Windows and UNIX-based systems differ in terms of line endings, it is a very good idea to configure git autocrlf settings.

On *Windows* we recommend setting `core.autocrlf` to `true`.

```
git config --global core.autocrlf true
```

On *Mac* we recommend setting `core.autocrlf` to `input`.

```
git config --global core.autocrlf input
```

### Code style guidelines

Please use 4 spaces for indentation.

Otherwise default ReSharper C# code style applies.

### Project Workflow

Our workflow is loosely based on [Github Flow](http://scottchacon.com/2011/08/31/github-flow.html).

### Submitting Pull Requests

Make sure you can build the code. Familiarize yourself with the project workflow and our coding conventions. If you don't know what a pull request is
read this https://help.github.com/articles/using-pull-requests.

Before submitting a feature or substantial code contribution please discuss it with the team and ensure it follows the MvvmCross roadmap.
Note that code submissions will be reviewed and tested. Only code that meets quality and design/roadmap appropriateness will be merged into the source. [Don't "Push" Your Pull Requests](https://www.igvita.com/2011/12/19/dont-push-your-pull-requests/)

## Questions & support

* [StackOverflow](http://stackoverflow.com/questions/tagged/mvvmcross)
* [Xamarin forums](http://forums.xamarin.com)
* [Slack](https://xamarinchat.herokuapp.com/) join the #mvvmcross channel after you are in

**When creating a new sample, please do the following:**

 - Use NuGets for all external references
 - Provide a Readme.md file describing the sample
 - Provide a screenshots of the sample

### Acknowledgements


Licensing
---------

This project is developed and distributed under the [Microsoft Public License (MS-PL)](http://opensource.org/licenses/ms-pl.html).
