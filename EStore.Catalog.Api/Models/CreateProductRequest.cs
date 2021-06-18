using System;
using System.Collections.Generic;
using System.Text;

namespace EStore.Catalog.Api.Models
{
    public class CreateProductRequest
    {
        public string Title { get; set; }
        public string Description { get; set; }
        public decimal Price { get; set; }
    }
}
