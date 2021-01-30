using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace EStore.Catalog.Domain.Contracts
{
    public interface ICategoryRepository
    {
        Task Save(Category category);
    }
}
