using System;
using System.Collections.Generic;


namespace denizProject
{
    class Program
    {
        static void Main(string[] args)
        {
            int userInput = Preperation.DisplayMenu();

            while (userInput == 1)
            {
                switch (userInput)
                {
                    //Game starts
                    case 1:
                        //Initialize players with random cards from deck.
                        List<Player> players = Preperation.CreatePlayers();
                        Player player1 = players[0];
                        Player player2 = players[1];

                        Console.Clear();
                        Console.WriteLine("Player1 starts...");
                        bool isPlayerOneTurn = true;

                        Player player = isPlayerOneTurn ? player1 : player2;
                        Console.WriteLine();

                        //game on
                        while (player1.getHealth() > 0 && player2.getHealth() > 0)
                        {
                            Console.WriteLine("player1's Current Health is " + player1.getHealth());
                            Console.WriteLine("player2's Current Health is " + player2.getHealth());
                            Console.WriteLine();

                            //Player selects a card, or ends turn.
                            Card selectedCard = Gameplay.SelectCard(player);

                            //if it is card selection, attack.
                            if (selectedCard != null)
                            {
                                Gameplay.Attack(selectedCard, isPlayerOneTurn, player1, player2);
                            }
                            else //End Turn
                            {
                                //Switch active player
                                isPlayerOneTurn = !isPlayerOneTurn;
                                player = isPlayerOneTurn ? player1 : player2;
                                //New turn settings for active player (mana,deck,etc..)
                                Gameplay.NewTurn(player);
                            }
                        }
                        Player winner = player1.getHealth() > 0 ? player1 : player2;
                        userInput = Gameplay.EndGame(winner);
                        break;
                    case 2:
                        break;
                }
            }
        }
    }
}
