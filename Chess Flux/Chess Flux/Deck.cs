using System;
using System.Collections.Generic;
using System.Text;

namespace Flux_Chess
{
    internal class Deck
    {
        // This is implimented like a queue; cards are taken from the bottom and added to the top.
        // Imagine that if the deck of cards was on the table, this implimentation would have the array upside down.
        protected List<Card> cards;
        protected int? deckMaxSize;

        public Deck()
        {
            this.cards = new List<Card>();
        }

        public Deck(List<Card> cards)
        {
            deckMaxSize = cards.Count;
            this.cards = cards;
        }

        public Card Pop()
        {
            Card card = cards[0];
            cards.RemoveAt(0);
            return card;
        }

        public Card PopAt(int index)
        {
            Card card = cards[index];
            cards.RemoveAt(index);
            return card;
        }

        public void Push(Card card)
        {
            cards.Add(card);
        }

        public void Shuffle()
        {
            Random random = new Random();
            Card[] temporaryCards = new Card[cards.Count];
            int count = 0;
            while (count < cards.Count)
            {
                int randomIndex = random.Next(cards.Count);
                if (temporaryCards[randomIndex] != null)
                {
                    continue;
                }
                else
                {
                    temporaryCards[randomIndex] = cards[count];
                    count++;
                }
            }
        }

        public int Count
        {
            get { return cards.Count; }
        }

        // This functions as a peak not as a draw.
        // Idk if this is useful but it was cool to find out you could make this.
        public Card this[int index]
        {
            get => cards.ToArray()[index];
        }
    }
}
