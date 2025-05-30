using ClientProductCore.Domain.Entities;
using ClientProductCore.Domain.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Data.SqlClient;

namespace ClientProductCore.DataAccess.SqlServer
{
    public class SqlProductRepository : IProductRepository
    {

        private readonly string _connectionString;
        public SqlProductRepository(string connectionString)
        {
            _connectionString = connectionString;
        }

        public int Add(Product item)
        {
            using (SqlConnection connection = new SqlConnection(_connectionString))
            {
                connection.Open();

                string insertQuery = @"
                        INSERT INTO Products (Name,Description,Price)
                        output inserted.Id VALUES (@Name,@Description,@Price);";


                using (SqlCommand command = new SqlCommand(insertQuery, connection))
                {
                    command.Parameters.AddWithValue("@Name", item.Name);
                    command.Parameters.AddWithValue("@Description", item.Description);
                    command.Parameters.AddWithValue("@Price", item.Price);

                    return (int)command.ExecuteScalar();
                }
            }

        }
        public void Delete(int id)
        {

            using (SqlConnection connection = new SqlConnection(_connectionString))
            {
                connection.Open();
                string query = "DELETE FROM Products WHERE Id = @Id;";

                using (SqlCommand command = new SqlCommand(query, connection))
                {
                    command.Parameters.AddWithValue("@Id", id);
                    command.ExecuteNonQuery();
                }
            }

        }

        public Product Get(int id)
        {
            using (SqlConnection connection = new SqlConnection(_connectionString))
            {
                connection.Open();
                string query = @"Select Id,Name,Description,Price FROM Products WHERE Id=@Id";

                using (SqlCommand command = new SqlCommand(query, connection))
                {
                    command.Parameters.AddWithValue("@Id", id);
                    using (SqlDataReader reader = command.ExecuteReader())
                    {
                        if (reader.Read() == false)
                            return null;

                        Product product = new Product();
                        product.Id = reader.GetInt32(reader.GetOrdinal("Id"));
                        product.Name = reader.GetString(reader.GetOrdinal("Name"));
                        product.Description = reader.GetString(reader.GetOrdinal("Description"));
                        product.Price = reader.GetDecimal(reader.GetOrdinal("Price"));
                        return product;
                    }
                }
            }

        }

        public List<Product> GetAll()
        {
            using (SqlConnection connection = new SqlConnection(_connectionString))
            {
                connection.Open();
                string query = @"Select * FROM Products";

                using (SqlCommand command = new SqlCommand(query, connection))
                {
                    List<Product> products = new List<Product>();
                    using (SqlDataReader reader = command.ExecuteReader())
                    {
                        while (reader.Read())
                        {

                            Product product = new Product();
                            product.Id = reader.GetInt32(reader.GetOrdinal("Id"));
                            product.Name = reader.GetString(reader.GetOrdinal("Name"));
                            product.Description = reader.GetString(reader.GetOrdinal("Description"));
                            product.Price = reader.GetDecimal(reader.GetOrdinal("Price"));
                            products.Add(product);
                        }
                        return products.OrderBy(product => product.Name).ToList();

                    }
                }
            }

        }

        public void Update(Product item)
        {
            using (SqlConnection connection = new SqlConnection(_connectionString))
            {
                connection.Open();
                string query = @"Update Products set Name=@Name,Description=@Description,Price=@Price WHERE Id=@Id";

                using (SqlCommand command = new SqlCommand(query, connection))
                {
                    command.Parameters.AddWithValue("@Id", item.Id);
                    command.Parameters.AddWithValue("@Name", item.Name);
                    command.Parameters.AddWithValue("@Description", item.Description);
                    command.Parameters.AddWithValue("@Price", item.Price);

                    command.ExecuteNonQuery();
                }
            }

        }


    }
}
