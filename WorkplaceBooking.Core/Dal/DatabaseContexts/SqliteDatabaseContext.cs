using Microsoft.Data.Sqlite;
using System.Data;
using WorkplaceBooking.Core.Interfaces;

namespace WorkplaceBooking.Core.Dal.DatabaseContexts
{
    public class SqliteDatabaseContext : IDatabaseContext
    {
        private readonly IConfiguration _configuration;

        public SqliteDatabaseContext(IConfiguration configuration)
        {
            _configuration = configuration;
        }

        /// <summary>
        /// Соединение с базой данных
        /// </summary>
        public IDbConnection Connection
        {
            get
            {
                return new SqliteConnection(_configuration.GetConnectionString("DatabaseConnectionString"));
            }
        }
    }
}
