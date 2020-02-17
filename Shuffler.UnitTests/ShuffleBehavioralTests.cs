using Microsoft.VisualStudio.TestTools.UnitTesting;
using Shuffler.Data.Rules;
using Shuffler.Domain;
using System.Threading.Tasks;

namespace Shuffler.UnitTests
{
	[TestClass]
	public class ShuffleBehavioralTests
	{
		public ShuffleBehavioralTests()
		{
			AutoMapperConfiguration.Configure();
		}

		[TestMethod]
		[ExpectedException(typeof(DeckInstanceMustShuffleOnlyOnceException))]
		public async Task DeckInstanceMustShuffleOnlyOnce()
		{
			var deck = new Deck();
			await deck.Shuffle();
			await deck.Shuffle();
		}
	}
}
