using MediatR;
using Shuffler.Domain;
using System.Threading;
using System.Threading.Tasks;

namespace Shuffler.Api.Domain.UseCases
{
	public class ApiRequestEvent : IRequest<CardDto[]> { }

	public class ApiShuffleUseCaseHandler : IRequestHandler<ApiRequestEvent, CardDto[]>
	{
		private IDeck deck;

		public ApiShuffleUseCaseHandler(IDeck deck)
		{
			this.deck = deck;
		}

		public async Task<CardDto[]> Handle(ApiRequestEvent request, CancellationToken cancellationToken)
		{
			return await deck.Shuffle();
		}
	}
}
