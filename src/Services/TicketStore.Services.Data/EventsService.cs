namespace TicketStore.Services.Data
{
    using AutoMapper;
    using System;
    using System.Collections.Generic;
    using System.Linq;
    using System.Linq.Expressions;
    using System.Threading.Tasks;
    using TicketStore.Common.Mapping;
    using TicketStore.Data.Common.Repositories;
    using TicketStore.Data.Models;
    using TicketStore.Services.Data.Interfaces;
    using TicketStore.Web.Shared.Events;
    using TicketStore.Web.Shared.Tickets;

    public class EventsService : IEventsService
    {
        private readonly IRepository<Event> eventsRepository;

        public EventsService(IRepository<Event> eventsRepository)
        {
            this.eventsRepository = eventsRepository;
        }

        public async Task<int> AddEvent(CreateEventRequestModel model)
        {
            
            var eventItem = Mapper.Map<Event>(model);

            await this.eventsRepository.AddAsync(eventItem);
            await this.eventsRepository.SaveChangesAsync();

            return eventItem.Id;

        }

        public async Task DeleteEvent(int id)
        {
            var eventItem = this.eventsRepository.All().FirstOrDefault(i => i.Id == id);

            this.eventsRepository.Delete(eventItem);

            await this.eventsRepository.SaveChangesAsync();
        }

        public async Task<EditEventResponseModel> EditEvent(int id, EditEventRequestModel model)
        {
            var editModel = Mapper.Map<Event>(model);
            editModel.Id = id;
            this.eventsRepository.Update(editModel);
            await this.eventsRepository.SaveChangesAsync();

            return Mapper.Map<EditEventResponseModel>(model);
        }

        public IEnumerable<EventListItem> GetAllEvents(
            Expression<Func<Event,bool>> predicate = null,
            Expression<Func<Event,object>> orderBy = null,
            Expression<Func<Event, object>> orderByDescending = null,
            int? skip = null,
            int? take = null)
        {
            var events = this.eventsRepository.All();

            if(predicate != null)
            {
                events = events.Where(predicate);
            }
            if (orderBy != null)
            {
                events = events.OrderBy(orderBy);
            }
            if (orderByDescending != null)
            {
                events = events.OrderByDescending(orderByDescending);
            }
            if (skip != null)
            {
                events = events.Skip(skip.Value);
            }
            if(take != null)
            {
                events = events.Take(take.Value);
            }

            return events.To<EventListItem>().ToList();
        }

        public IEnumerable<EventListItem> GetEventsByCategoryId(int id)
        {
            return this.GetAllEvents(e => e.CategoryId == id).ToList();
        }

        public EventDetailsResponseModel GetEvetById(int id)
        {
            var eventDetails = this.eventsRepository.All().Where(e => e.Id == id);

            return eventDetails.To<EventDetailsResponseModel>().FirstOrDefault();
        }

        public IEnumerable<TicketResponseModel> GetEvetTickets(int id)
        {
            return this.GetEvetById(id).Tickets.ToList();
        }

        public Expression<Func<Event, object>> GetSortOrderExpression(string order)
        {
            if (order != null)
            {
                order = order.ToLower();
            }

            switch (order)
            {
                case "id":
                    return e => e.Id;
                case "date":
                    return e => e.Date;
                case "title":
                    return e => e.Title;
                default:
                    return null;
            }
        }
    }
}
