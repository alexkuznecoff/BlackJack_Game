using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BlackJack_Game
{
    public struct Dealer
    {
        public Card[] dealerHand;
        public int dealerCounter;

        public Dealer(Card[]playingDeck, int count)
        {
            dealerHand = new Card[52];
            dealerCounter = 0;
            dealerHand = OneMoreCardToDealer(playingDeck, count);
            dealerHand = OneMoreCardToDealer(playingDeck, --count);
            Game.cardIndex = count;

        }

        public Card[] OneMoreCardToDealer(Card[] playingDeck, int count)
        {
            dealerHand[dealerCounter] = playingDeck[count-1];
            dealerCounter++;

            return dealerHand;
        }
    }
}
