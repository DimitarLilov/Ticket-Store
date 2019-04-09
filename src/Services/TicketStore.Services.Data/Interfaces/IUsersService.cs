namespace TicketStore.Services.Data.Interfaces
{
    using System.Collections.Generic;
    using TicketStore.Web.Shared.Users;

    public interface IUsersService
    {
        IEnumerable<UserTicketsResponseModel> GetUserTickets(string userId);
    }
}
