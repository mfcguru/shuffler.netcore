using AutoMapper;
using Shuffler.Data.Rules;
using Shuffler.Domain.Enums;
using System;
using System.Threading.Tasks;

namespace Shuffler.Domain
{
    public class Deck : IDeck
    {
        private const int MaximumCards = 52;
        private Card[] cards = new Card[MaximumCards];

        private volatile bool wasAlreadyShuffled = false;

        public Deck() => InitializeDeck();

		public async Task<CardDto[]> Shuffle()
		{
            return await Task.Run(() => 
            {
                if (wasAlreadyShuffled == true) throw new DeckInstanceMustShuffleOnlyOnceException();

                wasAlreadyShuffled = true;

                var r = new Random();
                //  Based on Java code from wikipedia:
                //  http://en.wikipedia.org/wiki/Fisher-Yates_shuffle
                for (int n = cards.Length - 1; n > 0; --n)
                {
                    int k = r.Next(n + 1);
                    var temp = cards[n];
                    cards[n] = cards[k];
                    cards[k] = temp;
                }

                return Mapper.Map<CardDto[]>(cards);
            });
		}

        private void InitializeDeck()
        {
            var index = 0;

            cards[index++] = new Card { Suit = CardSuitEnum.Club, Rank = CardRankEnum.Two, ImageFilename = "2C" };
            cards[index++] = new Card { Suit = CardSuitEnum.Club, Rank = CardRankEnum.Three, ImageFilename = "3C" };
            cards[index++] = new Card { Suit = CardSuitEnum.Club, Rank = CardRankEnum.Four, ImageFilename = "4C" };
            cards[index++] = new Card { Suit = CardSuitEnum.Club, Rank = CardRankEnum.Five, ImageFilename = "5C" };
            cards[index++] = new Card { Suit = CardSuitEnum.Club, Rank = CardRankEnum.Six, ImageFilename = "6C" };
            cards[index++] = new Card { Suit = CardSuitEnum.Club, Rank = CardRankEnum.Seven, ImageFilename = "7C" };
            cards[index++] = new Card { Suit = CardSuitEnum.Club, Rank = CardRankEnum.Eigth, ImageFilename = "8C" };
            cards[index++] = new Card { Suit = CardSuitEnum.Club, Rank = CardRankEnum.Nine, ImageFilename = "9C" };
            cards[index++] = new Card { Suit = CardSuitEnum.Club, Rank = CardRankEnum.Ten, ImageFilename = "10C" };
            cards[index++] = new Card { Suit = CardSuitEnum.Club, Rank = CardRankEnum.Jack, ImageFilename = "JC" };
            cards[index++] = new Card { Suit = CardSuitEnum.Club, Rank = CardRankEnum.Queeen, ImageFilename = "QC" };
            cards[index++] = new Card { Suit = CardSuitEnum.Club, Rank = CardRankEnum.King, ImageFilename = "KC" };
            cards[index++] = new Card { Suit = CardSuitEnum.Club, Rank = CardRankEnum.Ace, ImageFilename = "AC" };

            cards[index++] = new Card { Suit = CardSuitEnum.Spade, Rank = CardRankEnum.Two, ImageFilename = "2S" };
            cards[index++] = new Card { Suit = CardSuitEnum.Spade, Rank = CardRankEnum.Three, ImageFilename = "3S" };
            cards[index++] = new Card { Suit = CardSuitEnum.Spade, Rank = CardRankEnum.Four, ImageFilename = "4S" };
            cards[index++] = new Card { Suit = CardSuitEnum.Spade, Rank = CardRankEnum.Five, ImageFilename = "5S" };
            cards[index++] = new Card { Suit = CardSuitEnum.Spade, Rank = CardRankEnum.Six, ImageFilename = "6S" };
            cards[index++] = new Card { Suit = CardSuitEnum.Spade, Rank = CardRankEnum.Seven, ImageFilename = "7S" };
            cards[index++] = new Card { Suit = CardSuitEnum.Spade, Rank = CardRankEnum.Eigth, ImageFilename = "8S" };
            cards[index++] = new Card { Suit = CardSuitEnum.Spade, Rank = CardRankEnum.Nine, ImageFilename = "9S" };
            cards[index++] = new Card { Suit = CardSuitEnum.Spade, Rank = CardRankEnum.Ten, ImageFilename = "10S" };
            cards[index++] = new Card { Suit = CardSuitEnum.Spade, Rank = CardRankEnum.Jack, ImageFilename = "JS" };
            cards[index++] = new Card { Suit = CardSuitEnum.Spade, Rank = CardRankEnum.Queeen, ImageFilename = "QS" };
            cards[index++] = new Card { Suit = CardSuitEnum.Spade, Rank = CardRankEnum.King, ImageFilename = "KS" };
            cards[index++] = new Card { Suit = CardSuitEnum.Spade, Rank = CardRankEnum.Ace, ImageFilename = "AS" };

            cards[index++] = new Card { Suit = CardSuitEnum.Heart, Rank = CardRankEnum.Two, ImageFilename = "2H" };
            cards[index++] = new Card { Suit = CardSuitEnum.Heart, Rank = CardRankEnum.Three, ImageFilename = "3H" };
            cards[index++] = new Card { Suit = CardSuitEnum.Heart, Rank = CardRankEnum.Four, ImageFilename = "4H" };
            cards[index++] = new Card { Suit = CardSuitEnum.Heart, Rank = CardRankEnum.Five, ImageFilename = "5H" };
            cards[index++] = new Card { Suit = CardSuitEnum.Heart, Rank = CardRankEnum.Six, ImageFilename = "6S" };
            cards[index++] = new Card { Suit = CardSuitEnum.Heart, Rank = CardRankEnum.Seven, ImageFilename = "7H" };
            cards[index++] = new Card { Suit = CardSuitEnum.Heart, Rank = CardRankEnum.Eigth, ImageFilename = "8H" };
            cards[index++] = new Card { Suit = CardSuitEnum.Heart, Rank = CardRankEnum.Nine, ImageFilename = "9H" };
            cards[index++] = new Card { Suit = CardSuitEnum.Heart, Rank = CardRankEnum.Ten, ImageFilename = "10H" };
            cards[index++] = new Card { Suit = CardSuitEnum.Heart, Rank = CardRankEnum.Jack, ImageFilename = "JH" };
            cards[index++] = new Card { Suit = CardSuitEnum.Heart, Rank = CardRankEnum.Queeen, ImageFilename = "QH" };
            cards[index++] = new Card { Suit = CardSuitEnum.Heart, Rank = CardRankEnum.King, ImageFilename = "KH" };
            cards[index++] = new Card { Suit = CardSuitEnum.Heart, Rank = CardRankEnum.Ace, ImageFilename = "AH" };

            cards[index++] = new Card { Suit = CardSuitEnum.Diamond, Rank = CardRankEnum.Two, ImageFilename = "2D" };
            cards[index++] = new Card { Suit = CardSuitEnum.Diamond, Rank = CardRankEnum.Three, ImageFilename = "3D" };
            cards[index++] = new Card { Suit = CardSuitEnum.Diamond, Rank = CardRankEnum.Four, ImageFilename = "4D" };
            cards[index++] = new Card { Suit = CardSuitEnum.Diamond, Rank = CardRankEnum.Five, ImageFilename = "5D" };
            cards[index++] = new Card { Suit = CardSuitEnum.Diamond, Rank = CardRankEnum.Six, ImageFilename = "6D" };
            cards[index++] = new Card { Suit = CardSuitEnum.Diamond, Rank = CardRankEnum.Seven, ImageFilename = "7D" };
            cards[index++] = new Card { Suit = CardSuitEnum.Diamond, Rank = CardRankEnum.Eigth, ImageFilename = "8D" };
            cards[index++] = new Card { Suit = CardSuitEnum.Diamond, Rank = CardRankEnum.Nine, ImageFilename = "9D" };
            cards[index++] = new Card { Suit = CardSuitEnum.Diamond, Rank = CardRankEnum.Ten, ImageFilename = "10D" };
            cards[index++] = new Card { Suit = CardSuitEnum.Diamond, Rank = CardRankEnum.Jack, ImageFilename = "JD" };
            cards[index++] = new Card { Suit = CardSuitEnum.Diamond, Rank = CardRankEnum.Queeen, ImageFilename = "QD" };
            cards[index++] = new Card { Suit = CardSuitEnum.Diamond, Rank = CardRankEnum.King, ImageFilename = "KD" };
            cards[index++] = new Card { Suit = CardSuitEnum.Diamond, Rank = CardRankEnum.Ace, ImageFilename = "AD" };
        }
    }
}
