using CommunityToolkit.Mvvm.ComponentModel;
using CommunityToolkit.Mvvm.Input;
using ScoreKeeper.Models;
using ScoreKeeper.Services;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;

namespace ScoreKeeper.ViewModels;

public partial class MainViewModel : ViewModelBase
{
    //split view pane is open
    [ObservableProperty]
    private bool _isPaneOpen = true;

    [ObservableProperty]
    private ViewModelBase _currentPage = null!;

    public ObservableCollection<string> Players { get; } = [];

    public ObservableCollection<Game> Games { get; } = [];

    public MainViewModel()
    {
        OpenPlayers();
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
    }
    
    [RelayCommand]
    private void OpenGames()
    {
        CurrentPage = new HomePageViewModel(Games, OpenSingleGame);
    }

    [RelayCommand]
    private void OpenAddGames()
    {
        CurrentPage = new AddGameViewModel(Players, OpenSingleGame);
    }

    [RelayCommand]
    private void OpenSingleGame(Game game)
    {
        if (!Games.Contains(game))
        {
            Games.Add(game);
            SaveGames();
        }

        CurrentPage = new SingleGameViewModel(game, SaveGames);
    }

    private async void SaveGames()
    {
        await FileService.SaveGames(Games);
    }
    // TODO Disable buttons for active Views
    // eg.: you shoudn't switch to previous games when you're already in that page, currently it's possible which results in reconstructing the viewModel
}

