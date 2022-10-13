using System;
using System.Threading.Tasks;
using BS.DemoShop.Core.Entities;
using BS.DemoShop.Core.Interfaces;
using Dapper;
using Microsoft.Data.SqlClient;
using Microsoft.Extensions.Configuration;

namespace BS.DemoShop.Infrastructure.Data.Queries
{
    public class ProductQueryByDapperService : IProductQueryService
    {
        private readonly string _connectionString;

        public ProductQueryByDapperService(IConfiguration configuration)
        {
            _connectionString = configuration.GetConnectionString("BSDemoShopConnection");
        }

        public async Task<int> GetProductTotalInventoryById(int productId)
        {
            await using var conn = new SqlConnection(_connectionString);
            var parameters = new { Id = productId };
            var sqlQuery = @"
                    SELECT pd.ProductId AS Id, SUM(pd.Inventory) AS Inventory
                    FROM ProductDetails pd
                    GROUP BY pd.ProductId
                    HAVING pd.ProductId = @Id
                    ";
            var result = await conn.QueryFirstOrDefaultAsync<ProductInventory>(sqlQuery, parameters);

            return result?.Inventory ?? 0;
        }
        private class ProductInventory
        {
            public int Id { get; set; }
            public int Inventory { get; set; }
        }
        public async Task<decimal> GetProductMaxPriceById(int productId)
        {
            await using var conn = new SqlConnection(_connectionString);
            var parameters = new { Id = productId };
            var sqlQuery = @"
                        SELECT MAX(pd.UnitPrice) AS MaxPrice
                        FROM ProductDetails pd
                        INNER JOIN Products p ON p.Id = pd.ProductId
                        GROUP BY p.Id
                        HAVING p.Id = @Id
                        ";
            var result = await conn.QueryFirstOrDefaultAsync<ProductMaxPrice>(sqlQuery, parameters);
            return result?.MaxPrice ?? 0;
        }
        
        private class ProductMaxPrice
        {
            public decimal MaxPrice { get; set; }
        }
    }
}