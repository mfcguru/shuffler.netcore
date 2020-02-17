using Shuffler.Domain;
using Shuffler.Domain.Enums;
using System;
using System.Threading.Tasks;

namespace Shuffler.ConsoleApp
{
	class Program
	{
		static async Task Main(string[] args)
		{
			var deck = new Deck();
			var cards = await deck.Shuffle();

			foreach (var card in cards)
			{
				Console.WriteLine(string.Format("{0} of {1}s",
					Enum.GetName(typeof(CardRankEnum), card.Rank),
					Enum.GetName(typeof(CardSuitEnum), card.Suit)));
			}
		}
	}
}
