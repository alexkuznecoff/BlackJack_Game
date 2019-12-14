using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BlackJack_Game
{
    public struct Deck
    {
        public static void Shuffle(Card[] cards)
        {
            Random rand = new Random();
            int length = cards.Length;

            while(length > 1)
            {
                length--;
                int index = rand.Next(length + 1);
                Card card = cards[index];
                cards[index] = cards[length];
                cards[length] = card;
            }
        }
        public static int DeckValueCalculating(Card[]cards)
        {
            int decKValue = 0;

            foreach(var card in cards)
            {
                decKValue += card.Value;
            }
            return decKValue;
        }
        public static void PrintDeck(Card[] cards)
        {
            foreach(var item in cards)
            {
                if(item.Value > 0)
                {
                    Console.WriteLine($"{item.Rank}  {item.Suit}  {item.Value} points");
                }
            }
        }
    }
}
