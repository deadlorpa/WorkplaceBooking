using Dapper;
using WorkplaceBooking.Contracts.Entities;
using WorkplaceBooking.Interfaces;

namespace WorkplaceBooking.Dal.Repositories
{
    public class UserRepository : IUserRepository
    {
        private DatabaseContext _dataContext;
        public UserRepository(DatabaseContext dataContext)
        {
            _dataContext = dataContext;
        }

        public async Task Create(User user)
        {
            using var connection = _dataContext.Connection;
            var sql =
            @"
                INSERT INTO Users (
                    FirstName,
                    LastName,
                    Email,
                    Role,
                    Password
                )
                VALUES (
                   @FirstName,
                   @LastName,
                   @Email,
                   @Role,
                   @Password
                )
            ";
            await connection.ExecuteAsync(sql, user);
        }

        public async Task Delete(int id)
        {
            using var connection = _dataContext.Connection;
            var sql =
            @"
                DELETE FROM Users 
                WHERE Id = @id
            ";
            await connection.ExecuteAsync(sql, new { id });
        }

        public async Task<IEnumerable<User>> GetAll()
        {
            using var connection = _dataContext.Connection;
            var sql =
            @"
                SELECT * FROM Users
            ";
            return await connection.QueryAsync<User>(sql);
        }

        public async Task<User> GetByEmail(string email)
        {
            using var connection = _dataContext.Connection;
            var sql =
            @"
                SELECT * FROM Users
                WHERE Email = @email
            ";
            return await connection.QueryFirstOrDefaultAsync<User>(sql, new { email });
        }

        public async Task<User> GetById(int id)
        {
            using var connection = _dataContext.Connection;
            var sql =
            @"
                SELECT * FROM Users
                WHERE Id = @id
            ";
            return await connection.QueryFirstOrDefaultAsync<User>(sql, new { id });
        }

        public async Task Update(User user)
        {
            using var connection = _dataContext.Connection;
            var sql =
            @"
                UPDATE Users SET
                    FirstName = @FirstName,
                    LastName  = @LastName,
                    Email     = @Email,
                    Role      = @Role,
                    Password  = @Password
                WHERE Id = @Id
            ";
            await connection.ExecuteAsync(sql, user);
        }
    }
}
