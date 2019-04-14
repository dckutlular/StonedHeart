using System;
using System.Collections.Generic;

namespace denizProject
{
    public class Player
    {
        public Player(int initialHealth, int InitialMana, List<Card> InitialCards, int InitialManaSlot, int Initialid, List<Card> InitialCardsOnDeck)
        {
            if (InitialManaSlot != 0 || InitialMana != 0)
                throw new ArgumentException("You cant initiate a Player with negative mana", "Mana Parameters");
            if (initialHealth != 30)
                throw new ArgumentException("Player can't be initiated unless it has 30 hp.", "initialHealth");
            if (Initialid != 1 && Initialid != 2)
                throw new ArgumentException("Players should have id 1 or 2.", "Initialid");
            if (InitialCards.Count != 3)
                throw new ArgumentException("Don't Cheat! Every player should start with 3 cards on Hand.", "InitialCards");

            health = initialHealth;
            currentMana = InitialMana;
            cardsOnHand = InitialCards;
            manaSlot = InitialManaSlot;
            id = Initialid;
            cardsOnDeck = InitialCardsOnDeck;

        }
        private int health;
        private int currentMana;
        private int manaSlot;
        private List<Card> cardsOnHand;
        private int id;
        private List<Card> cardsOnDeck;

        public int getHealth() { return this.health; }
        public void setHealth(int health)
        {
            if (health <= getHealth())
                this.health = health;
            else
                throw new System.ArgumentException("You cant heal the hero!!", "Health");
        }

        public int getCurrentMana() { return this.currentMana; }
        public int setCurrentMana(int currentMana) { return this.currentMana = currentMana; }

        public int getId() { return this.id; }

        public int getManaSlot() { return this.manaSlot; }
        public void setManaSlot(int manaSlot)
        {
            if (manaSlot >= 0)
                this.manaSlot = manaSlot;
            else
                throw new System.ArgumentException("Parameter cannot be negative", "ManaSlot");
        }

        public List<Card> getCardsOnHand() { return this.cardsOnHand; }
        public List<Card> getCardsOnDeck() { return this.cardsOnDeck; }
    }
}
