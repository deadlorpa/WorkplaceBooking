using Dapper;
using WorkplaceBooking.Core.Contracts.Entities;
using WorkplaceBooking.Core.Interfaces;

namespace WorkplaceBooking.Core.Dal.Repositories
{
    public class RoomRepository : IRoomRepository
    {
        private IDatabaseContext _dataContext;
        public RoomRepository(IDatabaseContext dataContext)
        {
            _dataContext = dataContext;
        }
        public async Task<int> Create(Room room)
        {
            using var connection = _dataContext.Connection;
            var sql =
            @"
                INSERT INTO Rooms (
                    Name
                )
                VALUES (
                   @Name
                );
                SELECT last_insert_rowid()
            ";
            return await connection.QueryFirstOrDefaultAsync<int>(sql, room);
        }

        public async Task<int> Delete(int id)
        {
            using var connection = _dataContext.Connection;
            var sql =
            @"
                DELETE FROM Rooms 
                WHERE Id = @id
            ";
            return await connection.ExecuteAsync(sql, new { id });
        }

        public async Task<IEnumerable<Room>> GetAll()
        {
            using var connection = _dataContext.Connection;
            var sql =
            @"
                SELECT * FROM Rooms
            ";
            return await connection.QueryAsync<Room>(sql);
        }

        public async Task<Room> GetById(int id)
        {
            using var connection = _dataContext.Connection;
            var sql =
            @"
                SELECT * FROM Rooms
                WHERE Id = @id
            ";
            return await connection.QueryFirstOrDefaultAsync<Room>(sql, new { id });
        }

        public async Task<IEnumerable<Room>> GetByName(string name)
        {
            using var connection = _dataContext.Connection;
            var sql =
            @"
                SELECT * FROM Rooms
                WHERE Name = @name
            ";
            return await connection.QueryAsync<Room>(sql, new { name });
        }

        public async Task<int> Update(Room room)
        {
            using var connection = _dataContext.Connection;
            var sql =
            @"
                UPDATE Rooms SET
                    Name = @Name
                WHERE Id = @Id
            ";
            return await connection.ExecuteAsync(sql, room);
        }
    }
}
