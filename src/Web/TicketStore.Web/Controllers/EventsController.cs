namespace TicketStore.Web.Controllers
{
    using Microsoft.AspNetCore.Authentication.JwtBearer;
    using Microsoft.AspNetCore.Authorization;
    using Microsoft.AspNetCore.Http;
    using Microsoft.AspNetCore.Mvc;
    using System.Threading.Tasks;
    using TicketStore.Data.Models;
    using TicketStore.Services.Data.Interfaces;
    using TicketStore.Web.Infrastructure.Extensions;
    using TicketStore.Web.Shared.Events;

    public class EventsController : ApiController
    {

        private readonly IEventsService eventsService;

        public EventsController(IEventsService eventsService)
        {
            this.eventsService = eventsService;
        }

        [HttpGet]
        [ProducesResponseType(StatusCodes.Status200OK)]
        public ActionResult<EventsResponseModel> Index(int page)
        {
            var events = this.eventsService.GetAllEvents();

            EventsResponseModel response = new EventsResponseModel { events = events };

            return Ok(response);
        }

        [HttpGet("{id}")]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        [ProducesDefaultResponseType]
        public ActionResult<EventDetailsResponseModel> Details(int id)
        {
            var eventDetails = this.eventsService.GetEvetById(id);
            if(eventDetails == null)
            {
                return this.NotFound();
            }

            return Ok(eventDetails);
        }

        [HttpPost()]
        [Authorize(Roles = "Administrator", AuthenticationSchemes = JwtBearerDefaults.AuthenticationScheme)]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status401Unauthorized)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        [ProducesDefaultResponseType]
        public async  Task<ActionResult<EventDetailsResponseModel>> Create([FromBody]CreateEventRequestModel model)
        {
            if (!this.HttpContext.User.IsInRole("Administrator"))
            {
                return this.Unauthorized();
            }
            if(model == null || !this.ModelState.IsValid)
            {
                return this.BadRequest(this.ModelState.GetFirstError());
            }
          
            return Ok( await this.eventsService.AddEvent(model));
        }

        [HttpPut("{id}")]
        [Authorize(Roles = "Administrator", AuthenticationSchemes = JwtBearerDefaults.AuthenticationScheme)]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        [ProducesResponseType(StatusCodes.Status401Unauthorized)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        [ProducesDefaultResponseType]
        public async Task<ActionResult<EventDetailsResponseModel>> Edit(int id,[FromBody]EditEventRequestModel model)
        {
            var dbEventModel = this.eventsService.GetEvetById(id);

            if (dbEventModel == null)
            {
                return this.NotFound();
            }
            if (!this.HttpContext.User.IsInRole("Administrator"))
            {
                return this.Unauthorized();
            }
            if (model == null || !this.ModelState.IsValid)
            {
                return this.BadRequest(this.ModelState.GetFirstError());
            }

            return Ok(await this.eventsService.EditEvent(id, model));
        }

        [HttpDelete("{id}")]
        [Authorize(Roles = "Administrator", AuthenticationSchemes = JwtBearerDefaults.AuthenticationScheme)]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        [ProducesResponseType(StatusCodes.Status401Unauthorized)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        [ProducesDefaultResponseType]
        public async Task<ActionResult<EventDetailsResponseModel>> Delete(int id)
        {
            var dbEventModel = this.eventsService.GetEvetById(id);

            if (dbEventModel == null)
            {
                return this.NotFound();
            }
            if (!this.HttpContext.User.IsInRole("Administrator"))
            {
                return this.Unauthorized();
            }

            await this.eventsService.DeleteEvent(id);

            return Ok();
        }
    }
}