using System.Numerics;
using System.Collections.Generic;

namespace tutorial_wpf
{
    public class Player
    {
        public Player() { }
        public Player(string name, int age, string category, string position, int marketValue, int goals, int assists)
        {
            Name = name;
            Age = age;
            Category = category;
            Position = position;
            MarketValue = marketValue;
            GoalsScored = goals;
            Assists = assists;
        }

        public int PlayerId { get; set; }
        public string Name { get;set; }
        public int Age { get; set;}
        public string Position { get; set; }
        public string? Category { get; set; }
        public int GoalsScored { get; set; }
        public int Assists { get; set; }
        public int MarketValue { get; private set; }
        public virtual FootballClub? CurrentClub { get; private set; }

        public virtual List<Transfer> TransferHistory { get; } = new List<Transfer>();

        public void ScoreGoal()
        {
            GoalsScored++;
        }

        public void Assist()
        {
            Assists++;
        }

        public void TransferToClub(FootballClub newClub, decimal transferFee)
        {
            TransferHistory.Add(new Transfer(CurrentClub, newClub, transferFee));
            CurrentClub = newClub;
        }

        public override string ToString()
        {
            return $"{Name} ({Age} godina) - {Position} | Golovi: {GoalsScored}, Asistencije: {Assists}, Tržišna vrijednost: {MarketValue:C}";
        }
    }
}
