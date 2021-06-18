using EStore.Catalog.Api.Models;
using EStore.Catalog.Commands.CreateProduct;
using EStore.Catalog.Commands.UpdateProduct;
using EStore.Catalog.Queries.GetProduct;
using EStore.Catalog.Queries.GetProducts;
using MediatR;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace EStore.Catalog.Api
{
    public class ProductController : ControllerBase
    {
        private readonly IMediator _mediator;

        public ProductController(IMediator mediator)
        {
            _mediator = mediator;
        }

        [HttpGet, Route("api/products")]
        public async Task<ActionResult> GetProducts()
        {
            var query = new GetProductsQuery();

            var products = await _mediator.Send(query);

            return Ok(products);
        }

        [HttpGet, Route("api/products/{id}")]
        public async Task<ActionResult> GetProducts(Guid id)
        {
            var query = new GetProductQuery { 
                ProductId = id
            };

            var product = await _mediator.Send(query);

            return Ok(product);
        }

        [HttpPost, Route("api/products")]
        public async Task<ActionResult<Guid>> Create([FromBody] CreateProductRequest request)
        {
            var command = new CreateProductCommand
            {
                Title = request.Title,
                Description = request.Description,
                Price = request.Price
            };

            var productId = await _mediator.Send(command);

            return Created("products", productId);
        }

        [HttpPut, Route("api/products/{id}")]
        public async Task<IActionResult> Update(Guid id, [FromBody] UpdateProductRequest request)
        {
            var command = new UpdateProductCommand
            {
                Id = id,
                Title = request.Title,
                Description = request.Description,
                Price = request.Price
            };

            await _mediator.Send(command);

            return Ok();
        }
    }
}
