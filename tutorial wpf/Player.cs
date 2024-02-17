using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace tutorial_wpf
{
    public class Player(string name, int age, string position, decimal marketValue)
    {
        public string Name { get; } = name;
        public int Age { get; } = age;
        public string Position { get; } = position;
        public int GoalsScored { get; private set; }
        public int Assists { get; private set; }
        public decimal MarketValue { get; private set; } = marketValue;
        public FootballClub? CurrentClub { get; private set; }

        public List<Transfer> TransferHistory { get; } = new List<Transfer>();

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
            CurrentClub= newClub;
        }

        public override string ToString()
        {
            return $"{Name} ({Age} godina) - {Position} | Golovi: {GoalsScored}, Asistencije: {Assists}, Tržišna vrijednost: {MarketValue:C}";
        }
    }

}
