using MediatR;
using System;
using System.Collections.Generic;
using System.Text;

namespace EStore.Catalog.Commands.UpdateCategory
{
    public class UpdateCategoryCommand: IRequest
    {
        public Guid Id { get; set; }
        public string Title { get; set; }
        public string Description { get; set; }
        public Guid? ParentCategoryId { get; set; }
    }
}
