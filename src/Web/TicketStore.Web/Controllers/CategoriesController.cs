namespace TicketStore.Web.Controllers
{
    using System;
    using System.Collections.Generic;
    using System.Linq.Expressions;
    using System.Threading.Tasks;

    using Microsoft.AspNetCore.Authentication.JwtBearer;
    using Microsoft.AspNetCore.Authorization;
    using Microsoft.AspNetCore.Http;
    using Microsoft.AspNetCore.Mvc;
    using TicketStore.Common;
    using TicketStore.Data.Models;
    using TicketStore.Services.Data.Interfaces;
    using TicketStore.Web.Infrastructure.Extensions;
    using TicketStore.Web.Shared.Categories;
    using TicketStore.Web.Shared.Common;

    public class CategoriesController : ApiController
    {
        private readonly ICategoriesService categoriesService;

        private readonly IEventsService eventsService;

        public CategoriesController(
            ICategoriesService categoriesService,
            IEventsService eventsService)
        {
            this.categoriesService = categoriesService;
            this.eventsService = eventsService;
        }

        [HttpGet]
        [ProducesResponseType(StatusCodes.Status200OK)]
        public ActionResult<IEnumerable<CategoryResponseModel>> Index(int page)
        {
            var categories = this.categoriesService.GetAllCategories();

            return this.Ok(categories);
        }

        [HttpGet("{id}")]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        [ProducesDefaultResponseType]
        public ActionResult<CategoryDetailsResponseModel> Details(int id, [FromQuery]FilterResponseModel filter)
        {
            var categoryName = this.categoriesService.GetCategoryNameById(id);
            if (string.IsNullOrEmpty(categoryName))
            {
                return this.NotFound();
            }

            var response = new CategoryDetailsResponseModel() { Name = categoryName };

            Expression<Func<Event, object>> orderByExpression = this.eventsService.GetSortOrderExpression(filter.OrderBy);
            Expression<Func<Event, object>> orderByDecendingExpression = this.eventsService.GetSortOrderExpression(filter.OrderByDecending);
            Expression<Func<Event, bool>> getEventsByCatecoryExpresiond = e => e.CategoryId == id;

            if (filter.Page != null && filter.Page != 0)
            {
                var skip = (filter.Page - 1) * filter.Limit;
                response.Events = this.eventsService.GetAllEvents(getEventsByCatecoryExpresiond, orderByExpression, orderByDecendingExpression, skip, filter.Limit).Events;
                return this.Ok(response);
            }

            var events = this.eventsService.GetAllEvents(getEventsByCatecoryExpresiond, orderByExpression, orderByDecendingExpression, null, filter.Limit).Events;
            response.Events = events;
            return this.Ok(response);
        }

        [HttpPost]
        [Authorize(Roles = GlobalConstants.AdministratorRoleName, AuthenticationSchemes = JwtBearerDefaults.AuthenticationScheme)]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status401Unauthorized)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        [ProducesDefaultResponseType]
        public async Task<ActionResult<CategoryDetailsResponseModel>> Create([FromBody]CategoryRequestModel model)
        {
            if (!this.HttpContext.User.IsInRole(GlobalConstants.AdministratorRoleName))
            {
                return this.Unauthorized();
            }

            if (model == null || !this.ModelState.IsValid)
            {
                return this.BadRequest(this.ModelState.GetFirstError());
            }

            return this.Ok(await this.categoriesService.AddCategory(model));
        }

        [HttpPut("{id}")]
        [Authorize(Roles = GlobalConstants.AdministratorRoleName, AuthenticationSchemes = JwtBearerDefaults.AuthenticationScheme)]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        [ProducesResponseType(StatusCodes.Status401Unauthorized)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        [ProducesDefaultResponseType]
        public async Task<ActionResult<CategoryResponseModel>> Edit(int id, [FromBody]CategoryRequestModel model)
        {
            var category = this.categoriesService.GetCategoryById(id);

            if (category == null)
            {
                return this.NotFound();
            }

            if (!this.HttpContext.User.IsInRole(GlobalConstants.AdministratorRoleName))
            {
                return this.Unauthorized();
            }

            if (model == null || !this.ModelState.IsValid)
            {
                return this.BadRequest(this.ModelState.GetFirstError());
            }

            return this.Ok(await this.categoriesService.EditCategory(id, model));
        }

        [HttpDelete("{id}")]
        [Authorize(Roles = GlobalConstants.AdministratorRoleName, AuthenticationSchemes = JwtBearerDefaults.AuthenticationScheme)]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        [ProducesResponseType(StatusCodes.Status401Unauthorized)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        [ProducesDefaultResponseType]
        public async Task<ActionResult> Delete(int id)
        {
            var category = this.categoriesService.GetCategoryById(id);

            if (category == null)
            {
                return this.NotFound();
            }

            if (!this.HttpContext.User.IsInRole(GlobalConstants.AdministratorRoleName))
            {
                return this.Unauthorized();
            }

            await this.categoriesService.DeleteCategory(id);

            return this.Ok();
        }
    }
}