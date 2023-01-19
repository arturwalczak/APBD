using Microsoft.Extensions.Configuration;
using System;
using System.Data.SqlClient;
using System.Threading.Tasks;
using System.Transactions;
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
           // var connection = new SqlConnection(_configuration.GetConnectionString("ProductionDb"));
            
            double price;
            int idOrder;


            using (var connection = new SqlConnection(_configuration.GetConnectionString("ProductionDb")))
            {
                connection.Open();
                using (var command = connection.CreateCommand())
                {
                    command.CommandText = $"SELECT Price FROM Product WHERE IdProduct = {productWarehouse.IdProduct}";
                    using (var reader = command.ExecuteReader())
                    {
                        Console.WriteLine("duuuuupa");
                        await reader.ReadAsync();
                        if (!reader.HasRows) throw new Exception("No Product found");
                        price = double.Parse(reader["Price"].ToString());

                    }


                }




                using (var command = connection.CreateCommand())
                {
                    command.CommandText = $"SELECT IdWarehouse FROM Warehouse WHERE IdWarehouse = {productWarehouse.IdWarehouse}";
                    using (var reader = command.ExecuteReader())
                    {
                        await reader.ReadAsync();
                        /*int warehouseCount = (int)command.ExecuteScalar();

                        if (warehouseCount != 1)
                        {
                            throw new Exception("Warehouse not found");
                        }*/

                    }

                }






                using (var command = connection.CreateCommand())
                {
                    command.CommandText = $"SELECT IdOrder FROM Order WHERE IdProduct = {productWarehouse.IdProduct} AND Amount = {productWarehouse.Amount} AND CreatedAt < {productWarehouse.CreatedAt}";
                    using (var reader = command.ExecuteReader())
                    {

                        await reader.ReadAsync();
                        if (!reader.HasRows) throw new Exception("No Order found");
                        idOrder = int.Parse(reader["IdOrder"].ToString());

                    }

                }




                using (var command = connection.CreateCommand())
                {
                    command.CommandText = $"SELECT IdWarehouse FROM Product_Warehouse LEFT JOIN Order ON Product_Warehouse.IdProduct = Order.IdProduct WHERE Amount = {productWarehouse.Amount}";
                    using (var reader = command.ExecuteReader())
                    {
                        await reader.ReadAsync();
                        /*int pendingCount = (int)command.ExecuteScalar();

                        if (pendingCount != 0)
                        {
                            throw new Exception("Order already fullfilled");
                        }*/

                    }

                }
            }

            int idProductWarehouse;
            using (var connection = new SqlConnection(_configuration.GetConnectionString("ProductionDb")))
            {
                connection.Open();
                SqlDataReader reader2 = null;
                
                using (var cd = connection.CreateCommand())
                {


                    var transaction = (SqlTransaction)await connection.BeginTransactionAsync();
                    cd.Transaction = transaction;


                    try
                    {
                        cd.CommandText = "UPDATE [Order] SET FulfilledAt = @CreatedAt WHERE IdOrder = @IdOrder";
                        cd.Parameters.AddWithValue("CreatedAt", productWarehouse.CreatedAt);
                        cd.Parameters.AddWithValue("IdOrder", idOrder);

                        int rowsUpdated = await cd.ExecuteNonQueryAsync();


                        cd.Parameters.Clear();

                        cd.CommandText = "INSERT INTO Product_Warehouse(IdWarehouse, IdProduct, IdOrder, Amount, Price, CreatedAt) " +
                            $"VALUES(@IdWarehouse, @IdProduct, @IdOrder, @Amount, @Amount*{price}, @CreatedAt)";

                        cd.Parameters.AddWithValue("IdWarehouse", productWarehouse.IdWarehouse);
                        cd.Parameters.AddWithValue("IdProduct", productWarehouse.IdProduct);
                        cd.Parameters.AddWithValue("IdOrder", idOrder);
                        cd.Parameters.AddWithValue("Amount", productWarehouse.Amount);
                        cd.Parameters.AddWithValue("CreatedAt", productWarehouse.CreatedAt);

                        int rowsInserted = await cd.ExecuteNonQueryAsync();


                        await transaction.CommitAsync();
                    }
                    catch (Exception)
                    {
                        await transaction.RollbackAsync();
                        throw new Exception("Database error");
                    }



                    cd.Parameters.Clear();

                    cd.CommandText = "SELECT TOP 1 IdProductWarehouse FROM Product_Warehouse ORDER BY IdProductWarehouse DESC";

                    using (var reader = cd.ExecuteReader())
                    {
                        await reader2.ReadAsync();
                        idProductWarehouse = int.Parse(reader2["IdProductWarehouse"].ToString());

                    }

                }
            }
            //await connection.CloseAsync();

            return idProductWarehouse;




        }
    }
}
