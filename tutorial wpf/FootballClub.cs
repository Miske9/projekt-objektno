using System.ComponentModel.DataAnnotations.Schema;

namespace tutorial_wpf
{
    public class FootballClub
    {
        public int FootballClubId { get; set; }
        public string Name { get; set; }
        public int Position { get; set; }
        public int PlayedGames { get; set; }
        public int Wins { get; set; }
        public int Draws { get; set; }
        public int Losses { get; set; }

        public int Games { get; set; }
        public int Points { get; set; }
        [NotMapped]
        public virtual Player? DomaciStrijelac { get; set; }
        [NotMapped]
        public virtual Player? GostStrijelac { get; set; }
        public virtual List<Player> Players { get; } = new List<Player>();
        public virtual List<Match> Matches { get; } = new List<Match>();
        public int Finances { get; private set; }
        public virtual List<Transfer> TransferHistory { get; } = new List<Transfer>();

        public FootballClub() { }
        public FootballClub(string name, int initialFinances, int position, int wins, int draws, int loses)
        {
            Name = name;
            Finances = initialFinances;
            Position = position;
            Wins = wins;
            Draws = draws;
            Losses = loses;
            Games = loses + wins + draws;
            Points = wins * 3 + draws;
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

        public void Strijelci(Match match, Player domaciStrijelac, Player gostStrijelac)
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
