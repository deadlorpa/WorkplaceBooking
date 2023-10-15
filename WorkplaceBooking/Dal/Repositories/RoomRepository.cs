using Dapper;
using WorkplaceBooking.Contracts.Entities;
using WorkplaceBooking.Interfaces;

namespace WorkplaceBooking.Dal.Repositories
{
    public class RoomRepository : IRoomRepository
    {
        private DatabaseContext _dataContext;
        public RoomRepository(DatabaseContext dataContext)
        {
            _dataContext = dataContext;
        }
        public async Task Create(Room room)
        {
            using var connection = _dataContext.Connection;
            var sql =
            @"
                INSERT INTO Rooms (
                    Name
                )
                VALUES (
                   @Name
                )
            ";
            await connection.ExecuteAsync(sql, room);
        }

        public async Task Delete(int id)
        {
            using var connection = _dataContext.Connection;
            var sql =
            @"
                DELETE FROM Rooms 
                WHERE Id = @id
            ";
            await connection.ExecuteAsync(sql, new { id });
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

        public async Task Update(Room room)
        {
            using var connection = _dataContext.Connection;
            var sql =
            @"
                UPDATE Rooms SET
                    Name = @Name
                WHERE Id = @Id
            ";
            await connection.ExecuteAsync(sql, room);
        }
    }
}
