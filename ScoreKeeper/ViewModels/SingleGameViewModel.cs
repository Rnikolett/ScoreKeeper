using CommunityToolkit.Mvvm.ComponentModel;
using CommunityToolkit.Mvvm.Input;
using ScoreKeeper.Models;
using System;
using System.Collections.Generic;

namespace ScoreKeeper.ViewModels
{
    public partial class SingleGameViewModel : ViewModelBase
    {
        [ObservableProperty]
        private Game _game;

        public SingleGameViewModel(Game game)
        {
            Game = game;
        }

        // TODO save game -> call from MainView to save all game to json

        // TODO create DataGrid with dynamic columns in code-behind (SingleGameView.axaml.cs)
        // Diable sorting -> round number should always determine row order!
        
        // TODO display summary line -> separate grid?
        
        // TODO Add new round

        // TODO Delete existing round -> reindex rounds when deleting
        // eg.: [1, 2, 3, 4, 5, 6] -> delete 4th -> [1, 2, 3, 4 (prevoiusly 5), 5 (previously 6)]
    }
}