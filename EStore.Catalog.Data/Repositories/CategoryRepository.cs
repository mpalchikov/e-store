using Dapper;
using EStore.Catalog.Domain;
using EStore.Catalog.Domain.Contracts;
using Npgsql;
using System;
using System.Collections.Generic;
using System.Data;
using System.Text;
using System.Threading.Tasks;

namespace EStore.Catalog.Data.Repositories
{
    public class CategoryRepository : ICategoryRepository
    {
        private readonly IDbConnection _connection;
        
        public CategoryRepository(IDbConnection connection)
        {
            _connection = connection;
        }

        public async Task Save(Category category)
        {
            var sql = @"insert into categories (id, title, description, parentCategoryId) 
                        values (@id, @title, @description, @parentCategoryId)
                        on conflict (id) do update
                        set title = excluded.title, description = excluded.description, parentCategoryId = excluded.parentCategoryId";

            await _connection.ExecuteAsync(sql, category);                  
        }
    }
}
