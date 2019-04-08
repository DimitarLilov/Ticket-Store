namespace TicketStore.Services.Data.Interfaces
{
    using System.Collections.Generic;
    using System.Threading.Tasks;
    using TicketStore.Web.Shared.Orders;

    public interface IOrdersService
    {
        IEnumerable<OrderResponseModel> GetAllOrders();

        Task Activate(string id);
    }
}
