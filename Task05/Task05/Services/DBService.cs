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
            
            var warehouseId = 0;
            var order = 0;
            var price = 0;
            using (var conn = new SqlConnection(_configuration.GetConnectionString("ProductionDb")))
            {
                conn.Open();

                using (SqlTransaction transaction = conn.BeginTransaction())
                {
                    //conn.Open();
                    SqlCommand com = new SqlCommand();
                    com.Transaction = transaction;


                    using (com = new SqlCommand())
                    {
                        com.Connection = conn;

                        com.Transaction = transaction;

                        com.CommandText = "SELECT * FROM WAREHOUSE WHERE IDWAREHOUSE = " + productWarehouse.IdProduct;

                        using (SqlDataReader dr = await com.ExecuteReaderAsync())
                        {
                            dr.Read();
                            if (dr.HasRows)
                            {
                                warehouseId = int.Parse(dr["IdWarehouse"].ToString());
                            }
                        }
                    }

                    using (com = new SqlCommand())
                    {
                        com.Connection = conn;
                        com.Transaction = transaction;
                        com.CommandText = "SELECT * FROM ORDER WHERE WHERE IDPRODUCT = " + productWarehouse.IdProduct + " AND AMOUNT = " + productWarehouse.Amount;

                        using (SqlDataReader dr = await com.ExecuteReaderAsync())
                        {
                            dr.Read();
                            if (dr.HasRows)
                            {
                                order = int.Parse(dr["IdOrder"].ToString());
                            }
                        }
                    }

                    using (com = new SqlCommand())
                    {
                        com.Connection = conn;
                        com.Transaction = transaction;
                        if (order != 0)
                        {

                            com.CommandText = "SELECT * FROM PRODUCT_WAREHOUSE WHERE IDORDER = " + order;

                            int rows = com.ExecuteNonQuery();
                            if (rows != 0)
                            {

                            }
                        }
                    }

                    using (com = new SqlCommand())
                    {
                        com.Connection = conn;
                        com.Transaction = transaction;
                        com.CommandText = "update order set FulfilledAt = " + DateTime.Now + " where idorder = " + order;
                        com.ExecuteNonQuery();
                    }

                    using (com = new SqlCommand())
                    {
                        com.Connection = conn;
                        com.Transaction = transaction;
                        com.CommandText = "Select price from product where idproduct = " + productWarehouse.IdProduct;
                        await com.ExecuteNonQueryAsync();
                        SqlDataReader dr = await com.ExecuteReaderAsync();
                        dr.Read();
                        if (dr.HasRows)
                        {
                            price = int.Parse(dr["price"].ToString());
                        }
                        com.CommandText = $"INSERT INTO Product_Warehouse(IdWarehouse, IdProduct, IdOrder, Amount, Price, CreatedAt) VALUES( {productWarehouse.IdWarehouse}, {productWarehouse.IdProduct}, {order}, {productWarehouse.Amount}, {productWarehouse.Amount * price}, {productWarehouse.CreatedAt} );";
                        await com.ExecuteNonQueryAsync();
                    }

                    await transaction.CommitAsync();
                    await conn.CloseAsync();

                }
            }

            return 1;
        }

        
    }
}
