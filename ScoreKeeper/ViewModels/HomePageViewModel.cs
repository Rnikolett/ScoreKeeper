using ScoreKeeper.Models;
using System.Collections.ObjectModel;

namespace ScoreKeeper.ViewModels
{
	public partial class HomePageViewModel : ViewModelBase
	{
		public ObservableCollection<Game> Games { get; }

		public HomePageViewModel(ObservableCollection<Game> games) 
		{
			Games = games;
		}

        // TODO open game
        // TODO delete game
    }
}