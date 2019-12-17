using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
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

            while (play)
            {
                game.Initialize(cards);
                Console.WriteLine("Choise  who draws the card first");
                Console.WriteLine("1. Dealer");
                Console.WriteLine("2. Player");
                string decision = Console.ReadLine();

               if(decision=="1")
                {
                    Console.WriteLine("Dealer first take a card :");
                    Console.WriteLine("Shaffle deck.........");
                    Deck.Shuffle(game.playingDeck);
                    Thread.Sleep(1000);

                    Console.Clear();


                    Dealer dealer = new Dealer(game.playingDeck, --Game.cardIndex);
                    Console.WriteLine($"Dealer take a {dealer.dealerCounter} cards");

                    Player player = new Player(game.playingDeck, --Game.cardIndex);
                    Console.WriteLine($"Player take {player.playerCounter} cards");

                    Console.WriteLine("You are holding cards");
                    Deck.PrintDeck(player.playerHand);

                    Console.WriteLine($"Value of your hand  {Deck.DeckValueCalculating(player.playerHand)}");
                    Console.WriteLine("Press any key for continue....");
                    Console.ReadKey();

                    if(!game.CheckAces(dealer,player))
                    {
                        game.ChoiceOptionIfDealerFirst(dealer, player);
                        game.CalculaitingPoints(dealer, player);
                    }
                        play = game.GameResult();
                }
               else if (decision =="2")
                {
                    Console.WriteLine("Your first take a card");
                    Deck.Shuffle(game.playingDeck);

                    Player player = new Player(game.playingDeck, --Game.cardIndex);
                    Console.WriteLine($"Your take a {player.playerCounter} cards");

                    Dealer dealer = new Dealer(game.playingDeck, --Game.cardIndex);
                    Console.WriteLine($"Dealer take a {dealer.dealerCounter} cards");

                    Console.WriteLine($"Value of your hand : {Deck.DeckValueCalculating(player.playerHand)}");
                    Console.WriteLine("Press ane key for continue...");
                    Console.ReadKey();

                    if(!game.CheckAces(dealer, player))
                    {
                        game.ChoiceOptionIfPlayerFirst(dealer, player);
                        game.CalculaitingPoints(dealer, player);
                    }
                    play = game.GameResult();
                }
                else
                {
                    Console.WriteLine("Incorrect input.");
                    Console.WriteLine("try againe");
                }
               
            }
           
            Console.ReadKey();
        }
    }
}
