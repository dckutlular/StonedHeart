using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace denizProject
{
    public class Preperation
    {
        public static List<Card> CreateInitialCards()
        {
            List<Card> Cards = new List<Card>();
            int[] cardsArr = new int[] { 0, 0, 1, 1, 2, 2, 2, 3, 3, 3, 3, 4, 4, 4, 5, 5, 6, 6, 7, 8 };

            foreach (int power in cardsArr)
            {
                Cards.Add(new Card() { power = power });
            }
            return Cards;
        }

        public static List<Player> CreatePlayers()
        {
            Random rnd = new Random();
            List<Card> Deck1 = CreateInitialCards();
            List<Card> Deck2 = CreateInitialCards();
            List<Card> playerOneInitialThree = Deck1.OrderBy(item => rnd.Next()).Take(3).ToList();
            List<Card> playerTwoInitialThree = Deck2.OrderBy(item => rnd.Next()).Take(3).ToList();

            foreach (Card item in playerOneInitialThree)
            {
                Card cardToRemove = playerOneInitialThree.FirstOrDefault(r => r.power == item.power);
                Deck1.Remove(cardToRemove);
            }
            foreach (Card item in playerTwoInitialThree)
            {
                Card cardToRemove = playerTwoInitialThree.FirstOrDefault(r => r.power == item.power);
                Deck2.Remove(cardToRemove);
            }
            List<Player> players = new List<Player>();
            Player player1 = new Player(30, 0, playerOneInitialThree, 0, 1, Deck1);
            Player player2 = new Player(30, 0, playerTwoInitialThree, 0, 2, Deck2);
            players.Add(player1);
            players.Add(player2);

            return players;
        }

        static public int DisplayMenu()
        {
            Console.WriteLine("Welcome to closed beta version of StonedHeart");
            Console.WriteLine();
            Console.WriteLine("1. Start a new game");
            Console.WriteLine("2. Exit");
            var result = Console.ReadLine();
            int.TryParse(result, out int selection);

            if (selection == 1 || selection == 2)
            {
                return Convert.ToInt32(selection);
            }
            //force user to choose a valid option.
            else
            {
                Console.Clear();
                return DisplayMenu();
            }
        }
    }
}
