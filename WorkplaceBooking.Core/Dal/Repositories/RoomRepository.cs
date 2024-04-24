using Dapper;
using WorkplaceBooking.Core.Contracts.Entities;
using WorkplaceBooking.Core.Interfaces;

namespace WorkplaceBooking.Core.Dal.Repositories
{
    public class RoomRepository : IRoomRepository
    {
        private IDatabaseContext _dataContext;
        private const string _selectQuery =
            $@"
                SELECT 
                    {nameof(Room.Id)},
                    {nameof(Room.Name)}
                FROM Rooms
            ";

        public RoomRepository(IDatabaseContext dataContext)
        {
            _dataContext = dataContext;
        }

        public async Task<int> Create(Room room)
        {
            using var connection = _dataContext.Connection;
            var sql =
            $@"
                INSERT INTO Rooms (
                    {nameof(Room.Name)}
                )
                VALUES (
                   @{nameof(Room.Name)}
                );
                SELECT last_insert_rowid()
            ";
            return await connection.QueryFirstOrDefaultAsync<int>(sql, room);
        }

        public async Task<int> Delete(int id)
        {
            using var connection = _dataContext.Connection;
            var sql =
            $@"
                DELETE FROM Rooms 
                WHERE {nameof(Room.Id)} = @id
            ";
            return await connection.ExecuteAsync(sql, new { id });
        }

        public async Task<IEnumerable<Room>> GetAll()
        {
            using var connection = _dataContext.Connection;
            return await connection.QueryAsync<Room>(_selectQuery);
        }

        public async Task<Room> GetById(int id)
        {
            using var connection = _dataContext.Connection;
            var sql =
            $@"
                {_selectQuery}
                WHERE {nameof(Room.Id)} = @id
            ";
            return await connection.QueryFirstOrDefaultAsync<Room>(sql, new { id });
        }

        public async Task<IEnumerable<Room>> GetByName(string name)
        {
            using var connection = _dataContext.Connection;
            var sql =
            $@"
                {_selectQuery}
                WHERE {nameof(Room.Name)} = @name
            ";
            return await connection.QueryAsync<Room>(sql, new { name });
        }

        public async Task<int> Update(Room room)
        {
            using var connection = _dataContext.Connection;
            var sql =
            $@"
                UPDATE Rooms SET
                    {nameof(Room.Name)} = @{nameof(Room.Name)}
                WHERE {nameof(Room.Id)} = @{nameof(Room.Id)}
            ";
            return await connection.ExecuteAsync(sql, room);
        }
    }
}
