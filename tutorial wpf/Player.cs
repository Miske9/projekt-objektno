namespace tutorial_wpf
{
    public class Player
    {
        public Player() { }
        public Player(string name, int age, string category, string position, decimal marketValue)
        {
            Name = name;
            Age = age;
            Category = category;
            Position = position;
            MarketValue = marketValue;
        }

        public int PlayerId { get; set; }
        public string Name { get; }
        public int Age { get; }
        public string Position { get; }
        public string Category { get; set; }
        public int GoalsScored { get; private set; }
        public int Assists { get; private set; }
        public decimal MarketValue { get; private set; }
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
