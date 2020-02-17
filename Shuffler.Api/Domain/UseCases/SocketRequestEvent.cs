using MediatR;
using Microsoft.AspNetCore.SignalR;
using Shuffler.Api.Hubs;
using Shuffler.Domain;
using System.Threading;
using System.Threading.Tasks;

namespace Shuffler.Api.Domain.UseCases
{
	public class SocketRequestEvent : IRequest { }

	public class SocketShuffleUseCaseHandler : IRequestHandler<SocketRequestEvent>
	{
		private DeckHub hub;
		private IDeck deck;

		public SocketShuffleUseCaseHandler(Hub hub, IDeck deck)
		{
			this.hub = (DeckHub) hub;
			this.deck = deck;
		}

		public async Task<Unit> Handle(SocketRequestEvent request, CancellationToken cancellationToken)
		{
			await hub.SendMessage(deck);

			return await Task.FromResult(Unit.Value);
		}
	}
}
