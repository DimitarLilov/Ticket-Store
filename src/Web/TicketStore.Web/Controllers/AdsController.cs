using Microsoft.AspNetCore.Http;

namespace TicketStore.Web.Controllers
{
    using Microsoft.AspNetCore.Authentication.JwtBearer;
    using Microsoft.AspNetCore.Authorization;
    using Microsoft.AspNetCore.Http;
    using Microsoft.AspNetCore.Mvc;
    using System.Collections.Generic;
    using System.Threading.Tasks;
    using TicketStore.Common;
    using TicketStore.Services.Data.Interfaces;
    using TicketStore.Web.Infrastructure.Extensions;
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
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        [ProducesDefaultResponseType]
        public ActionResult<IEnumerable<AdResponseModel>> Index([FromQuery]string type, int page)
        {
            if (!string.IsNullOrEmpty(type))
            {
                if (!this.adsService.ContainsAdsType(type))
                {
                    return this.NotFound();
                }
                return this.Ok(this.adsService.GetAdsByType(type));
            }

            var ads = this.adsService.GetAllAds();

            return this.Ok(ads);
        }

        [HttpPost]
        [Authorize(Roles = GlobalConstants.AdministratorRoleName, AuthenticationSchemes = JwtBearerDefaults.AuthenticationScheme)]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status401Unauthorized)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        [ProducesDefaultResponseType]
        public async Task<ActionResult<AdResponseModel>> Create([FromBody]CreateAdRequestModel model)
        {
            if (!this.HttpContext.User.IsInRole(GlobalConstants.AdministratorRoleName))
            {
                return this.Unauthorized();
            }

            if (model == null || !this.ModelState.IsValid)
            {
                return this.BadRequest(this.ModelState.GetFirstError());
            }

            return this.Ok(await this.adsService.AddAd(model));
        }

    }
}