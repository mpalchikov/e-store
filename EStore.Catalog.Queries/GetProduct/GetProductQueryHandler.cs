using Dapper;
using MediatR;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace EStore.Catalog.Queries.GetProduct
{
    class GetProductQueryHandler : IRequestHandler<GetProductQuery, ProductDto>
    {
        private readonly IDbConnection _connection;

        public GetProductQueryHandler(IDbConnection connection)
        {
            _connection = connection;
        }

        public async Task<ProductDto> Handle(GetProductQuery request, CancellationToken cancellationToken)
        {
            var sql = "select * from products where id = @ProductId";

            var product = await _connection.QueryFirstAsync<ProductDto>(sql, new { ProductId = request.ProductId });

            return product;
        }
    }
}
