using ClientProductCore.Domain.Entities;
using ClientProductCore.Domain.Interfaces;
using System;
using System.Collections.Generic;
using System.Text;
using System.Data.SqlClient;
using System.Linq;

namespace ClientProductCore.DataAccess.SqlServer
{
    public class SqlOrderRepository : IOrderRepository
    {
        private readonly string _connectionString;

        public SqlOrderRepository(string connectionString)
        {
            _connectionString = connectionString;
        }

        public int Add(Order item)
        {
            using (SqlConnection connection = new SqlConnection(_connectionString))
            {
                connection.Open();
                string query = @"
                INSERT INTO Orders (ClientId, ProductId, OrderDate)
                OUTPUT INSERTED.Id
                VALUES (@ClientId, @ProductId, @OrderDate);";

                using (SqlCommand command = new SqlCommand(query, connection))
                {
                    command.Parameters.AddWithValue("@ClientId", item.ClientId);
                    command.Parameters.AddWithValue("@ProductId", item.ProductId);
                    command.Parameters.AddWithValue("@OrderDate", item.OrderDate);

                    return (int)command.ExecuteScalar();
                }
            }
            
        }

        public void Delete(int id)
        {
            using (SqlConnection connection = new SqlConnection(_connectionString))
            {
                connection.Open();
                string query = "DELETE FROM Orders WHERE Id = @Id;";

                using (SqlCommand command = new SqlCommand(query, connection))
                {
                    command.Parameters.AddWithValue("@Id", id);
                    command.ExecuteNonQuery();
                }
            }
            
        }

        public Order Get(int id)
        {
            using (SqlConnection connection = new SqlConnection(_connectionString))
            {
                connection.Open();
                string query = @"
                SELECT Id, ClientId, ProductId, OrderDate
                FROM Orders
                WHERE Id = @Id;";

                using (SqlCommand command = new SqlCommand(query, connection))
                {
                    command.Parameters.AddWithValue("@Id", id);
                    using (SqlDataReader reader = command.ExecuteReader())
                    {
                        if (reader.Read() == false)
                            return null;

                        Order order = new Order();
                        order.Id = reader.GetInt32(reader.GetOrdinal("Id"));
                        order.ClientId = reader.GetInt32(reader.GetOrdinal("ClientId"));
                        order.ProductId = reader.GetInt32(reader.GetOrdinal("ProductId"));
                        order.OrderDate = reader.GetDateTime(reader.GetOrdinal("OrderDate"));
                        return order;
                    }
                }
            }
            
        }

        public List<Order> GetAll()
        {

            using (SqlConnection connection = new SqlConnection(_connectionString))
            {
                connection.Open();
              string query = @"Select * FROM Orders";                                      

                using (SqlCommand command = new SqlCommand(query, connection))
                {
                    List<Order> orders = new List<Order>();
                    using (SqlDataReader reader = command.ExecuteReader())
                    {
                        while (reader.Read())
                        {

                            Order order = new Order();
                            order.Id = reader.GetInt32(reader.GetOrdinal("Id"));
                            order.ClientId = reader.GetInt32(reader.GetOrdinal("ClientId"));
                            order.ProductId = reader.GetInt32(reader.GetOrdinal("ProductId"));
                            order.OrderDate = reader.GetDateTime(reader.GetOrdinal("OrderDate"));
                            orders.Add(order);
                        }
                        return orders.OrderBy(order => order.Id).ToList();

                    }
                }
            }
           
        }

        

        public void Update(Order item)
        {
            using (SqlConnection connection = new SqlConnection(_connectionString))
            {
                connection.Open();
                string query = @"
                UPDATE Orders 
                SET ClientId = @ClientId,
                    ProductId = @ProductId,
                    OrderDate = @OrderDate
                WHERE Id = @Id;";

                using (SqlCommand command = new SqlCommand(query, connection))
                {
                    command.Parameters.AddWithValue("@Id", item.Id);
                    command.Parameters.AddWithValue("@ClientId", item.ClientId);
                    command.Parameters.AddWithValue("@ProductId", item.ProductId);
                    command.Parameters.AddWithValue("@OrderDate", item.OrderDate);

                    command.ExecuteNonQuery();
                }
            }
          
        }

    }
}
