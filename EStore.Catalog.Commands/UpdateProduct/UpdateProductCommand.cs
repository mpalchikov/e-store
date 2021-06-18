using MediatR;
using System;
using System.Collections.Generic;
using System.Text;

namespace EStore.Catalog.Commands.UpdateProduct
{
    public class UpdateProductCommand : IRequest
    {
        public Guid Id { get; set; }
        public string Title { get; set; }
        public string Description { get; set; }
        public decimal Price { get; set; }
    }
}
