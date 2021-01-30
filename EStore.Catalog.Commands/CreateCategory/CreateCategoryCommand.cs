using MediatR;
using System;
using System.Collections.Generic;
using System.Text;

namespace EStore.Catalog.Commands.CreateCategory
{
    public class CreateCategoryCommand: IRequest<Guid>
    {
        public string Title { get; set; }
        public string Description { get; set; }
        public Guid? ParentCategoryId { get; set; }
    }
}
