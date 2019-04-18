namespace TicketStore.Services.Data.Interfaces
{
    using System;
    using System.Collections.Generic;
    using System.Linq.Expressions;
    using System.Threading.Tasks;
    using TicketStore.Data.Models;
    using TicketStore.Web.Shared.Events;
    using TicketStore.Web.Shared.Tickets;

    public interface IEventsService
    {
        AllEventsResponseModel GetAllEvents(
            Expression<Func<Event, bool>> predicate = null,
            Expression<Func<Event, object>> orderBy = null,
            Expression<Func<Event, object>> orderByDescending = null,
            int? skip = null,
            int? take = null);

        EventDetailsResponseModel GetEvetById(int id);

        Task<int> AddEvent(CreateEventRequestModel model);

        Task<EditEventResponseModel> EditEvent(int id, EditEventRequestModel model);

        Task DeleteEvent(int id);

        IEnumerable<EventListItem> GetEventsByCategoryId(int id);

        IEnumerable<TicketResponseModel> GetEvetTickets(int id);

        Expression<Func<Event, object>> GetSortOrderExpression(string sortOrder);
    }
}
