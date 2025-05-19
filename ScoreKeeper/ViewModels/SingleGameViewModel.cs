using CommunityToolkit.Mvvm.ComponentModel;
using CommunityToolkit.Mvvm.Input;
using ScoreKeeper.Models;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Security.Cryptography.X509Certificates;

namespace ScoreKeeper.ViewModels
{
    public partial class SingleGameViewModel : ViewModelBase
    {
        private readonly Action _saveGames;

        [ObservableProperty]
        private Game _game;


        public SingleGameViewModel(Game game, Action saveGames)
        {
            Game = game;
            _saveGames = saveGames;
        }

        [RelayCommand]
        private void SaveGames()
        {
            _saveGames.Invoke();
        }

        public void CountScore()
        {
            int count = 0;
            foreach (var player in Game.PlayersList)
            {
                
            }
        }

        
        
        // TODO display summary line -> separate grid?
        
        // TODO Add new round

        // TODO Delete existing round -> reindex rounds when deleting
        // eg.: [1, 2, 3, 4, 5, 6] -> delete 4th -> [1, 2, 3, 4 (prevoiusly 5), 5 (previously 6)]
    }
}