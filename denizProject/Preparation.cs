using System;
using System.Collections.Generic;
using System.Linq;

namespace DenizProject
{
    public static class Preparation
    {
        private static List<Card> CreateInitialCards()
        {
            int[] cardsArr = { 0, 0, 1, 1, 2, 2, 2, 3, 3, 3, 3, 4, 4, 4, 5, 5, 6, 6, 7, 8 };

            return cardsArr.Select(power => new Card {Power = power}).ToList();
        }

        public static List<Player> CreatePlayers()
        {
            Random rnd = new Random();
            List<Card> deck1 = CreateInitialCards();
            List<Card> deck2 = CreateInitialCards();
            List<Card> playerOneInitialThree = deck1.OrderBy(item => rnd.Next()).Take(3).ToList();
            List<Card> playerTwoInitialThree = deck2.OrderBy(item => rnd.Next()).Take(3).ToList();

            foreach (Card item in playerOneInitialThree)
            {
                Card cardToRemove = playerOneInitialThree.FirstOrDefault(r => r.Power == item.Power);
                deck1.Remove(cardToRemove);
            }

            foreach (Card item in playerTwoInitialThree)
            {
                Card cardToRemove = playerTwoInitialThree.FirstOrDefault(r => r.Power == item.Power);
                deck2.Remove(cardToRemove);
            }

            List<Player> players = new List<Player>();
            Player player1 = new Player(30, 0, playerOneInitialThree, 0, 1, deck1);
            Player player2 = new Player(30, 0, playerTwoInitialThree, 0, 2, deck2);
            players.Add(player1);
            players.Add(player2);

            return players;
        }

        public static int DisplayMenu()
        {
            while (true)
            {
                Console.WriteLine("Welcome to closed beta version of StonedHeart");
                Console.WriteLine();
                Console.WriteLine("1. Start a new game");
                Console.WriteLine("2. Exit");
                var result = Console.ReadLine();
                int.TryParse(result, out int selection);

                // if player make a selection.
                // if not, force player to to choose a valid option.
                if (selection == 1 || selection == 2)
                {
                    return Convert.ToInt32(selection);
                }

                Console.Clear();
            }
        }
    }
}
