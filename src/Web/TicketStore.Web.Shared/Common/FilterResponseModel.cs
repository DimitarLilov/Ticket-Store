namespace TicketStore.Web.Shared.Common
{
    public class FilterResponseModel
    {
        public int? Page { get; set; }

        public int? Limit { get; set; }

        public string OrderBy { get; set; }

        public string OrderByDecending { get; set; }
    }
}
