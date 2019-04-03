namespace TicketStore.Web.Controllers
{
    using System.Security.Claims;
    using System.Threading.Tasks;

    using Microsoft.AspNetCore.Authentication.JwtBearer;
    using Microsoft.AspNetCore.Authorization;
    using Microsoft.AspNetCore.Http;
    using Microsoft.AspNetCore.Mvc;

    using TicketStore.Services.Data.Interfaces;
    using TicketStore.Web.Infrastructure.Extensions;
    using TicketStore.Web.Shared.Tickets;

    public class TicketsController : ApiController
    {
        private readonly ITicketsService ticketsService;
        private readonly IEventsService eventsService;

        public TicketsController(ITicketsService ticketsService, IEventsService eventsService)
        {
            this.ticketsService = ticketsService;
            this.eventsService = eventsService;
        }

        [HttpGet("{id}")]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        [ProducesDefaultResponseType]
        public ActionResult<TicketDetailsResponseModel> Details(int id)
        {
            TicketDetailsResponseModel ticket = this.ticketsService.GetEvetById(id);
            if (ticket == null)
            {
                return this.NotFound();
            }

            return this.Ok(ticket);
        }

        [HttpPost]
        [Authorize(Roles = "Administrator", AuthenticationSchemes = JwtBearerDefaults.AuthenticationScheme)]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        [ProducesResponseType(StatusCodes.Status401Unauthorized)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        [ProducesDefaultResponseType]
        public async Task<ActionResult<int>> Create([FromBody]TicketRequestModel model)
        {
            if (!this.HttpContext.User.IsInRole("Administrator"))
            {
                return this.Unauthorized();
            }

            var eventDb = this.eventsService.GetEvetById(model.EventId);

            if (eventDb == null)
            {
                return this.NotFound();
            }

            if (model == null || !this.ModelState.IsValid)
            {
                return this.BadRequest(this.ModelState.GetFirstError());
            }

            var ticket = await this.ticketsService.AddTicket(model);
            return this.Ok(ticket);
        }

        [HttpPut("{id}")]
        [Authorize(Roles = "Administrator", AuthenticationSchemes = JwtBearerDefaults.AuthenticationScheme)]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        [ProducesResponseType(StatusCodes.Status401Unauthorized)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        [ProducesDefaultResponseType]
        public async Task<ActionResult<TicketResponseModel>> Edit(int id, [FromBody]TicketRequestModel model)
        {
            if (!this.HttpContext.User.IsInRole("Administrator"))
            {
                return this.Unauthorized();
            }

            var eventDb = this.eventsService.GetEvetById(model.EventId);

            if (eventDb == null)
            {
                return this.NotFound();
            }

            if (model == null || !this.ModelState.IsValid)
            {
                return this.BadRequest(this.ModelState.GetFirstError());
            }

            var ticket = await this.ticketsService.EditTicket(id, model);
            return this.Ok(ticket);
        }

        [HttpPost("{id}/buy")]
        [Authorize(Roles = "Administrator", AuthenticationSchemes = JwtBearerDefaults.AuthenticationScheme)]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        [ProducesResponseType(StatusCodes.Status401Unauthorized)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        [ProducesDefaultResponseType]
        public async Task<ActionResult<TicketResponseModel>> Buy(int id, [FromBody]TicketRequestModel model)
        {
            if (model == null || !this.ModelState.IsValid)
            {
                return this.BadRequest(this.ModelState.GetFirstError());
            }
            var user = this.HttpContext.User.FindFirst(ClaimTypes.NameIdentifier).Value;
            await this.ticketsService.BuyTicket(id, user);
            return this.Ok();
        }

        [HttpDelete("{id}")]
        [Authorize(Roles = "Administrator", AuthenticationSchemes = JwtBearerDefaults.AuthenticationScheme)]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        [ProducesResponseType(StatusCodes.Status401Unauthorized)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        [ProducesDefaultResponseType]
        public async Task<ActionResult> Delete(int id)
        {
            var ticket = this.ticketsService.GetEvetById(id);

            if (ticket == null)
            {
                return this.NotFound();
            }

            if (!this.HttpContext.User.IsInRole("Administrator"))
            {
                return this.Unauthorized();
            }

            await this.ticketsService.DeleteTicket(id);

            return this.Ok();
        }
    }
}