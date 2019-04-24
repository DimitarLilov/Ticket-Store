namespace TicketStore.Web.Shared.Ads
{
    using TicketStore.Common.Mapping;
    using TicketStore.Data.Models;

    public class AdTypeResponseModel : IMapFrom<AdType>
    {
        public string Type { get; set; }
    }
}
