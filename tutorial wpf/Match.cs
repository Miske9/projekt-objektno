namespace tutorial_wpf
{
    public class Match
    {

        FootballDbContext _context = new FootballDbContext();
        public int MatchId { get; set; }
        public string? DomaciStrijelac { get; set; }
        public string? GostStrijelac { get; set; }
        public virtual FootballClub Opponent { get; set; }
        public virtual FootballClub Klub { get; set; }
        public string Location { get; set; }
        public int HomeGoals { get; private set; }
        public int AwayGoals { get; private set; }
        public string Result { get; set; }
        public string TeamType { get; set; }

        public Match() { }
        public Match(FootballClub opponent, FootballClub klub, string location, string teamType)
        {
            Opponent = opponent;
            Klub = klub;
            Location = location;
            Result = "N/A";
            TeamType = teamType;
        }

        public void RecordResult(int homeGoals, int awayGoals, string? domaciStrijelac, string? gostStrijelac)
        {
            Result = $"{homeGoals}:{awayGoals}";
            HomeGoals = homeGoals;
            AwayGoals = awayGoals;
            if(domaciStrijelac != null)
            {

            DomaciStrijelac = domaciStrijelac;
            }
            if(gostStrijelac != null)
            {

            GostStrijelac = gostStrijelac;
            }
        }
    }
}
