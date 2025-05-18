using System.Collections.Generic;
using System.Linq;

namespace ScoreKeeper.Models
{
    public class Round
    {
        public int RoundIndex { get; set; }
        public Dictionary<string, int> RoundData { get; set; }

        public Round()
        {
            RoundIndex = 0;
            RoundData = [];
        }

        public Round(int index, IEnumerable<string> players)
        {
            RoundIndex = index;
            RoundData = players.ToDictionary(p => p, p => 0);
        }
    }
}
