using ClientProductCore.Domain.Entities;
using ClientProductCore.Domain.Interfaces;
using System;
using System.Collections.Generic;
using System.Text;
using System.Data.SqlClient;
using System.Linq;

namespace ClientProductCore.DataAccess.SqlServer
{
    public class SqlClientRepository : IClientRepository
    {
        private readonly string _connectionString;

        public SqlClientRepository(string connectionString)
        {
            _connectionString = connectionString;
        }

        public int Add(Client item)
        {
            using (SqlConnection connection = new SqlConnection(_connectionString))
            {
                connection.Open();

                string query = @"
                INSERT INTO Clients (Name, Surname, Username,RegistrationDate, Email, Password, Phone)
                OUTPUT INSERTED.Id
                VALUES (@Name, @Surname, @Username, @RegistrationDate, @Email, @Password, @Phone);";

                using (SqlCommand command = new SqlCommand(query, connection))
                {
                    command.Parameters.AddWithValue("@Name", item.Name);
                    command.Parameters.AddWithValue("@Surname", item.Surname);
                    command.Parameters.AddWithValue("@Username", item.Username);
                    command.Parameters.AddWithValue("@RegistrationDate", item.RegistrationDate);
                    command.Parameters.AddWithValue("@Email", (object)item.Email ?? DBNull.Value);
                    command.Parameters.AddWithValue("@Password", item.Password);
                    command.Parameters.AddWithValue("@Phone", item.Phone);

                    return (int)command.ExecuteScalar();
                }
            }
           
        }

        public void Delete(int id)
        {
            using (SqlConnection connection = new SqlConnection(_connectionString))
            {
                connection.Open();
                string query = @"DELETE FROM Clients WHERE Id = @Id;";

                using (SqlCommand command = new SqlCommand(query, connection))
                {
                    command.Parameters.AddWithValue("@Id", id);
                    command.ExecuteNonQuery();
                }
            }
            
        }

        public Client Get(int id)
        {
            using (SqlConnection connection = new SqlConnection(_connectionString))
            {
                connection.Open();
                string query = @"SELECT * FROM Clients WHERE Id = @Id;";

                using (SqlCommand command = new SqlCommand(query, connection))
                {
                    command.Parameters.AddWithValue("@Id", id);

                    using (SqlDataReader reader = command.ExecuteReader())
                    {
                        if (reader.Read() == false)
                            return null;

                        Client client = new Client();

                        client.Id = reader.GetInt32(reader.GetOrdinal("Id"));
                        client.Name = reader.GetString(reader.GetOrdinal("Name"));
                        client.Surname = reader.GetString(reader.GetOrdinal("Surname"));
                        client.Username = reader.GetString(reader.GetOrdinal("Username"));
                        client.RegistrationDate = reader.GetDateTime(reader.GetOrdinal("RegistrationDate"));
                        client.Email = reader.IsDBNull(reader.GetOrdinal("Email")) ? null : reader.GetString(reader.GetOrdinal("Email"));
                        client.Password = reader.GetString(reader.GetOrdinal("Password"));
                        client.Phone = reader.GetString(reader.GetOrdinal("Phone"));
                        return client;

                    }
                }
            }

        }

        public List<Client> GetAll()
        {

            using (SqlConnection connection = new SqlConnection(_connectionString))
            {
                connection.Open();
                string query = @"Select * FROM Clients";

                using (SqlCommand command = new SqlCommand(query, connection))
                {
                    List<Client> clients = new List<Client>();
                    using (SqlDataReader reader = command.ExecuteReader())
                    {
                        while (reader.Read())
                        {

                            Client client = new Client();
                            client.Id = reader.GetInt32(reader.GetOrdinal("Id"));
                            client.Name = reader.GetString(reader.GetOrdinal("Name"));
                            client.Surname = reader.GetString(reader.GetOrdinal("Surname"));
                            client.Username = reader.GetString(reader.GetOrdinal("Username"));
                            client.RegistrationDate = reader.GetDateTime(reader.GetOrdinal("RegistrationDate"));
                            client.Email = reader.IsDBNull(reader.GetOrdinal("Email")) ? null : reader.GetString(reader.GetOrdinal("Email"));
                            client.Password = reader.GetString(reader.GetOrdinal("Password"));
                            client.Phone = reader.GetString(reader.GetOrdinal("Phone"));
                            clients.Add(client);
                        }
                        return clients.OrderBy(client => client.Name).ToList();

                    }
                }
            }
            
        }

        public void Update(Client item)
        {
            using (SqlConnection connection = new SqlConnection(_connectionString))
            {
                connection.Open();
                string query = @"
                UPDATE Clients
                SET Name = @Name,
                    Surname = @Surname,
                    Username = @Username,
                    RegistrationDate = @RegistrationDate,
                    Email = @Email,
                    Password = @Password,
                    Phone = @Phone
                WHERE Id = @Id;";

                using (SqlCommand command = new SqlCommand(query, connection))
                {
                    command.Parameters.AddWithValue("@Id", item.Id);
                    command.Parameters.AddWithValue("@Name", item.Name);
                    command.Parameters.AddWithValue("@Surname", item.Surname);
                    command.Parameters.AddWithValue("@Username", item.Username);
                    command.Parameters.AddWithValue("@RegistrationDate", item.RegistrationDate);
                    command.Parameters.AddWithValue("@Email", item.Email);
                    command.Parameters.AddWithValue("@Password", item.Password);
                    command.Parameters.AddWithValue("@Phone", item.Phone);

                    command.ExecuteNonQuery();
                }
                
        }
        }
    }
}
