namespace TicketStore.Services.Data.Interfaces
{
    using System;
    using System.Collections.Generic;
    using System.Linq.Expressions;
    using System.Threading.Tasks;
    using TicketStore.Data.Models;
    using TicketStore.Web.Shared.Events;

    public interface IEventsService
    {
        IEnumerable<EventListItem> GetAllEvents(
            Expression<Func<Event, bool>> predicate = null,
            Expression<Func<Event, object>> orderBy = null,
            int? skip = null,
            int? take = null);

        EventDetailsResponseModel GetEvetById(int id);
        Task<int> AddEvent(CreateEventRequestModel model);
        Task<EditEventRequestModel> EditEvent(int id, EditEventRequestModel model);
        Task DeleteEvent(int id);
    }
}
