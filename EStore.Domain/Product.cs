using System;
using System.Collections.Generic;
using System.Text;

namespace EStore.Catalog.Domain
{
    public class Product
    {
        public Guid Id { get; private set; }
        public string Title { get; private set; }
        public string Description { get; private set; }
        public Guid CategoryId { get; private set; }
    }
}
