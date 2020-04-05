using System;
using System.Collections.Generic;
using System.Text;

namespace DvirSolitare
{
    class Deck
    {
        private Card[] cards = new Card[52];

        public Deck(Card[] cards) 
        {
            this.cards = cards;
        }
        public Deck()
        {
            //Spade Heart Diamond and Club
            String t = null;
            int Counter = 1;
            for (int i = 1; i <= 4; i++)
            {
                if (i == 1) { t = "Spade"; }
                if (i == 2) { t = "Heart"; }
                if (i == 3) { t = "Diamond"; }
                if (i == 4) { t = "Club"; }
                for (int n = 1; n <= 13; n++)
                {
                    Card card = new Card(n, t);
                    this.cards[Counter - 1] = card;
                    //Console.WriteLine(Counter);
                    Console.WriteLine(card.ToString());
                    Counter++;
                }
            }
        }
        public Deck(Deck d)
        {
            this.cards = d.cards;
        }
        public override string ToString()
        {
            return cards.ToString();
        }
        public Card getCard(int i)
        {
            return cards[i];
        }
        public bool areFollowingNum(Card c1, Card c2)
        //are the Cards one after the other
        {
            if (c1.getNum() == c2.getNum() - 1)
            {
                return true;
            }
            return false;
        }
        public bool areDifferentcolors(Card c1, Card c2)
        //are the Cards diffrent colors
        {
            if ((c1.getType() == "Spade" || c1.getType() == "Club") && (c2.getType() == "Heart" || c2.getType() == "Diamond"))
            {
                return true;
            }
            return false;
        }
    }
}