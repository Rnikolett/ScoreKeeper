using CommunityToolkit.Mvvm.ComponentModel;
using CommunityToolkit.Mvvm.Input;
using ScoreKeeper.Services;
using System.Collections.ObjectModel;
using System.Threading.Tasks;

namespace ScoreKeeper.ViewModels
{
    public partial class PlayerListViewModel : ViewModelBase
    {
        [ObservableProperty]
        [NotifyCanExecuteChangedFor(nameof(AddPlayerCommand))]
        private string? _newPlayer;

        public ObservableCollection<string> Players { get; }

        public PlayerListViewModel(ObservableCollection<string> players)
        {
            Players = players;
        }

        private bool CanAddPlayer => !string.IsNullOrWhiteSpace(NewPlayer);

        [RelayCommand(CanExecute = nameof(CanAddPlayer))]
        private void AddPlayer()
        {
            Players.Add(NewPlayer!);
            NewPlayer = null;
        }

        [RelayCommand]
        private void RemovePlayer(string player)
        {
            Players.Remove(player);
        }

        [RelayCommand]
        private async Task SavePlayers()
        {
            await FileService.SavePlayers(Players);
        }
    }
}