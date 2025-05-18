using Avalonia;
using Avalonia.Controls.ApplicationLifetimes;
using Avalonia.Data.Core.Plugins;
using Avalonia.Markup.Xaml;
using ScoreKeeper.Services;
using ScoreKeeper.ViewModels;
using ScoreKeeper.Views;
using System.Threading.Tasks;

namespace ScoreKeeper;

public partial class App : Application
{
    private readonly MainViewModel _mainViewModel = new();

    public override void Initialize()
    {
        AvaloniaXamlLoader.Load(this);
    }

    public override async void OnFrameworkInitializationCompleted()
    {
        // Line below is needed to remove Avalonia data validation.
        // Without this line you will get duplicate validations from both Avalonia and CT
        BindingPlugins.DataValidators.RemoveAt(0);

        if (ApplicationLifetime is IClassicDesktopStyleApplicationLifetime desktop)
        {
            desktop.MainWindow = new MainWindow
            {
                DataContext = _mainViewModel,
            };
        }
        else if (ApplicationLifetime is ISingleViewApplicationLifetime singleViewPlatform)
        {
            singleViewPlatform.MainView = new MainView
            {
                DataContext = _mainViewModel,
            };
        }

        await InitMainViewModelAsync();
        
        base.OnFrameworkInitializationCompleted();
    }

    private async Task InitMainViewModelAsync()
    {
        var playersLoaded = await FileService.LoadPlayers();
        if (playersLoaded != null)
        {
            foreach (string player in playersLoaded) 
            {
                _mainViewModel.Players.Add(player);
            }
        }

        var gamesLoaded = await FileService.LoadGames();
        if (gamesLoaded != null)
        {
            foreach(var game in gamesLoaded)
            {
                _mainViewModel.Games.Add(game);
            }
        }
    }
}
