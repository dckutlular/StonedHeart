using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace denizProject
{
    public class Player
    {
        public Player(int initialHealth, int InitialMana, List<Card> InitialCards,int InitialRoundMana,int Initialid,List<Card> InitialCardsOnDeck)
        {
            health = initialHealth;
            currentMana = InitialMana;
            cardsOnHand = InitialCards;
            roundMana = InitialRoundMana;
            id = Initialid;
            cardsOnDeck = InitialCardsOnDeck;

        }
        public int health { get; set; }
        private int currentMana;
        private int roundMana;
        private List<Card> cardsOnHand;
        public int id { get; set; }
        private List<Card> cardsOnDeck;

        public int getCurrentMana() { return this.currentMana; }
        public int setCurrentMana(int currentMana) { return this.currentMana = currentMana; }

        public int getRoundMana() { return this.roundMana; }
        public int setRoundMana(int roundMana) { return this.roundMana = roundMana; }

        public List<Card> getCardsOnHand() { return this.cardsOnHand; }
        public List<Card> getCardsOnDeck() { return this.cardsOnDeck; }
    }
}
