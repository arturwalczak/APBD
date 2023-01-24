using Microsoft.Extensions.Configuration;
using System.Data;
using System;
using System.Data.SqlClient;
using System.Threading.Tasks;
using Task05.Models;

namespace Task05.Services
{
    public class DbProcedureService : IDbProcedureService
    {
        private IConfiguration _configuration;
        public DbProcedureService(IConfiguration configuration)
        {
            _configuration = configuration;
        }
        public async Task<int> AddProductToWarehouseAsync(ProductWarehouse productWarehouse)
        {
            int idProductWarehouse = 0;
            using (var connection = new SqlConnection(_configuration.GetConnectionString("ProductionDb")))
            {
                connection.Open();               

                using (var cmd = new SqlCommand())
                {
                    cmd.Connection = connection;
                    
                    var transaction = (SqlTransaction)await connection.BeginTransactionAsync();
                    cmd.Transaction = transaction;

                    try
                    {
                        cmd.CommandType = CommandType.StoredProcedure;
                        cmd.Parameters.AddWithValue("IdProduct", productWarehouse.IdProduct);
                        cmd.Parameters.AddWithValue("IdWarehouse", productWarehouse.IdWarehouse);
                        cmd.Parameters.AddWithValue("Amount", productWarehouse.Amount);
                        cmd.Parameters.AddWithValue("CreatedAt", productWarehouse.CreatedAt);

                        await connection.OpenAsync();
                        int rowsChanged = await cmd.ExecuteNonQueryAsync();

                        if (rowsChanged < 1) throw new Exception();

                        await transaction.CommitAsync();
                    }
                    catch (Exception)
                    {
                        await transaction.RollbackAsync();
                        throw new Exception();
                    }
                }

                using (var cmd = new SqlCommand())
                {
                    cmd.Connection = connection;
                    cmd.CommandText = "SELECT TOP 1 IdProductWarehouse FROM Product_Warehouse ORDER BY IdProductWarehouse DESC";
                    using (var reader = await cmd.ExecuteReaderAsync())
                    {
                        if (!reader.HasRows) throw new Exception("not added");
                        await reader.ReadAsync();
                        idProductWarehouse = int.Parse(reader["IdProductWarehouse"].ToString());
                    }


                }
            }
            return idProductWarehouse;
        }
    }
}

