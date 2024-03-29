﻿using Dapper;
using WorkplaceBooking.Core.Contracts.Entities;
using WorkplaceBooking.Core.Interfaces;

namespace WorkplaceBooking.Core.Dal.Repositories
{
    public class WorkplaceRepository : IWorkplaceRepository
    {
        private IDatabaseContext _dataContext;
        public WorkplaceRepository(IDatabaseContext dataContext)
        {
            _dataContext = dataContext;
        }

        public async Task<int> Create(Workplace workplace)
        {
            using var connection = _dataContext.Connection;
            var sql =
            @"
                INSERT INTO Workplaces (
                    RoomId,
                    Name,
                    Description
                )
                VALUES (
                   @RoomId,
                   @Name,
                   @Description
                );
                
            ";
            return await connection.ExecuteAsync(sql, workplace);
        }

        public async Task<int> Delete(int id)
        {
            using var connection = _dataContext.Connection;
            var sql =
            @"
                DELETE FROM Workplaces 
                WHERE Id = @id
            ";
            return await connection.ExecuteAsync(sql, new { id });
        }

        public async Task<IEnumerable<Workplace>> GetAll()
        {
            using var connection = _dataContext.Connection;
            var sql =
            @"
                SELECT * FROM Workplaces
            ";
            return await connection.QueryAsync<Workplace>(sql);
        }

        public async Task<Workplace> GetById(int id)
        {
            using var connection = _dataContext.Connection;
            var sql =
            @"
                SELECT * FROM Workplaces
                WHERE Id = @id
            ";
            return await connection.QueryFirstOrDefaultAsync<Workplace>(sql, new { id });
        }

        public async Task<IEnumerable<Workplace>> GetByRoomId(int roomId)
        {
            using var connection = _dataContext.Connection;
            var sql =
            @"
                SELECT * FROM Workplaces
                WHERE RoomId = @roomId
            ";
            return await connection.QueryAsync<Workplace>(sql, new { roomId });
        }

        public async Task<int> Update(Workplace workplace)
        {
            using var connection = _dataContext.Connection;
            var sql =
            @"
                UPDATE Workplaces SET
                    RoomId = @RoomId,
                    Name = @Name,
                    Description = @Description
                WHERE Id = @Id
            ";
            return await connection.ExecuteAsync(sql, workplace);
        }
    }
}
