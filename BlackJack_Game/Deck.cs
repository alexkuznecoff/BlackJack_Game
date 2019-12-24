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

            while (length > 1)
            {
                length--;
                int index = rand.Next(length + 1);
                Card card = cards[index];
                cards[index] = cards[length];
                cards[length] = card;
            }
        }
        public static int DeckValueCalculating(Card[] cards)
        {
            int decKValue = 0;

            foreach (var card in cards)
            {
                decKValue += card.Value;
            }
            return decKValue;
        }
        public static void PrintDeck(Card[] cards)
        {
            for (int i = 0; i < cards.Length; i++)
            {
                if (cards[i].Value > 0)
                {
                    if (cards[i].Suit == Suit.Diamonds || cards[i].Suit == Suit.Hearts)
                    {
                        Console.ForegroundColor = ConsoleColor.Red;
                        if (cards[i].Suit == Suit.Diamonds)
                        {
                            cards[i].Unicode = '\u2666';
                        }
                        else if (cards[i].Suit == Suit.Hearts)
                        {
                            cards[i].Unicode = '\u2665';
                        }

                    }
                    else
                    {
                        if (cards[i].Suit == Suit.Clubs)
                        {
                            cards[i].Unicode = '\u2663';
                        }
                        else if (cards[i].Suit==Suit.Spades)
                        {
                            cards[i].Unicode = '\u2660';
                        }
                            Console.ForegroundColor = ConsoleColor.White;
                    }
                    Console.OutputEncoding = Encoding.Unicode;

                    Console.WriteLine($"{cards[i].Rank}  {cards[i].Unicode}  {cards[i].Value} points");
                    Console.ResetColor();
                }
            }
        }
    }
}
