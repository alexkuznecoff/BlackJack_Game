using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace BlackJack_Game
{
    public struct Game
    {
        public Card[] playingDeck;
        public static int cardIndex;
        public int dealerWinCounter;
        public int playerWinCounter;
        public char UnicodeSign { get; set; }

        public void Initialize(Card[] cards)
        {
            cardIndex = 0;
            playingDeck = cards;

            foreach(Rank rank in Enum.GetValues(typeof(Rank)))  
            {
                foreach (Suit suit in Enum.GetValues(typeof(Suit)))   
                {
                   
                    playingDeck[cardIndex] = new Card { Rank = rank, Suit = suit };
                    playingDeck[cardIndex].Value = (int)playingDeck[cardIndex].Rank;   
                    cardIndex++;
                }
            }

        }
        public void CalculaitingPoints(Dealer dealer, Player player)
        {
            int dealerPoints = Deck.DeckValueCalculating(dealer.dealerHand);
            int playerPoints = Deck.DeckValueCalculating(player.playerHand);

            if (dealerPoints > playerPoints && dealerPoints <= 21 || dealerPoints < playerPoints && playerPoints > 21)
            {
                if (dealerPoints == 21)
                {
                    Console.WriteLine("Dealer win  in Blac Jack!!!");
                    Console.WriteLine();
                    Console.WriteLine("Winner hand :");
                    Deck.PrintDeck(dealer.dealerHand);

                    dealerWinCounter++;
                }
                else
                {
                    Console.WriteLine($"Dealer wins with  {dealerPoints}  points");
                    Console.WriteLine();
                    Console.WriteLine("Winner hand :");
                    Deck.PrintDeck(dealer.dealerHand);
                    dealerWinCounter++;
                }
            }
            else if(playerPoints > dealerPoints && playerPoints <= 21 || playerPoints < dealerPoints && dealerPoints > 21)
            {
                if(playerPoints == 21)
                {
                    Console.WriteLine();
                    Console.WriteLine("Player wins in BlackJack");
                    Console.WriteLine();
                    Console.WriteLine("Winner hand :");
                    Deck.PrintDeck(player.playerHand);
                    playerWinCounter++;
                }
                else
                {
                    Console.WriteLine();
                    Console.WriteLine($"Player wins with  {playerPoints}  points");
                    Deck.PrintDeck(player.playerHand);
                    playerWinCounter++;
                }
            }
        }
        public bool CheckAces(Dealer dealer, Player player)
        {
            bool aces = false;
            if(dealer.dealerHand[0].Rank == Rank.Ace && dealer.dealerHand[1].Rank == Rank.Ace)
            {
                Console.Clear();
                Console.WriteLine("Dealer won with two aces");
                Console.WriteLine();
                Console.WriteLine("Winner hand :");
                Deck.PrintDeck(dealer.dealerHand);
                dealerWinCounter++;

                aces = true;
            }
            else if(player.playerHand[0].Rank == Rank.Ace && player.playerHand[1].Rank == Rank.Ace)
            {
                Console.Clear();
                Console.WriteLine("Yor woinner with two aces");
                Console.WriteLine();
                Console.WriteLine("Winner hand :");
                Deck.PrintDeck(player.playerHand);
                playerWinCounter++;

                aces = true;
            }

            return aces;

        }
        
        public void ChoiceOptionIfDealerFirst(Dealer dealer, Player player)
        {
            bool play = true;

            do
            {
                Console.WriteLine("Your whant one more card ?");
                Console.WriteLine("1. Take");
                Console.WriteLine("2. Stay");
                string decision = Console.ReadLine();

                switch(decision)
                {
                    case "1":
                        if(Deck.DeckValueCalculating(dealer.dealerHand) <= 17)
                        {
                            Console.WriteLine("Dealer take one more card :");
                            dealer.dealerHand = dealer.OneMoreCardToDealer(playingDeck, --cardIndex);
                        }
                        else
                        {
                            Console.WriteLine("Dealer decides to stay!");
                            if(Deck.DeckValueCalculating(player.playerHand) > 21)
                            {
                                play = false;
                                continue;
                            }
                        }
                        Console.WriteLine("Your take one more card...");
                        Thread.Sleep(100);
                        player.playerHand = player.OneMoreCardToPlayer(playingDeck, --cardIndex);
                        if(Deck.DeckValueCalculating(player.playerHand) <= 21)
                        {
                            Console.WriteLine($"Dealer have {dealer.dealerCounter}  cards");
                            Console.WriteLine();
                            Console.WriteLine("Your have nex card");
                            Deck.PrintDeck(player.playerHand);
                            Console.WriteLine($"Your total score {Deck.DeckValueCalculating(player.playerHand)}");
                            Console.WriteLine();
                            Console.ReadKey();
                        }
                        else
                        {
                            play = false;
                        }
                        break;
                    case "2":
                        do
                        {
                            if(Deck.DeckValueCalculating(dealer.dealerHand) <= 17)
                            {
                                Console.WriteLine("Dealer take one more card :");
                                dealer.dealerHand = dealer.OneMoreCardToDealer(playingDeck, --cardIndex); 

                                if(Deck.DeckValueCalculating(dealer.dealerHand) > 21)
                                {
                                    play = false;
                                    break;
                                }

                            }
                            else
                            {
                                Console.WriteLine("Dealer decides to stay! ");
                                play = false;
                            }
                        } while (play);

                        Console.WriteLine("You stay !!!");
                        Console.WriteLine();
                        Console.WriteLine($"Dealer have {dealer.dealerCounter} cards");
                        Console.WriteLine();
                        Console.WriteLine("You have next card :");
                        Deck.PrintDeck(player.playerHand);
                        Console.WriteLine($"Your total score {Deck.DeckValueCalculating(player.playerHand)}");
                        break;
                    default:
                        Console.WriteLine("Incorrect input :");
                        break;
                }
            }
            while (play);

        }

        public void ChoiceOptionIfPlayerFirst(Dealer dealer, Player player)
        {
            bool play = true;

            do
            {
                Console.WriteLine("Your whant one more card ?");
                Console.WriteLine();
                Console.WriteLine("1. Take");
                Console.WriteLine("2. Stay");
                string decision = Console.ReadLine();

               switch(decision)
                {
                    case "1":
                        Console.WriteLine("Your take one more card :");
                        player.playerHand = player.OneMoreCardToPlayer(playingDeck, --cardIndex);
                       
                        if(Deck.DeckValueCalculating(dealer.dealerHand) <= 16)
                        {
                            Console.WriteLine("Dealer take one mor card :");
                            dealer.dealerHand = dealer.OneMoreCardToDealer(playingDeck, --cardIndex);
                            if(Deck.DeckValueCalculating(player.playerHand) > 21)
                            {
                                play = false;
                                break;
                            }
                        }
                        else
                        {
                            Console.WriteLine("Dealer decides to stay!");
                            if (Deck.DeckValueCalculating(player.playerHand) > 21)
                            {
                                play = false;
                                break;
                            }
                           
                        }
                        Console.WriteLine();
                        Console.WriteLine($"Dealer have {dealer.dealerCounter}  cards");
                        Console.WriteLine();
                        Console.WriteLine("Your have next cards :");
                        Deck.PrintDeck(player.playerHand);
                        Console.WriteLine($"Your total score {Deck.DeckValueCalculating(player.playerHand)}");
                        Console.WriteLine();
                        Console.WriteLine("press any key to continue....");
                        break;

                    case "2":
                        do
                        {
                            Console.Clear();
                            Console.WriteLine("You stay !!!");
                            if(Deck.DeckValueCalculating(dealer.dealerHand) <=17)
                            {
                                Console.WriteLine("Dealer take one more card ");
                                dealer.dealerHand = dealer.OneMoreCardToDealer(playingDeck, --cardIndex);
                            }
                            else
                            {
                                Console.WriteLine("Dealer decides to stay !!!");
                                play = false;
                                break;
                            }
                        }
                        while (play);

                        Console.WriteLine();
                        Console.WriteLine($"Dealer have {dealer.dealerCounter} cards");
                        Console.WriteLine("You have next cards :");
                        Deck.PrintDeck(player.playerHand);
                        Console.WriteLine($"Your totatl score {Deck.DeckValueCalculating(player.playerHand)}");
                        Console.WriteLine();
                        Console.WriteLine("press any key to continue....");
                        break;

                    default:
                        Console.WriteLine("Incorrect input...");
                        break;
                }
            }
            while (play);
        }
        public bool GameResult()
        {
            Console.WriteLine("For current session :");
            Console.WriteLine($"You wins {playerWinCounter}");
            Console.WriteLine($"Dealer wins {dealerWinCounter}");
            while(true)
            {
                Console.WriteLine();
                Console.WriteLine("If you want to exit, say 'No' , to play more 'Yes'");
                string decision = (Console.ReadLine().ToLower());
                if(decision =="yes")
                {
                    Console.Clear();
                    return true;
                }
                else if (decision == "no")
                {
                    return false;
                }
                else
                {
                    Console.WriteLine("Wrong input ");
                }
            }
        }

    }
}
