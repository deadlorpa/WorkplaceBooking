using Dapper;
using WorkplaceBooking.Core.Contracts.Entities;
using WorkplaceBooking.Core.Interfaces;

namespace WorkplaceBooking.Core.Dal.Repositories
{
    public class UserRepository : IUserRepository
    {
        private IDatabaseContext _dataContext;
        private const string _selectQuery =
            $@"
                SELECT
                    {nameof(User.Id)},
                    {nameof(User.FirstName)},
                    {nameof(User.LastName)},
                    {nameof(User.Email)},
                    {nameof(User.Role)},
                    {nameof(User.Password)}
                FROM Users
            ";

        public UserRepository(IDatabaseContext dataContext)
        {
            _dataContext = dataContext;
        }

        public async Task<int> Create(User user)
        {
            using var connection = _dataContext.Connection;
            var sql =
            $@"
                INSERT INTO Users (
                    {nameof(User.FirstName)},
                    {nameof(User.LastName)},
                    {nameof(User.Email)},
                    {nameof(User.Role)},
                    {nameof(User.Password)}
                )
                VALUES (
                    @{nameof(User.FirstName)},
                    @{nameof(User.LastName)},
                    @{nameof(User.Email)},
                    @{nameof(User.Role)},
                    @{nameof(User.Password)}
                )
            ";
            return await connection.ExecuteAsync(sql, user);
        }

        public async Task<int> Delete(int id)
        {
            using var connection = _dataContext.Connection;
            var sql =
            $@"
                DELETE FROM Users 
                WHERE {nameof(User.Id)} = @id
            ";
            return await connection.ExecuteAsync(sql, new { id });
        }

        public async Task<IEnumerable<User>> GetAll()
        {
            using var connection = _dataContext.Connection;
            return await connection.QueryAsync<User>(_selectQuery);
        }

        public async Task<User> GetByEmail(string email)
        {
            using var connection = _dataContext.Connection;
            var sql =
            $@"
                {_selectQuery}
                WHERE {nameof(User.Email)} = @email
            ";
            return await connection.QueryFirstOrDefaultAsync<User>(sql, new { email });
        }

        public async Task<User> GetById(int id)
        {
            using var connection = _dataContext.Connection;
            var sql =
            $@"
                {_selectQuery}
                WHERE {nameof(User.Id)} = @id
            ";
            return await connection.QueryFirstOrDefaultAsync<User>(sql, new { id });
        }

        public async Task<int> Update(User user)
        {
            using var connection = _dataContext.Connection;
            var sql =
            $@"
                UPDATE Users SET
                    {nameof(User.FirstName)} = @{nameof(User.FirstName)},
                    {nameof(User.LastName)}  = @{nameof(User.LastName)},
                    {nameof(User.Email)}     = @{nameof(User.Email)},
                    {nameof(User.Role)}      = @{nameof(User.Role)},
                    {nameof(User.Password)}  = @{nameof(User.Password)}
                WHERE {nameof(User.Id)} = @{nameof(User.Id)}
            ";
            return await connection.ExecuteAsync(sql, user);
        }
    }
}
