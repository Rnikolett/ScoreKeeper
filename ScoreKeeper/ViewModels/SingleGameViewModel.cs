using CommunityToolkit.Mvvm.ComponentModel;
using CommunityToolkit.Mvvm.Input;
using ScoreKeeper.Models;
using System;
using System.Collections.ObjectModel;
using System.ComponentModel;

namespace ScoreKeeper.ViewModels
{
    public partial class SingleGameViewModel : ViewModelBase
    {
        private readonly Action _saveGames;

        [ObservableProperty]
        private Game _game;

        public ObservableCollection<Round> ScoreSummary { get; }

        public SingleGameViewModel(Game game, Action saveGames)
        {
            Game = game;
            _saveGames = saveGames;
            foreach (var round in Game.Rounds)
            {
                round.RoundData.PropertyChanged -= UpdateScoreSummary;
                round.RoundData.PropertyChanged += UpdateScoreSummary;
            }
            ScoreSummary = [Game.GetScoreSummary()];
        }

        [RelayCommand]
        private void SaveGames()
        {
            _saveGames.Invoke();
        }

        [RelayCommand]
        private void AddRound()
        {
            var newRound = new Round(Game.Rounds.Count + 1, Game.PlayersList);
            newRound.RoundData.PropertyChanged += UpdateScoreSummary;
            Game.Rounds.Add(newRound);
        }

        [RelayCommand]
        private void DeleteRound(Round roundToDelete)
        {
            var deletedIndex = roundToDelete.RoundIndex;
            roundToDelete.RoundData.PropertyChanged -= UpdateScoreSummary;
            Game.Rounds.Remove(roundToDelete);
            
            //Reindexing
            for (int i = deletedIndex - 1; i < Game.Rounds.Count; i++)
            {
                Game.Rounds[i].RoundIndex--;
            }
        }

        private void UpdateScoreSummary(object? sender, PropertyChangedEventArgs e)
        {
            ScoreSummary[0] = Game.GetScoreSummary();
        }
    }
}