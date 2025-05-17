using CommunityToolkit.Mvvm.ComponentModel;
using CommunityToolkit.Mvvm.Input;
using ScoreKeeper.Models;
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
    private ViewModelBase _currentPage;

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
        CurrentPage = new HomePageViewModel(Games);
    }

    [RelayCommand]
    private void OpenAddGames()
    {
        CurrentPage = new AddGameViewModel(Players, Games, OpenSingleGame);
    }

    [RelayCommand]
    private void OpenSingleGame(Game game)
    {
        // TODO create SingleGameViewModel with DataGrid!
        //CurrentPage = new SingleGameViewModel(game);
    }
}

