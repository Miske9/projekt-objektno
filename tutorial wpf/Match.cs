using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace tutorial_wpf
{
    public class Match
    {
        public string DomaciStrijelac { get; set; }
        public string GostStrijelac { get; set; }
        public string Opponent { get; }
        public string Klub { get; }
        public string Location { get; }
        public int HomeGoals { get; private set; }
        public int AwayGoals { get; private set; }
        public string Result { get; set; }
        public string TeamType { get; }

        public Match(string opponent, string a2,string location, string teamType)
        {
            Opponent = opponent;
            Klub = a2;
            Location = location;
            Result = "N/A";
            TeamType = teamType;
        }

        public void RecordResult(int homeGoals, int awayGoals, string domaciStrijelac, string gostStrijelac)
        {
            HomeGoals = homeGoals;
            AwayGoals = awayGoals;
            DomaciStrijelac = domaciStrijelac;
            GostStrijelac = gostStrijelac;
        }

        public override string ToString()
        {
            return $"{Opponent} {Klub}- {Location} {TeamType} ({HomeGoals} : {AwayGoals}) ";
        }
    }

}
