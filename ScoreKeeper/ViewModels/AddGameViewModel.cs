using CommunityToolkit.Mvvm.ComponentModel;
using CommunityToolkit.Mvvm.Input;
using ScoreKeeper.Models;
using System;
using System.Collections.ObjectModel;
using System.Linq;

namespace ScoreKeeper.ViewModels
{
    public partial class AddGameViewModel : ViewModelBase
    {
        private readonly Action<Game> _openGame;

        [NotifyCanExecuteChangedFor(nameof(CreateGameCommand))]
        [ObservableProperty]
        private string? _title;

        [ObservableProperty]
        [NotifyCanExecuteChangedFor(nameof(CreateGameCommand))]
        private int? _countRounds;

        [ObservableProperty]
        private string? _errorMessage;

        public ObservableCollection<Round> Rounds { get; } = [];

        public ObservableCollection<CheckablePlayer> CheckablePlayers { get; }

        public AddGameViewModel(
            ObservableCollection<string> players,
            Action<Game> openGame
        )
        {
            _openGame = openGame;
            CheckablePlayers = [.. players.Select(p => new CheckablePlayer(p))];
        }

        [RelayCommand(CanExecute = nameof(CanCreateGame))]
        private void CreateGame()
        {
            var players = CheckablePlayers.Where(p => p.IsChecked).Select(p => p.Name);
            if (players.Any())
            {
                for (int i = 0; i < CountRounds; i++)
                {
                    Rounds.Add(new Round(i + 1, players));
                }

                var newGame = new Game(DateTime.Now, Title!, Rounds);

                _openGame.Invoke(newGame);
            }
            else
            {
                ErrorMessage = "Please choose one or more Player";
            }
        }

        private bool CanCreateGame()
        {
            return CountRounds.HasValue && !string.IsNullOrWhiteSpace(Title) && Title.Length >= 3;
        }
    }

    public class CheckablePlayer(string name)
    {
        public bool IsChecked { get; set; } = false;
        public string Name { get; set; } = name;
    }
}