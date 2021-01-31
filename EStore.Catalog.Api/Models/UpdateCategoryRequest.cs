using System;
using System.Collections.Generic;
using System.Text;

namespace EStore.Catalog.Api.Models
{
    public class UpdateCategoryRequest
    {
        public string Title { get; set; }
        public string Description { get; set; }
        public Guid? ParentCategoryId { get; set; }
    }
}
