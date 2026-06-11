using MediatR;
using Microsoft.AspNetCore.Mvc;
using MoveisRental.Core;
using MovieRental.Application.Features.Directors.Commands.CreateDirector;
using MovieRental.Application.Features.Directors.Commands.DeleteDirector;
using MovieRental.Application.Features.Directors.Commands.UpdateDirector;
using MoviesRental.Query.Application.Features.Directors.Queries.GetDirector;
using System.Net;

namespace MoviesRental.WebApi.Controllers
{
    public class DirectorsController : ApiController
    {
        private readonly IMediator _mediator;

        public DirectorsController( IMediator mediator)
        {
            _mediator = mediator;
        }

        [HttpGet("[action]/{fullName}", Name = "GetDirector")]
        [ProducesResponseType(typeof(BaseResponse), (int)HttpStatusCode.OK)]
        [ProducesResponseType((int)HttpStatusCode.NotFound)]
        public async Task<ActionResult> GetDirector([FromRoute] string fullName)
        {
            var query = new GetDirectorQuery(fullName);

            var response = await _mediator.Send(query, HttpContext.RequestAborted);

            if (response is null)
                return CustomResponse((int)HttpStatusCode.NotFound, false);

            return CustomResponse((int)HttpStatusCode.OK, true, response);

        }

        [HttpPost("CreateDirector")]
        [ProducesResponseType(typeof(CreateDirectorResponse), (int)HttpStatusCode.Created)]
        [ProducesResponseType((int)HttpStatusCode.BadRequest)]
        public async Task<ActionResult<CreateDirectorResponse>> CreateDirector(
            [FromBody] CreateDirectorCommand command)
        {
            var response = await _mediator.Send(command, HttpContext.RequestAborted);

            if (response is null)
                return CustomResponse((int)HttpStatusCode.BadRequest, false);

            return CustomResponse((int)HttpStatusCode.Created, true, response);
        }

        [HttpDelete("DeleteDirector/{id:guid}")]
        [ProducesResponseType((int)HttpStatusCode.OK)]
        [ProducesResponseType((int)HttpStatusCode.BadRequest)]
        public async Task<ActionResult> DeleteDirector([FromRoute] Guid id)
        {
            var command = new DeleteDirectorCommand(id);
            var response = await _mediator.Send(command, HttpContext.RequestAborted);

            if (!response)
                return CustomResponse((int)HttpStatusCode.BadRequest, false);

            return CustomResponse((int)HttpStatusCode.OK, true);
        }

    }
}
