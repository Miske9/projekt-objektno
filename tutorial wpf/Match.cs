using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace tutorial_wpf
{
    public class Match
    {
        public string Opponent { get; }
        public string Location { get; }
        public int HomeGoals { get; private set; }
        public int AwayGoals { get; private set; }
        public string Result { get; set; }
        public string TeamType { get; }

        public Match(string opponent, string location, string teamType)
        {
            Opponent = opponent;
            Location = location;
            Result = "N/A";
            TeamType = teamType;
        }

        public void RecordResult(int homeGoals, int awayGoals)
        {
            HomeGoals = homeGoals;
            AwayGoals = awayGoals;
        }

        public override string ToString()
        {
            return $"{Opponent} - {Location} ({HomeGoals} : {AwayGoals})";
        }
    }

}
