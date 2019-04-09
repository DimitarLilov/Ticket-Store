namespace TicketStore.Web.Shared.Users
{
    using TicketStore.Common.Mapping;
    using TicketStore.Data.Models;

    public class UserNameResponseModel : IMapFrom<ApplicationUser>
    {
        public string FirstName { get; set; }

        public string LastName { get; set; }
    }
}
