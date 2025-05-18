using CommunityToolkit.Mvvm.Input;
using ScoreKeeper.Models;
using ScoreKeeper.Services;
using System;
using System.Collections.ObjectModel;
using System.Threading.Tasks;

namespace ScoreKeeper.ViewModels
{
	public partial class HomePageViewModel : ViewModelBase
	{
        private readonly Action<Game> _openGame;
        public ObservableCollection<Game> Games { get; }

		public HomePageViewModel(ObservableCollection<Game> games, Action<Game> openGame) 
		{
			Games = games;
			_openGame = openGame;
		}

		[RelayCommand]
		private void OpenGame(Game game)
		{
			_openGame.Invoke(game);
		}

		[RelayCommand]
		private async void DeleteGame(Game game)
		{
			Games.Remove(game);
			await FileService.SaveGames(Games);
		}

		// TODO create table header in view
    }
}