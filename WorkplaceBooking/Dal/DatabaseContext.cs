using Microsoft.Data.Sqlite;
using System.Data;

namespace WorkplaceBooking.Dal
{
    public class DatabaseContext
    {
        private readonly IConfiguration _configuration;

        public DatabaseContext(IConfiguration configuration)
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
