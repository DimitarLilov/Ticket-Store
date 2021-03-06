﻿namespace TicketStore.Web.Controllers
{
    using System;
    using System.Collections.Generic;
    using System.Linq.Expressions;
    using System.Threading.Tasks;

    using Microsoft.AspNetCore.Authentication.JwtBearer;
    using Microsoft.AspNetCore.Authorization;
    using Microsoft.AspNetCore.Http;
    using Microsoft.AspNetCore.Mvc;

    using TicketStore.Common;
    using TicketStore.Data.Models;
    using TicketStore.Services.Data.Interfaces;
    using TicketStore.Web.Infrastructure.Extensions;
    using TicketStore.Web.Shared.Common;
    using TicketStore.Web.Shared.Events;
    using TicketStore.Web.Shared.Tickets;

    public class EventsController : ApiController
    {
        private readonly IEventsService eventsService;

        public EventsController(IEventsService eventsService)
        {
            this.eventsService = eventsService;
        }

        [HttpGet]
        [ProducesDefaultResponseType]
        [ProducesResponseType(StatusCodes.Status200OK)]
        public ActionResult<IEnumerable<EventListItem>> Index([FromQuery]FilterResponseModel filter)
        {
            Expression<Func<Event, object>> orderByExpression = this.eventsService.GetSortOrderExpression(filter.OrderBy);
            Expression<Func<Event, object>> orderByDecendingExpression = this.eventsService.GetSortOrderExpression(filter.OrderByDecending);

            if (filter.Page != null && filter.Page != 0)
            {
                var skip = (filter.Page - 1) * filter.Limit;
                return this.Ok(this.eventsService.GetAllEvents(null, orderByExpression, orderByDecendingExpression, skip, filter.Limit));
            }

            return this.Ok(this.eventsService.GetAllEvents(null, orderByExpression, orderByDecendingExpression, null, filter.Limit));
        }

        [HttpGet("{id}")]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        [ProducesDefaultResponseType]
        public ActionResult<EventDetailsResponseModel> Details(int id)
        {
            var eventDetails = this.eventsService.GetEvetById(id);
            if (eventDetails == null)
            {
                return this.NotFound();
            }

            return this.Ok(eventDetails);
        }

        [HttpGet("{id}/tickets")]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        [ProducesDefaultResponseType]
        public ActionResult<IEnumerable<TicketResponseModel>> Tickets(int id)
        {
            var eventDetails = this.eventsService.GetEvetTickets(id);
            if (eventDetails == null)
            {
                return this.NotFound();
            }

            return this.Ok(eventDetails);
        }

        [HttpPost]
        [Authorize(Roles = GlobalConstants.AdministratorRoleName, AuthenticationSchemes = JwtBearerDefaults.AuthenticationScheme)]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status401Unauthorized)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        [ProducesDefaultResponseType]
        public async Task<ActionResult<EventDetailsResponseModel>> Create([FromBody]CreateEventRequestModel model)
        {
            if (!this.HttpContext.User.IsInRole(GlobalConstants.AdministratorRoleName))
            {
                return this.Unauthorized();
            }

            if (model == null || !this.ModelState.IsValid)
            {
                return this.BadRequest(this.ModelState.GetFirstError());
            }
          
            return this.Ok(await this.eventsService.AddEvent(model));
        }

        [HttpPut("{id}")]
        [Authorize(Roles = GlobalConstants.AdministratorRoleName, AuthenticationSchemes = JwtBearerDefaults.AuthenticationScheme)]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        [ProducesResponseType(StatusCodes.Status401Unauthorized)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        [ProducesDefaultResponseType]
        public async Task<ActionResult<EditEventResponseModel>> Edit(int id, [FromBody]EditEventRequestModel model)
        {
            var eventModel = this.eventsService.GetEvetById(id);

            if (eventModel == null)
            {
                return this.NotFound();
            }

            if (!this.HttpContext.User.IsInRole(GlobalConstants.AdministratorRoleName))
            {
                return this.Unauthorized();
            }

            if (model == null || !this.ModelState.IsValid)
            {
                return this.BadRequest(this.ModelState.GetFirstError());
            }

            return this.Ok(await this.eventsService.EditEvent(id, model));
        }

        [HttpDelete("{id}")]
        [Authorize(Roles = GlobalConstants.AdministratorRoleName, AuthenticationSchemes = JwtBearerDefaults.AuthenticationScheme)]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        [ProducesResponseType(StatusCodes.Status401Unauthorized)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        [ProducesDefaultResponseType]
        public async Task<ActionResult> Delete(int id)
        {
            var eventModel = this.eventsService.GetEvetById(id);

            if (eventModel == null)
            {
                return this.NotFound();
            }

            if (!this.HttpContext.User.IsInRole(GlobalConstants.AdministratorRoleName))
            {
                return this.Unauthorized();
            }

            await this.eventsService.DeleteEvent(id);

            return this.Ok();
        }
    }
}