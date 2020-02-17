using Microsoft.AspNetCore.SignalR;
using Shuffler.Domain;
using System.Threading.Tasks;

namespace Shuffler.Api.Hubs
{
	public class DeckHub : Hub
	{
		private IHubContext<DeckHub> context;

		public DeckHub(IHubContext<DeckHub> context) => this.context = context;

		public async Task SendMessage(IDeck deck)
		{
			await context.Clients.All.SendAsync("SocketShuffle", await deck.Shuffle());
		}
	}
}
