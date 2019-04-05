namespace TicketStore.Services.Data.Interfaces
{
    using System.Collections.Generic;
    using TicketStore.Web.Shared.Orders;

    public interface IOrdersService
    {
        IEnumerable<OrderResponseModel> GetAllOrders();
    }
}
