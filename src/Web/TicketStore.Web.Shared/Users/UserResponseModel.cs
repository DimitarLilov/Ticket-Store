namespace TicketStore.Web.Shared.Users
{
    using TicketStore.Common.Mapping;
    using TicketStore.Data.Models;

    public class UserResponseModel : IMapFrom<ApplicationUser>
    {
        public string Id { get; set; }

        public string FirstName { get; set; }

        public string LastName { get; set; }

        public string Email { get; set; }
    }
}
