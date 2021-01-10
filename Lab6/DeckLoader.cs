using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace lab6
{
	class DeckLoader
    {
        public static List<Card> LoadDeck()
        {

            List<Card> deck = new List<Card>();
            for (int i = 2; i < 15; i++)
            {
                for (int j = 1; j < 5; j++)
                {
                    string rank = "";
                    switch (i)
                    {
                        case 11:
                            rank += "J"; break;
                        case 12:
                            rank += "Q"; break;
                        case 13:
                            rank += "K"; break;
                        case 14:
                            rank += "A"; break;
                        default: rank += i; break;
                    }
                    Card temp = CardParser(rank, "" + j);
                    deck.Add(temp);
                }
            }
            return deck;
        }

        private static Card CardParser(string rank, string suit)
        {
            int cardRank = -1;
            char cardSuit = ' ';

            if (rank == "10")
            {
                cardRank = 10;
            }
            else if (rank.Length == 1)
            {
                if (rank[0] >= '2' && rank[0] <= '9')
                {
                    cardRank = rank[0] - '0';
                }
                else
                {
                    switch (rank[0])
                    {
                        case 'J': cardRank = 11; break;
                        case 'Q': cardRank = 12; break;
                        case 'K': cardRank = 13; break;
                        case 'A': cardRank = 14; break;
                    }
                }
            }

            if (suit.Length == 1 && suit[0] >= '1' && suit[0] <= '4')
            {
                cardSuit = suit[0];
            }

            if (cardRank == -1 || cardSuit == ' ')
            {
                throw new Exception("Card parser exception");
            }

            return new Card(cardRank, cardSuit);
		}
    };
}
