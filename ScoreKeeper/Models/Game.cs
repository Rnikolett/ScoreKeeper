using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text.Json.Serialization;

namespace ScoreKeeper.Models
{
    public class Game
    {
        public DateTime Date { get; set; }
        public string Title { get; set; }
        public ObservableCollection<Round> Rounds { get; set; }

        [JsonIgnore]
        public List<string> PlayersList => Rounds.FirstOrDefault()?.RoundData.Keys.ToList() ?? [];
        [JsonIgnore]
        public string Players => string.Join(", ", PlayersList);

        public Game()
        {
            Date = DateTime.Now;
            Title = string.Empty;
            Rounds = [];
        }

        public Game(DateTime date, string title, IEnumerable<Round> rounds)
        {
            Date = date;
            Title = title;
            Rounds = [.. rounds];
        }
    }
}
