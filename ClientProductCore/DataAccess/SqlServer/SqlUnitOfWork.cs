using ClientProductCore.Domain.Interfaces;
using System;
using System.Collections.Generic;
using System.Text;
using System.Data.SqlClient;

namespace ClientProductCore.DataAccess.SqlServer
{
    public class SqlUnitOfWork : IUnitOfWork
    {

        private readonly string _connectionString;

        public SqlUnitOfWork(string dataSource, string dbName)
        {
            var builder = new SqlConnectionStringBuilder();
            builder.DataSource = dataSource;
            builder.InitialCatalog = dbName;
            builder.IntegratedSecurity = true;
            _connectionString = builder.ConnectionString;

        }

        public IOrderRepository OrderRepository => new SqlOrderRepository(_connectionString);
        public IClientRepository ClientRepository => new SqlClientRepository(_connectionString);
        public IProductRepository ProductRepository => new SqlProductRepository(_connectionString);
 
    }
}
