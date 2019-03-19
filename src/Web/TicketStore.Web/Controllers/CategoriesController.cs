namespace TicketStore.Web.Controllers
{
    using Microsoft.AspNetCore.Authentication.JwtBearer;
    using Microsoft.AspNetCore.Authorization;
    using Microsoft.AspNetCore.Http;
    using Microsoft.AspNetCore.Mvc;
    using System;
    using System.Collections.Generic;
    using System.Linq.Expressions;
    using System.Threading.Tasks;
    using TicketStore.Data.Models;
    using TicketStore.Services.Data.Interfaces;
    using TicketStore.Web.Infrastructure.Extensions;
    using TicketStore.Web.Shared.Categories;
    using TicketStore.Web.Shared.Events;

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

            return Ok(categories);
        }

        [HttpGet("{id}")]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        [ProducesDefaultResponseType]
        public ActionResult<CategoryDetailsResponseModel> Details(
            int id,
            int? page = null,
            int? pageSize = 10,
            string orderBy = null,
            string orderByDecending = null)
        {
            var categoryName = this.categoriesService.GetCategoryNameById(id);
            if (string.IsNullOrEmpty(categoryName))
            {
                return this.NotFound();
            }

            var response = new CategoryDetailsResponseModel() { Name = categoryName };

            Expression<Func<Event, object>> orderByExpression = this.eventsService.GetSortOrderExpression(orderBy);
            Expression<Func<Event, object>> orderByDecendingExpression = this.eventsService.GetSortOrderExpression(orderByDecending);
            Expression<Func<Event, bool>> getEventsByCatecoryExpresiond = e => e.CategoryId == id;

            if (page != null && page != 0)
            {
                var skip = (page - 1) * pageSize;
                response.Events =  eventsService.GetAllEvents(getEventsByCatecoryExpresiond, orderByExpression, orderByDecendingExpression, skip, pageSize);
                return Ok(response);
            }

            var events = eventsService.GetAllEvents(getEventsByCatecoryExpresiond, orderByExpression, orderByDecendingExpression);
            response.Events = events;
            return Ok(response);
        }

        [HttpPost()]
        [Authorize(Roles = "Administrator", AuthenticationSchemes = JwtBearerDefaults.AuthenticationScheme)]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status401Unauthorized)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        [ProducesDefaultResponseType]
        public async Task<ActionResult<CategoryDetailsResponseModel>> Create([FromBody]CategoryRequestModel model)
        {
            if (!this.HttpContext.User.IsInRole("Administrator"))
            {
                return this.Unauthorized();
            }
            if (model == null || !this.ModelState.IsValid)
            {
                return this.BadRequest(this.ModelState.GetFirstError());
            }

            return Ok(await this.categoriesService.AddCategory(model));
        }

        [HttpPut("{id}")]
        [Authorize(Roles = "Administrator", AuthenticationSchemes = JwtBearerDefaults.AuthenticationScheme)]
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
            if (!this.HttpContext.User.IsInRole("Administrator"))
            {
                return this.Unauthorized();
            }
            if (model == null || !this.ModelState.IsValid)
            {
                return this.BadRequest(this.ModelState.GetFirstError());
            }

            return Ok(await this.categoriesService.EditCategory(id, model));
        }

        [HttpDelete("{id}")]
        [Authorize(Roles = "Administrator", AuthenticationSchemes = JwtBearerDefaults.AuthenticationScheme)]
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
            if (!this.HttpContext.User.IsInRole("Administrator"))
            {
                return this.Unauthorized();
            }

            await this.categoriesService.DeleteCategory(id);

            return Ok();
        }

    }
}