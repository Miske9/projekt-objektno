using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace tutorial_wpf
{
    public class FootballClub
    {
        public int FootballClubId { get; set; }
        public string Name { get; }
        public string DomaciStrijelac { get; set; }
        public string GostStrijelac { get; set; }
        public virtual List<Player> Players { get; } = new List<Player>();
        public virtual List<Match> Matches { get; } = new List<Match>();
        public decimal Finances { get; private set; }
        public virtual List<Transfer> TransferHistory { get; } = new List<Transfer>();

        public FootballClub() { }
        public FootballClub(string name, decimal initialFinances)
        {
            Name = name;
            Finances = initialFinances;
        }

        public void AddPlayer(Player player)
        {
            Players.Add(player);
            player.TransferToClub(this, player.MarketValue);
        }

        public void ScheduleMatch(Match match)
        {
            Matches.Add(match);
        }

        public void RecordMatchResult(Match match, int goalsFor, int goalsAgainst)
        {
            match.Result = $"{goalsFor} : {goalsAgainst}";

            foreach (Player player in Players)
            {
                if ((match.TeamType == "Domaci" && player.CurrentClub == this) ||
                    (match.TeamType == "Gostujuci" && player.CurrentClub != this))
                {
                    if (goalsFor > goalsAgainst)
                    {
                        player.ScoreGoal();
                    }
                    else if (goalsFor < goalsAgainst)
                    {
                        player.Assist();
                    }
                }
            }

            Console.WriteLine($"Match {match.Opponent} ({match.TeamType}) ended with the result {match.Result}.");
        }

        public void Strijelci(Match match, string domaciStrijelac, string gostStrijelac)
        {
            DomaciStrijelac = domaciStrijelac;
            GostStrijelac = gostStrijelac;
            match.DomaciStrijelac = domaciStrijelac;
            match.GostStrijelac = gostStrijelac;
        }

        public void TransferPlayer(Player player, FootballClub newClub)
        {
            if (Players.Contains(player) && Finances >= player.MarketValue)
            {
                Players.Remove(player);
                newClub.AddPlayer(player);
                Finances -= player.MarketValue;
                newClub.Finances += player.MarketValue;

                TransferHistory.Add(new Transfer(this, newClub, player.MarketValue));

                Console.WriteLine($"Player {player.Name} successfully transferred from {Name} to {newClub.Name} for a transfer fee of {player.MarketValue:C}.");
            }
            else
            {
                Console.WriteLine($"Player transfer {player.Name} failed. Check if the player is in the club and if the finances are sufficient.");
            }
        }
    }
}
