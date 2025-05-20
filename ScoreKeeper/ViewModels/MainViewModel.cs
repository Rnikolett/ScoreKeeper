using CommunityToolkit.Mvvm.ComponentModel;
using CommunityToolkit.Mvvm.Input;
using ScoreKeeper.Models;
using ScoreKeeper.Services;
using System.Collections.ObjectModel;

namespace ScoreKeeper.ViewModels;

public partial class MainViewModel : ViewModelBase
{
    //split view pane is open
    [ObservableProperty]
    private bool _isPaneOpen = true;

    [ObservableProperty]
    private bool _isPlayerList = true;
    [ObservableProperty]
    private bool _isHomePage = true;
    [ObservableProperty]
    private bool _isAddGame = true;

    [ObservableProperty]
    private ViewModelBase _currentPage = null!;

    public ObservableCollection<string> Players { get; } = [];

    public ObservableCollection<Game> Games { get; } = [];

    public MainViewModel()
    {
        OpenGames();
    }

    //trigger split view pane open/close
    [RelayCommand]
    private void TriggerPane()
    {
        IsPaneOpen = !IsPaneOpen;
    }

    [RelayCommand]
    private void OpenPlayers()
    {
        CurrentPage = new PlayerListViewModel(Players);
        SetTrue();
        IsPlayerList = !IsPlayerList;
    }

    [RelayCommand]
    private void OpenGames()
    {
        //previous games
        CurrentPage = new HomePageViewModel(Games, OpenSingleGame);
        SetTrue();
        IsHomePage = !IsHomePage;
    }

    [RelayCommand]
    private void OpenAddGames()
    {
        CurrentPage = new AddGameViewModel(Players, OpenSingleGame);
        SetTrue();
        IsAddGame = !IsAddGame;
    }

    [RelayCommand]
    private void OpenSingleGame(Game game)
    {
        if (!Games.Contains(game))
        {
            Games.Add(game);
            SaveGames();
        }
        SetTrue();
        CurrentPage = new SingleGameViewModel(game, SaveGames);
    }

    private async void SaveGames()
    {
        await FileService.SaveGames(Games);
    }

    private void SetTrue()
    {
        IsAddGame = true;
        IsHomePage = true;
        IsPlayerList = true;
    }
}
