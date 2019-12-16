using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BlackJack_Game
{
    public struct Game
    {
        public Card[] playingDeck;
        public static int cardIndex;
        public int dealerWinCounter;
        public int playerWinCounter;

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

        internal bool GameResult()
        {
            throw new NotImplementedException();
        }


        public void ChoiceOptionIfDealerFirst(Dealer dealer, Player player)
        {
            throw new NotImplementedException();
        }

        internal bool CheckAces(Dealer dealer, Player player)
        {
            throw new NotImplementedException();
        }

        internal void ChoiceOptionIfPlayerFirst(Dealer dealer, Player player)
        {
            throw new NotImplementedException();
        }
    }
}
