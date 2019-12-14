using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BlackJack_Game
{
    public struct Player
    {
        public Card[] playerHand;
        public int playerCounter;

        public Player(Card[] playingDeck, int count)
        {
            playerHand = new Card[52];
            playerCounter = 0;
            playerHand = OneMoreCardToPlayer(playingDeck, count);
            playerHand = OneMoreCardToPlayer(playingDeck, --count);
            Game.cardIndex = count;

        }

        public Card[] OneMoreCardToPlayer(Card[] playingDeck, int count)
        {
            playerHand[playerCounter] = playingDeck[count-1];
            playerCounter++;
            return playerHand;
        }
    }
}
