using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.ExceptionServices;
using System.Text;
using System.Threading.Tasks;

namespace Flux_Chess
{
    internal class Player
    {
        protected Deck hand = new Deck();

        protected int? handLimit;

        public Player(int handLimit)
        {
            this.handLimit = handLimit;
        }

        public Deck Hand
        {
            get { return hand; }
        }

        public void UpdateHandLimit(UI ui, ref Deck discardDeck)
        {
            handLimit = Rules.handLimit;
        }

        public void Draw(Card drawnCard)
        {
            hand.Push(drawnCard);
        }

        //??? surely this should draw into the players deck.
        public Card[] DrawWithRules(ref Deck deck)
        {
            Card[] cardsToReturn = new Card[Rules.drawAmount];

            for (int i = 0; i <= Rules.drawAmount; i++)
            {
                cardsToReturn[i] = deck.Pop();
            }

            return cardsToReturn;
        }

        public Card Discard(int index)
        {
            return hand.PopAt(index);
        }
    }
}
