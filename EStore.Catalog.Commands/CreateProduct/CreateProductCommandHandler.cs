using EStore.Catalog.Domain;
using EStore.Catalog.Domain.Contracts;
using MediatR;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace EStore.Catalog.Commands.CreateProduct
{
    class CreateProductCommandHandler : IRequestHandler<CreateProductCommand, Guid>
    {
        private readonly IProductRepository _productRepository;

        public CreateProductCommandHandler(IProductRepository categoryRepository)
        {
            _productRepository = categoryRepository;
        }

        public async Task<Guid> Handle(CreateProductCommand request, CancellationToken cancellationToken)
        {
            var productId = Guid.NewGuid();

            var product = new Product(
                productId,
                request.Title,
                request.Description,
                request.Price);

            await _productRepository.Save(product);

            return productId;
        }
    }
}
