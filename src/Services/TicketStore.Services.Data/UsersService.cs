namespace TicketStore.Services.Data
{
    using System.Collections.Generic;
    using System.Linq;
    using AutoMapper;
    using TicketStore.Common.Mapping;
    using TicketStore.Data.Common.Repositories;
    using TicketStore.Data.Models;
    using TicketStore.Services.Data.Interfaces;
    using TicketStore.Web.Shared.Users;

    public class UsersService : IUsersService
    {
        private readonly IRepository<ApplicationUser> usersRepository;
        private readonly IRepository<UserTickets> ordersRepository;

        public UsersService(IRepository<ApplicationUser> usersRepository, IRepository<UserTickets> ordersRepository)
        {
            this.usersRepository = usersRepository;
            this.ordersRepository = ordersRepository;
        }

        public IEnumerable<UserTicketsResponseModel> GetUserTickets(string userId)
        {
            return this.ordersRepository.All().Where(o => o.UserId == userId).To<UserTicketsResponseModel>().ToList();
        }
    }
}
