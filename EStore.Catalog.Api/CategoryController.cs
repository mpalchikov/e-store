using EStore.Catalog.Api.Models;
using EStore.Catalog.Commands.CreateCategory;
using EStore.Catalog.Commands.UpdateCategory;
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

            return Created("categories", categoryId);
        }

        [HttpPut, Route("api/categories/{id}")]
        public async Task<IActionResult> Update(Guid id, [FromBody] UpdateCategoryRequest request)
        {
            var command = new UpdateCategoryCommand
            {
                Id = id,
                Title = request.Title,
                Description = request.Description,
                ParentCategoryId = request.ParentCategoryId
            };

            await _mediator.Send(command);

            return Ok();
        }
    }
}
