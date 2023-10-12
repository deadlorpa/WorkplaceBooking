using Dapper;
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

        //TODO : надо бы деть куда-то, когда миграции начну + пароль ближе хэшированию
        /// <summary>
        /// Инициализация с проверкой существования таблицы Users
        /// </summary>
        /// <returns></returns>
        public async Task Init()
        {
            using var connection = Connection;

            await _initUsers();

            async Task _initUsers()
            {
                var sql =
                    @"
                        CREATE TABLE IF NOT EXISTS
                        Users (
                            Id INTEGER NOT NULL PRIMARY KEY AUTOINCREMENT,
                            FirstName TEXT,
                            LastName TEXT,
                            Email TEXT,
                            Role TEXT,
                            Password TEXT
                        );
                    ";
                await connection.ExecuteAsync(sql);
            }
        }

    }
}
