using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BlackJack_Game
{
    public enum Suit
    {
        Diamonds,
        Hearts,
        Spades,
        Clubs,
    }
    public enum Rank
    {
        Two = 2,
        Three = 3,
        Four,
        Five,
        Six,
        Seven,
        Eight,
        Nine,
        Ten,
        Jack = 2,
        Lady,
        King,
        Ace = 11,
    }
    class Program
    {
        static void Main(string[] args)
        {
            Card[] cards = new Card[52];
            Game game = new Game();
            bool play = true;

            while(play)
            {
                game.Initialize(cards);
                Console.WriteLine("Choes");
            }
            /*
            Card[] cards = new Card[52];
            Game game = new Game();
            game.Initialize(cards);

            Deck deck = new Deck();
            deck.PrintDeck(cards);

            Console.WriteLine("____________");
            Deck.Shuffle(cards);
            deck.PrintDeck(cards);

            Console.WriteLine("card for player:");
            Player player = new Player(game.playingDeck, Game.cardIndex);
            deck.PrintDeck(player.playerHand);
            */
            Console.ReadKey();
        }
    }
}
