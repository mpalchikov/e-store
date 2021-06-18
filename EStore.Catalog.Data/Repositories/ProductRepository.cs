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
    public class ProductRepository : IProductRepository
    {
        private readonly IDbConnection _connection;

        public ProductRepository(IDbConnection connection)
        {
            _connection = connection;
        }

        public async Task Save(Product product)
        {
            var sql = @"insert into products (id, title, description, price) 
                        values (@id, @title, @description, @price)
                        on conflict (id) do update
                        set title = excluded.title, description = excluded.description, price = excluded.price";

            await _connection.ExecuteAsync(sql, product);
        }
    }
}
