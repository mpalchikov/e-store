using EStore.Catalog.Domain;
using EStore.Catalog.Domain.Contracts;
using MediatR;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace EStore.Catalog.Commands.CreateCategory
{
    class CreateCategoryCommandHandler : IRequestHandler<CreateCategoryCommand, Guid>
    {
        private readonly ICategoryRepository _categoryRepository;

        public CreateCategoryCommandHandler(ICategoryRepository categoryRepository)
        {
            _categoryRepository = categoryRepository;
        }

        public async Task<Guid> Handle(CreateCategoryCommand request, CancellationToken cancellationToken)
        {
            var categoryId = Guid.NewGuid();
            var category = new Category(categoryId, request.Title, request.Description, request.ParentCategoryId);

            await _categoryRepository.Save(category);

            return categoryId;
        }
    }
}
