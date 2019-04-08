namespace TicketStore.Web.Controllers
{
    using System.Collections.Generic;
    using System.Threading.Tasks;
    using Microsoft.AspNetCore.Authentication.JwtBearer;
    using Microsoft.AspNetCore.Authorization;
    using Microsoft.AspNetCore.Http;
    using Microsoft.AspNetCore.Mvc;

    using TicketStore.Common;
    using TicketStore.Services.Data.Interfaces;
    using TicketStore.Web.Shared.Orders;

    public class OrdersController : ApiController
    {
        private readonly IOrdersService ordersService;

        public OrdersController(IOrdersService ordersService)
        {
            this.ordersService = ordersService;
        }

        [HttpGet]
        [Authorize(Roles = GlobalConstants.AdministratorRoleName, AuthenticationSchemes = JwtBearerDefaults.AuthenticationScheme)]
        [ProducesDefaultResponseType]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status401Unauthorized)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        public ActionResult<IEnumerable<OrderResponseModel>> Index()
        {
            if (!this.HttpContext.User.IsInRole(GlobalConstants.AdministratorRoleName))
            {
                return this.Unauthorized();
            }

            return this.Ok(this.ordersService.GetAllOrders());
        }

        [HttpPost("{id}")]
        [Authorize(Roles = GlobalConstants.AdministratorRoleName, AuthenticationSchemes = JwtBearerDefaults.AuthenticationScheme)]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        [ProducesResponseType(StatusCodes.Status401Unauthorized)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        [ProducesDefaultResponseType]
        public async Task<ActionResult> Activate(string id)
        {
            if (!this.HttpContext.User.IsInRole(GlobalConstants.AdministratorRoleName))
            {
                return this.Unauthorized();
            }
            await this.ordersService.Activate(id);
            return this.Ok();
        }
    }
}