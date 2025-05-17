using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;

namespace ScoreKeeper.Models
{
    public class Game(DateTime date, string title, IEnumerable<Round> rounds)
    {
        public DateTime Date { get; set; } = date;
        public string Title { get; set; } = title;
        public ObservableCollection<Round> Rounds { get; set; } = [..rounds];
        public List<string> PlayersList => Rounds.FirstOrDefault()?.RoundData.Keys.ToList() ?? [];
        public string Players => string.Join(", ", PlayersList);
    }
}
