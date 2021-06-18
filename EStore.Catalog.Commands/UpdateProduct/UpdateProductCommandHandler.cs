using EStore.Catalog.Domain;
using EStore.Catalog.Domain.Contracts;
using MediatR;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace EStore.Catalog.Commands.UpdateProduct
{
    class UpdateProductCommandHandler : IRequestHandler<UpdateProductCommand>
    {
        private readonly IProductRepository _productRepository;

        public UpdateProductCommandHandler(IProductRepository categoryRepository)
        {
            _productRepository = categoryRepository;
        }

        public async Task<Unit> Handle(UpdateProductCommand request, CancellationToken cancellationToken)
        {
            var product = new Product(
                request.Id,
                request.Title, 
                request.Description, 
                request.Price);

            await _productRepository.Save(product);

            return new Unit();
        }
    }
}
