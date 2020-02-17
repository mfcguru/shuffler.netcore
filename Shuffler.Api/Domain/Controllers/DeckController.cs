using MediatR;
using Microsoft.AspNetCore.Mvc;
using Shuffler.Api.Domain.UseCases;
using Shuffler.Api.Hubs;
using Shuffler.Domain;
using System.Threading.Tasks;

namespace Shuffler.Api.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class DeckController : ControllerBase
    {
        private readonly IMediator mediator;

        public DeckController(IMediator mediator)
        {
            this.mediator = mediator;
        }

        [HttpGet]
        public async Task<ActionResult<CardDto[]>> Shuffle()
        {
            return await mediator.Send(new ApiRequestEvent());
        }

        [HttpGet]
        [Route("socket")]
        public async Task<ActionResult> SocketShuffle()
        {
            await mediator.Send(new SocketRequestEvent());
            return Ok();
        }
    }
}