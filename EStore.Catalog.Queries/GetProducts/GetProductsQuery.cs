using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EStore.Catalog.Queries.GetProducts
{
    public class GetProductsQuery : IRequest<IEnumerable<ProductDto>>
    {
    }
}
