using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EStore.Catalog.Queries.GetProduct
{
    public class GetProductQuery: IRequest<ProductDto>
    {
        public Guid ProductId { get; set; }
    }
}
