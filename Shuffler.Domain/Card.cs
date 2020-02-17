using Shuffler.Domain.Enums;

namespace Shuffler.Domain
{
	public class Card
	{
		public CardSuitEnum Suit { get; set; }
		public CardRankEnum Rank { get; set; }
		public string ImageFilename { get; set; }
	}
}
