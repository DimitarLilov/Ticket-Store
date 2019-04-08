namespace TicketStore.Services.Data
{
    using System.Collections.Generic;
    using System.Threading.Tasks;
    using TicketStore.Common.Mapping;
    using TicketStore.Data.Common.Repositories;
    using TicketStore.Data.Models;
    using TicketStore.Services.Data.Interfaces;
    using TicketStore.Web.Shared.Orders;

    public class OrdersService : IOrdersService
    {

        private readonly IRepository<UserTickets> ordersRepository;

        public OrdersService(IRepository<UserTickets> ordersRepository)
        {
            this.ordersRepository = ordersRepository;
        }

        public async Task Activate(string id)
        {
            var order = this.ordersRepository.GetById(id);
            order.Active = true;

            this.ordersRepository.Update(order);
            await this.ordersRepository.SaveChangesAsync();
        }

        public IEnumerable<OrderResponseModel> GetAllOrders()
        {
            return this.ordersRepository.All().To<OrderResponseModel>();
        }
    }
}
