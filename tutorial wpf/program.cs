using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
/*
namespace tutorial_wpf
{
    using System;
    using System.Collections.Generic;

    class Program
    {
        static void Main()
        {
            FootballClub myClub = new FootballClub("Barecelona", 1000);
            FootballClub newClub = new FootballClub("Real Madrid", 1000);

            Player player1 = new Player("Messi", 10, "Napadač", 100);
            Player player2 = new Player("Ronaldo", 7, "Vezni", 200);
            myClub.AddPlayer(player1);
            myClub.AddPlayer(player2);

            foreach (Player player in myClub.Players)
            {
                Console.WriteLine(player.ToString());

                if (player.TransferHistory != null)
                {
                    Console.WriteLine("Povijest transfera:");
                    foreach (Transfer transfer in player.TransferHistory)
                    {
                        Console.WriteLine(transfer.ToString());
                    }
                }
                else
                {
                    Console.WriteLine("Igrač nema povijest transfera.");
                }

                Console.WriteLine();
            }

            Match match1 = new Match("Bilbao", "Domaća", "Prijateljska");
            Match match2 = new Match("PSG", "Gostujuća", "Liga");
            myClub.ScheduleMatch(match1);
            myClub.ScheduleMatch(match2);

            myClub.RecordMatchResult(match1, 2, 1);
            myClub.RecordMatchResult(match2, 1, 1);

            Console.WriteLine("Izvještaj o klubu: " + myClub.Name);

            Console.WriteLine("\nRaspored utakmica:");
            foreach (Match match in myClub.Matches)
            {
                Console.WriteLine(match.ToString());
            }

            Console.WriteLine("\nFinancije kluba: " + myClub.Finances);

            Console.WriteLine("Izvještaj o klubu: " + myClub.Name);

            myClub.TransferPlayer(player1, newClub);
            myClub.TransferPlayer(player2, myClub);

            myClub.RecordMatchResult(match1, 2, 1);
            myClub.RecordMatchResult(match2, 1, 1);

            Console.WriteLine("Igrači:");
            Console.WriteLine("Povijest transfera:");
            foreach (Player player in myClub.Players)
            {
                Console.WriteLine(player.ToString());

                if (player.TransferHistory != null)
                {
                    Console.WriteLine("Povijest transfera:");
                    foreach (Transfer transfer in player.TransferHistory)
                    {
                        Console.WriteLine(transfer.ToString());
                    }
                }
                else
                {
                    Console.WriteLine("Igrač nema povijest transfera.");
                }

                Console.WriteLine();
            }

            Console.ReadLine();
        }
    }
}
   */