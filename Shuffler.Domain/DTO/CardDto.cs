using System;

namespace Shuffler.Domain
{
	public class CardDto
	{
		public Guid Key { get; set; }
		public int Suit { get; set; }
		public int Rank { get; set; }
		public string ImageUrl { get; set; }
	}
}
