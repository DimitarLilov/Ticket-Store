namespace TicketStore.Data.Models
{
    using TicketStore.Data.Common.Models;

    public class AdType : BaseModel<int>
    {
        public string Type { get; set; }
    }
}
