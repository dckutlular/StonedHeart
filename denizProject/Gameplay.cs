using System;
using System.Collections.Generic;
using System.Linq;

namespace denizProject
{
    public class Gameplay
    {
        public static Card SelectCard(Player player)
        {
            int lastOption = 1;
            Console.WriteLine("Player" + player.getId() + " is playing..");
            Console.WriteLine("Select a Card to Play");
            Console.WriteLine();
            Console.WriteLine("Your Current Mana is " + player.getCurrentMana());
            Console.WriteLine("Your Current Health is " + player.getHealth());
            Console.WriteLine();
            List<Card> cardsOnHand = player.getCardsOnHand();
            foreach (Card card in cardsOnHand)
            {
                Console.WriteLine(lastOption.ToString() + ". " + "Damage --> " + card.power);
                lastOption += 1;
            }
            Console.WriteLine(lastOption.ToString() + ". " + "End Turn!");
            string result = Console.ReadLine();
            Console.Clear();

            //input validations
            bool isValid = int.TryParse(result, out int selectedOption);
            if (isValid && selectedOption <= lastOption)
            {
                //player choose End Turn Option.
                if (selectedOption == lastOption)
                {
                    return null;
                }
                //player choose to play a card.
                Card selectedCard = cardsOnHand[selectedOption - 1];
                //if player can afford that card.
                if (selectedCard.power <= player.getCurrentMana())
                {
                    return selectedCard;
                }
                //not enough mana
                else
                {
                    Console.WriteLine("Not enough mana to play this card. Choose Another Card or end turn!!");
                    Console.WriteLine();
                    return SelectCard(player);
                }
            }
            else
            {
                return SelectCard(player);
            }
        }
        public static void NewTurn(Player player)
        {
            //at the beginning of a turn, increase mana slot by 1 for the active player(at most 10).
            player.setManaSlot(player.getManaSlot() + 1);
            player.setCurrentMana(player.getManaSlot() >= 10 ? 10 : player.getManaSlot());

            //check if he has card on deck. 
            bool isDeckEmpty = !player.getCardsOnDeck().Any();
            //if he has card on deck, pick a random one.
            if (!isDeckEmpty)
            {
                //get a new Card from shuffled Deck.
                Card newCard = player.getCardsOnDeck().OrderBy(x => Guid.NewGuid()).FirstOrDefault();

                //Add to Hand if active player has less than 5 Cards.
                if (player.getCardsOnHand().Count < 5)
                {
                    player.getCardsOnHand().Add(newCard);
                }
                else
                {
                    Console.WriteLine("Player" + player.getId().ToString() + " lost a new card because 5 cards in hand. Lost card's attack was : " + newCard.power.ToString());
                }
                //Delete that new Card from Deck anyway.
                player.getCardsOnDeck().Remove(newCard);
            }
            //if there is no card on deck, get a 1 damage.
            else
            {
                player.setHealth(player.getHealth() - 1);
            }
        }
        public static void Attack(Card selectedCard, bool isPlayerOneTurn, Player player1, Player player2)
        {
            Player player = isPlayerOneTurn ? player1 : player2;
            //spend mana when player plays a card.
            player.setCurrentMana(player.getCurrentMana() - selectedCard.power);
            //Remove card from hand.
            Card cardToRemove = player.getCardsOnHand().FirstOrDefault(r => r.power == selectedCard.power);
            player.getCardsOnHand().Remove(cardToRemove);
            //update enemy health
            if (isPlayerOneTurn)
                player2.setHealth(player2.getHealth() - selectedCard.power);
            else
                player1.setHealth(player1.getHealth() - selectedCard.power);
        }
        public static int EndGame(Player winner)
        {
            Console.Clear();
            Console.WriteLine("Game over.. Winner is: Player" + winner.getId().ToString() + ". Press 1 to start a new game, Press 2 to quit.");
            int.TryParse(Console.ReadLine(), out int selection);
            if (selection == 1 || selection == 2)
                return selection;
            else
                return EndGame(winner);
        }
    }
}
