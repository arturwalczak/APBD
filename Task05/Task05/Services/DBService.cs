using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.Primitives;
using System;
using System.Data;
using System.Data.SqlClient;
using System.Diagnostics;
using System.Globalization;
using System.Threading.Tasks;
using Task05.Models;

namespace Task05.Services
{
    public class DBService : IDBService
    {
        private IConfiguration _configuration;
        public DBService(IConfiguration configuration)
        {
            _configuration = configuration;
        }
        public async Task<int> AddProductToWarehouseAsync(ProductWarehouse productWarehouse)
        {
            int idOrder;
            double price = 0.0;
            int idProductWarehouse;

            using (var connection = new SqlConnection(_configuration.GetConnectionString("ProductionDb")))
            {
                await connection.OpenAsync();

                using (var cmd = new SqlCommand())
                {
                    cmd.Connection = connection;
                    cmd.CommandText = "SELECT TOP 1 * FROM Product WHERE IdProduct = " + productWarehouse.IdProduct;
                   
                    using (var reader = await cmd.ExecuteReaderAsync())
                    {
                        if (reader.HasRows) {                            
                            await reader.ReadAsync();
                            price = double.Parse(reader["price"].ToString());                                                       
                        }
                        else
                        {
                            throw new Exception("product not found");
                        }
                        
                    }
                    cmd.CommandText = "SELECT TOP 1 * FROM Warehouse WHERE IdWarehouse = " + productWarehouse.IdWarehouse;
                    using (var reader = await cmd.ExecuteReaderAsync())
                    {
                        if (!reader.HasRows)
                        {
                            throw new Exception("warehouse not found");
                        }                       

                    }

                }                
                
                using (var cmd = new SqlCommand())
                {
                    cmd.Connection = connection;                    
                    cmd.CommandText = $"SELECT TOP 1 * FROM \"Order\" WHERE IDPRODUCT = " + productWarehouse.IdProduct + " AND AMOUNT = " + productWarehouse.Amount;
                    
                    using (var reader = await cmd.ExecuteReaderAsync())
                    {
                        await reader.ReadAsync();
                        if (!reader.HasRows) throw new Exception("order not found");
                        idOrder = int.Parse(reader["IdOrder"].ToString());
                    }                        
                    cmd.CommandText = $"SELECT TOP 1 * FROM \"ORDER\" WHERE CreatedAt > " + productWarehouse.CreatedAt.ToString("yyyy-mm-dd");
                    
                    using (var reader = await cmd.ExecuteReaderAsync())
                    {
                        if (!reader.HasRows) throw new Exception("wrong createdAt");
                    }
                    
                    
                }

                using (var cmd = new SqlCommand())
                {
                    cmd.Connection = connection;
                    cmd.CommandText = $"SELECT TOP 1 * FROM \"Order\" WHERE IDPRODUCT = " + productWarehouse.IdProduct;
                    
                    using (var reader = await cmd.ExecuteReaderAsync())
                    {                        
                        if (!reader.HasRows) throw new Exception("order not found");
                        await reader.ReadAsync();
                        idOrder = int.Parse(reader["IdOrder"].ToString());
                    }              
                    


                }

                using (var cmd = new SqlCommand())
                {
                    var transaction = (SqlTransaction)await connection.BeginTransactionAsync();
                    cmd.Transaction = transaction;
                    cmd.Connection = connection;

                    try
                    {
                        cmd.CommandText = "UPDATE \"Order\" SET FulfilledAt = " + productWarehouse.CreatedAt.ToString("yyyy-mm-dd") + " WHERE IdOrder = " + idOrder;
                       
                        System.Diagnostics.Debug.WriteLine(price + "CommandText " + cmd.CommandText);
                        int rowsUpdated = await cmd.ExecuteNonQueryAsync();                        
                        if (rowsUpdated < 1) throw new Exception("problem");
                        string pricePW = (Convert.ToDouble(productWarehouse.Amount) * price).ToString(CultureInfo.InvariantCulture);
                        
                        cmd.CommandText = "INSERT INTO Product_Warehouse(IdWarehouse, IdProduct, IdOrder, Amount, Price, CreatedAt) " +
                            "VALUES(" + productWarehouse.IdWarehouse + ", " + productWarehouse.IdProduct + ", " + idOrder + ", " + productWarehouse.Amount + ", " + pricePW + ", " + productWarehouse.CreatedAt.ToString("yyyy-mm-dd") + ")";
                                                
                        int rowsInserted = await cmd.ExecuteNonQueryAsync();

                        if (rowsInserted < 1) throw new Exception();

                        await transaction.CommitAsync();
                    }
                    catch (Exception)
                    {
                        await transaction.RollbackAsync();
                        throw new Exception("Transaction problem, no change commited");
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

