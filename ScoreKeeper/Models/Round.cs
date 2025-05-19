using Avalonia.Collections;
using CommunityToolkit.Mvvm.ComponentModel;
using System.Collections.Generic;

namespace ScoreKeeper.Models
{
    public partial class Round : ObservableObject
    {
        [ObservableProperty]
        private int _roundIndex;
        
        public AvaloniaDictionary<string, int> RoundData { get; set; }

        public Round()
        {
            RoundIndex = 0;
            RoundData = [];
        }

        public Round(Dictionary<string, int> roundDict) : this() 
        {
            foreach (var dict in roundDict)
            {
                RoundData.Add(dict.Key, dict.Value);
            }
        }

        public Round(int index, IEnumerable<string> players)
        {
            RoundIndex = index;
            RoundData = [];
            foreach (var player in players)
            {
                RoundData.Add(player, 0);
            }
        }
    }
}
