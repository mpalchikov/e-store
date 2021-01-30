using EStore.Catalog.Api.Models;
using EStore.Catalog.Commands.CreateCategory;
using MediatR;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Threading.Tasks;

namespace EStore.Catalog.Api
{   
    public class CategoryController : ControllerBase
    {
        private readonly IMediator _mediator;

        public CategoryController(IMediator mediator)
        {
            _mediator = mediator;
        }        

        [HttpPost, Route("api/categories")]
        public async Task<ActionResult<Guid>> Create([FromBody] CreateCategoryRequest request)
        {
            var command = new CreateCategoryCommand
            {
                Title = request.Title,
                Description = request.Description,
                ParentCategoryId = request.ParentCategoryId
            };

            var categoryId = await _mediator.Send(command);

            return Ok(categoryId);
        }
    }
}
