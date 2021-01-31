using EStore.Catalog.Domain;
using EStore.Catalog.Domain.Contracts;
using MediatR;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace EStore.Catalog.Commands.UpdateCategory
{
    class UpdateCategoryCommandHandler : IRequestHandler<UpdateCategoryCommand>
    {
        private readonly ICategoryRepository _categoryRepository;

        public UpdateCategoryCommandHandler(ICategoryRepository categoryRepository)
        {
            _categoryRepository = categoryRepository;
        }

        public async Task<Unit> Handle(UpdateCategoryCommand request, CancellationToken cancellationToken)
        {
            var category = new Category(request.Id, request.Title, request.Description, request.ParentCategoryId);

            await _categoryRepository.Save(category);

            return new Unit();
        }
    }
}
