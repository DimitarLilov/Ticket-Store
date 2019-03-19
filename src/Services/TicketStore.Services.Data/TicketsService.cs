namespace TicketStore.Services.Data
{
    using System.Linq;
    using System.Threading.Tasks;
    using AutoMapper;
    using TicketStore.Common.Mapping;
    using TicketStore.Data.Common.Repositories;
    using TicketStore.Data.Models;
    using TicketStore.Services.Data.Interfaces;
    using TicketStore.Web.Shared.Tickets;

    public class TicketsService : ITicketsService
    {
        private readonly IRepository<Ticket> ticketsRepository;

        public TicketsService(IRepository<Ticket> ticketsRepository)
        {
            this.ticketsRepository = ticketsRepository;
        }

        public async Task<int> AddTicket(TicketRequestModel model)
        {
            var ticket = Mapper.Map<Ticket>(model);

            await this.ticketsRepository.AddAsync(ticket);
            await this.ticketsRepository.SaveChangesAsync();

            return ticket.Id;
        }

        public async Task DeleteTicket(int id)
        {
            var ticket = this.ticketsRepository.All().FirstOrDefault(i => i.Id == id);

            this.ticketsRepository.Delete(ticket);

            await this.ticketsRepository.SaveChangesAsync();
        }

        public async Task<TicketResponseModel> EditTicket(int id, TicketRequestModel model)
        {
            var ticket = Mapper.Map<Ticket>(model);
            ticket.Id = id;
            this.ticketsRepository.Update(ticket);
            await this.ticketsRepository.SaveChangesAsync();

            return Mapper.Map<TicketResponseModel>(model);
        }

        public TicketDetailsResponseModel GetEvetById(int id)
        {
            var ticket = this.ticketsRepository.All().Where(e => e.Id == id);

            return ticket.To<TicketDetailsResponseModel>().FirstOrDefault();
        }
    }
}
