namespace TicketStore.Services.Data
{
    using System.Linq;
    using System.Threading.Tasks;
    using AutoMapper;
    using Microsoft.AspNetCore.Identity;
    using TicketStore.Common.Mapping;
    using TicketStore.Data.Common.Repositories;
    using TicketStore.Data.Models;
    using TicketStore.Services.Data.Interfaces;
    using TicketStore.Web.Shared.Tickets;

    public class TicketsService : ITicketsService
    {
        private readonly IRepository<Ticket> ticketsRepository;
        private readonly IRepository<UserTickets> userTicketsRepository;

        private readonly UserManager<ApplicationUser> userManager;

        public TicketsService(IRepository<Ticket> ticketsRepository, IRepository<UserTickets> userTicketsRepository, UserManager<ApplicationUser> userManager)
        {
            this.ticketsRepository = ticketsRepository;
            this.userManager = userManager;
            this.userTicketsRepository = userTicketsRepository;
        }

        public async Task<int> AddTicket(TicketRequestModel model)
        {
            var ticket = Mapper.Map<Ticket>(model);

            await this.ticketsRepository.AddAsync(ticket);
            await this.ticketsRepository.SaveChangesAsync();

            return ticket.Id;
        }

        public async Task BuyTicket(int id, string user)
        {
            UserTickets userTickets = new UserTickets()
            {
                TicketId = id,
                UserId = user,
                Active = false
            };
            await this.userTicketsRepository.AddAsync(userTickets);
            await this.userTicketsRepository.SaveChangesAsync();
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
