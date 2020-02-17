using System.Net;

namespace Shuffler.Data.Rules
{
	public class DeckInstanceMustShuffleOnlyOnceException : BusinessRulesException
	{
		private const string message = "Deck instance must shuffle only once";

		public DeckInstanceMustShuffleOnlyOnceException() : base(HttpStatusCode.BadRequest, message) { }
	}
}
