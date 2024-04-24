using Dapper;
using WorkplaceBooking.Core.Contracts.Entities;
using WorkplaceBooking.Core.Interfaces;

namespace WorkplaceBooking.Core.Dal.Repositories
{
    public class WorkplaceRepository : IWorkplaceRepository
    {
        private IDatabaseContext _dataContext;
        private const string _selectQuery = 
            $@"
                SELECT 
                    {nameof(Workplace.Id)},
                    {nameof(Workplace.RoomId)},
                    {nameof(Workplace.Name)},
                    {nameof(Workplace.Description)}
                FROM Workplaces
            ";

        public WorkplaceRepository(IDatabaseContext dataContext)
        {
            _dataContext = dataContext;
        }

        public async Task<int> Create(Workplace workplace)
        {
            using var connection = _dataContext.Connection;
            var sql =
            $@"
                INSERT INTO Workplaces (
                    {nameof(Workplace.RoomId)},
                    {nameof(Workplace.Name)},
                    {nameof(Workplace.Description)}
                )
                VALUES (
                    @{nameof(Workplace.RoomId)},
                    @{nameof(Workplace.Name)},
                    @{nameof(Workplace.Description)}
                );
                
            ";
            return await connection.ExecuteAsync(sql, workplace);
        }

        public async Task<int> Delete(int id)
        {
            using var connection = _dataContext.Connection;
            var sql =
            $@"
                DELETE FROM Workplaces 
                WHERE {nameof(Workplace.Id)} = @id
            ";
            return await connection.ExecuteAsync(sql, new { id });
        }

        public async Task<IEnumerable<Workplace>> GetAll()
        {
            using var connection = _dataContext.Connection;
            return await connection.QueryAsync<Workplace>(_selectQuery);
        }

        public async Task<Workplace> GetById(int id)
        {
            using var connection = _dataContext.Connection;
            var sql =
            $@"
                {_selectQuery}
                WHERE {nameof(Workplace.Id)} = @id
            ";
            return await connection.QueryFirstOrDefaultAsync<Workplace>(sql, new { id });
        }

        public async Task<IEnumerable<Workplace>> GetByRoomId(int roomId)
        {
            using var connection = _dataContext.Connection;
            var sql =
            $@"
                {_selectQuery}
                WHERE {nameof(Workplace.RoomId)} = @roomId
            ";
            return await connection.QueryAsync<Workplace>(sql, new { roomId });
        }

        public async Task<int> Update(Workplace workplace)
        {
            using var connection = _dataContext.Connection;
            var sql =
            $@"
                UPDATE Workplaces SET
                    {nameof(Workplace.RoomId)} = @{nameof(Workplace.RoomId)},
                    {nameof(Workplace.Name)} = @{nameof(Workplace.Name)},
                    {nameof(Workplace.Description)} = @{nameof(Workplace.Description)}
                WHERE {nameof(Workplace.Id)} = @{nameof(Workplace.Id)}
            ";
            return await connection.ExecuteAsync(sql, workplace);
        }
    }
}
