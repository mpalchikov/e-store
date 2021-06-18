using Dapper;
using MediatR;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace EStore.Catalog.Queries.GetProducts
{
    class GetProductsQueryHandler : IRequestHandler<GetProductsQuery, IEnumerable<ProductDto>>
    {
        private readonly IDbConnection _connection;

        public GetProductsQueryHandler(IDbConnection connection)
        {
            _connection = connection;
        }

        public async Task<IEnumerable<ProductDto>> Handle(GetProductsQuery request, CancellationToken cancellationToken)
        {
            var sql = "select * from products";

            var products = await _connection.QueryAsync<ProductDto>(sql);

            return products.Select(p => new ProductDto
            {
                Id = p.Id,
                Title = p.Title,
                Description = p.Description,
                Price = p.Price
            }).ToList();
        }
    }
}
