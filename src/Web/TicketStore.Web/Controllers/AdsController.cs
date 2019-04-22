namespace TicketStore.Web.Controllers
{
    using Microsoft.AspNetCore.Http;
    using Microsoft.AspNetCore.Mvc;
    using System.Collections.Generic;
    using TicketStore.Services.Data.Interfaces;
    using TicketStore.Web.Shared.Ads;

    public class AdsController : ApiController
    {
        public readonly IAdsService adsService;

        public AdsController(IAdsService adsService)
        {
            this.adsService = adsService;
        }

        [HttpGet]
        [ProducesResponseType(StatusCodes.Status200OK)]
        public ActionResult<IEnumerable<AdResponseModel>> Index(int page)
        {
            var ads = this.adsService.GetAllAds();

            return this.Ok(ads);
        }

        [HttpGet("{type}")]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        [ProducesDefaultResponseType]
        public ActionResult<AdResponseModel> Details(string type)
        {
            if (!this.adsService.ContainsAdsType(type))
            {
                return this.NotFound();
            }
            var ads = this.adsService.GetAdsByType(type);
            return this.Ok(ads);
        }
    }
}