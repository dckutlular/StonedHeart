using System;
using System.Collections.Generic;

namespace DenizProject
{
    public class Player
    {
        private readonly List<Card> _cardsOnHand;
        private readonly List<Card> _cardsOnDeck;
        private readonly int _id;
        private int _health;
        private int _currentMana;
        private int _manaSlot;

        public Player(int initialHealth, int initialMana, List<Card> initialCards, int initialManaSlot, int initialid, List<Card> initialCardsOnDeck)
        {
            if (initialManaSlot != 0 || initialMana != 0)
                throw new ArgumentException("You cant initiate a Player with negative mana", nameof(initialMana));
            if (initialHealth != 30)
                throw new ArgumentException("Player can't be initiated unless it has 30 hp.", nameof(initialHealth));
            if (initialid != 1 && initialid != 2)
                throw new ArgumentException("Players should have id 1 or 2.", nameof(initialHealth));
            if (initialCards.Count != 3)
                throw new ArgumentException("Don't Cheat! Every player should start with 3 cards on Hand.", nameof(initialCards));

            _health = initialHealth;
            _currentMana = initialMana;
            _cardsOnHand = initialCards;
            _manaSlot = initialManaSlot;
            _id = initialid;
            _cardsOnDeck = initialCardsOnDeck;
        }

        public int getHealth()
        {
            return _health;
        }

        public void setHealth(int health)
        {
            if (health <= getHealth())
                _health = health;
            else
                throw new ArgumentException("You cant heal the hero!!", nameof(health));
        }

        public int getCurrentMana()
        {
            return _currentMana;
        }

        public void setCurrentMana(int currentMana)
        {
            _currentMana = currentMana;
        }

        public int getId()
        {
            return _id;
        }

        public int getManaSlot()
        {
            return _manaSlot;
        }

        public void setManaSlot(int manaSlot)
        {
            if (manaSlot >= 0)
                _manaSlot = manaSlot;
            else
                throw new ArgumentException("Parameter cannot be negative", nameof(manaSlot));
        }

        public List<Card> getCardsOnHand()
        {
            return _cardsOnHand;
        }

        public List<Card> getCardsOnDeck()
        {
            return _cardsOnDeck;
        }
    }
}
