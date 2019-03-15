namespace TicketStore.Web.Controllers
{
    using System.Threading.Tasks;

    using TicketStore.Data.Models;

    using Microsoft.AspNetCore.Authorization;
    using Microsoft.AspNetCore.Identity;
    using Microsoft.AspNetCore.Mvc;
    using TicketStore.Web.Shared.Account;
    using Microsoft.AspNetCore.Http;

    [AllowAnonymous]
    public class AccountController : ApiController
    {
        private readonly UserManager<ApplicationUser> userManager;

        public AccountController(UserManager<ApplicationUser> userManager)
        {
            this.userManager = userManager;
        }

        [HttpPost("{register}")]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        public async Task<IActionResult> Register([FromBody]UserRegisterRequestModel model)
        {
            if (model == null || !this.ModelState.IsValid)
            {
                return this.BadRequest();
            }

            var user = new ApplicationUser
            {
                Email = model.Email,
                UserName = model.Email,
                FirstName = model.FirstName,
                LastName = model.LastName
            };

            var result = await this.userManager.CreateAsync(user, model.Password);

            if (result.Succeeded)
            {
                return this.Ok();
            }

            return this.BadRequest();
        }
    }
}
