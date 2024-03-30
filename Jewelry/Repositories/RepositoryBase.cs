using System.Data.SqlClient;

namespace Jewelry.Repositories
{
    public abstract class RepositoryBase
    {
        private readonly string _connectionString;
        public RepositoryBase()
        {
            _connectionString = "data source=ADMIN\\ADMIN;initial catalog=Jewelry;integrated security=True;trustservercertificate=True;";
        }
        protected SqlConnection GetConnection()
        {
            return new SqlConnection(_connectionString);
        }
    }
}
