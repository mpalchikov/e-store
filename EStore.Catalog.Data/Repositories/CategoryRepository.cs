using EStore.Catalog.Domain;
using EStore.Catalog.Domain.Contracts;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace EStore.Catalog.Data.Repositories
{
    public class CategoryRepository : ICategoryRepository
    {
        public Task Save(Category category)
        {
            throw new NotImplementedException();
        }
    }
}
