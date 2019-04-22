namespace TicketStore.Web.Controllers
{
    using TicketStore.Services.Data.Interfaces;

    public class AdsController : ApiController
    {
        public readonly IAdsService adsService;

        public AdsController(IAdsService adsService)
        {
            this.adsService = adsService;
        }
    }
}