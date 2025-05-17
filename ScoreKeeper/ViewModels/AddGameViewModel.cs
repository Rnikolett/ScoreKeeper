using CommunityToolkit.Mvvm.ComponentModel;
using CommunityToolkit.Mvvm.Input;
using ScoreKeeper.Models;
using ScoreKeeper.Services;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;

namespace ScoreKeeper.ViewModels
{
    public partial class AddGameViewModel : ViewModelBase
    {
        private readonly Action<Game> _openGame;

        [ObservableProperty]
        private string? _title;

        [ObservableProperty]
        private int? _countRounds;

        public ObservableCollection<Round> Rounds { get; } = [];
        
        public ObservableCollection<Game> Games { get; }

        public ObservableCollection<CheckablePlayer> CheckablePlayers { get; }

        public AddGameViewModel(
            ObservableCollection<string> players, 
            ObservableCollection<Game> games,
            Action<Game> openGame
        )
        {
            _openGame = openGame;
            CheckablePlayers = [.. players.Select(p => new CheckablePlayer(p))];
            Games = games;
        }

        [RelayCommand]
        private async void CreateGame()
        {
            var players = CheckablePlayers.Where(p => p.IsChecked).Select(p => p.Name);
            for (int i = 0; i < CountRounds; i++)
            {
                Rounds.Add(new Round(i + 1, players));
            }
            var g = new Game(DateTime.Now, Title!, Rounds);
            Games.Add(g);

            await FileService.SaveGames(Games);

            _openGame.Invoke(g);
        }
    }

    public class CheckablePlayer(string name)
    {
        public bool IsChecked { get; set; } = false;
        public string Name { get; set; } = name;
    }
}