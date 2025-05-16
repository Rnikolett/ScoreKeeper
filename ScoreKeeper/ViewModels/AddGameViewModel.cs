

using ScoreKeeper.Models;
using System.Collections.Generic;
using System.Collections.ObjectModel;

namespace ScoreKeeper.ViewModels
{
    public partial class AddGameViewModel : ViewModelBase
    {

        public ObservableCollection<Round> Rounds { get; }

        public AddGameViewModel()
        {
            List<string> Players = new List<string>
            {
                "Janni",
                "Pisto"
            };
            Rounds = new ObservableCollection<Round>();
            for (int i = 0; i < 10; i++)
            {
                Rounds.Add(new Round(i + 1, Players));
            }
        }
    }


}