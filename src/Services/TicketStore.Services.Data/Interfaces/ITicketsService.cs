namespace TicketStore.Services.Data.Interfaces
{
    using System.Threading.Tasks;
    using TicketStore.Web.Shared.Tickets;

    public interface ITicketsService
    {
        Task<int> AddTicket(TicketRequestModel model);

        TicketDetailsResponseModel GetEvetById(int id);

        Task<TicketResponseModel> EditTicket(int id, TicketRequestModel model);

        Task DeleteTicket(int id);

        Task BuyTicket(BuyTicketRequestModel model, string user);
    }
}
