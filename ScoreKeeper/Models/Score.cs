using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ScoreKeeper.Models
{
    public class Score(string player, int round, int playerScore)
    {
        public string Player { get; set; } = player;
        public int Round { get; set; } = round;
        public int PlayerScore { get; set; } = playerScore;
    }
}
