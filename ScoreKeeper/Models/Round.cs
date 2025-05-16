using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ScoreKeeper.Models
{
    public class Round(int index, IEnumerable<string> players)
    {
        public int RoundIndex { get; set; } = index;
        public Dictionary<string, int> RoundData { get; set; } = players.ToDictionary(p => p, p => 0);
    }
}
