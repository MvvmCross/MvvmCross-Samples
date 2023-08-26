using Microsoft.Extensions.Logging;
using MvvmCross.Commands;
using MvvmCross.Navigation;
using MvvmCross.ViewModels;

namespace Core.ViewModels;

public class MainViewModel : MvxViewModel
{
    private readonly ILogger<MainViewModel> _logger;
    private readonly IMvxNavigationService _navigationService;
    private string _hello = "Hello from MvvmCross";
    private int _clicks;

    public string Hello
    {
        get => _hello;
        set => SetProperty(ref _hello, value);
    }

    public int Clicks
    {
        get => _clicks;
        set => SetProperty(ref _clicks, value, () => RaisePropertyChanged(nameof(ClickText)));
    }

    public string ClickText => $"Button Clicked {Clicks} Times";
    public string NavigateText => "Navigate to Detail";
    
    public IMvxCommand ClickCommand { get; }
    
    public IMvxAsyncCommand NavigateCommand { get; }

    public MainViewModel(ILogger<MainViewModel> logger, IMvxNavigationService navigationService)
    {
        _logger = logger;
        _navigationService = navigationService;
        ClickCommand = new MvxCommand(DoClick);
        NavigateCommand = new MvxAsyncCommand(DoNavigate);
    }

    private Task DoNavigate()
    {
        _logger.LogInformation("Navigating to Details");
        return _navigationService.Navigate<DetailViewModel, DetailParameters>(new DetailParameters(Clicks));
    }

    private void DoClick()
    {
        Clicks++;
        _logger.LogInformation("Clicked {ClickTimes}", Clicks);
    }
}