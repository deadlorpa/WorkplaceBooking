﻿using Dapper;
using WorkplaceBooking.Contracts.Entities;
using WorkplaceBooking.Interfaces;

namespace WorkplaceBooking.Dal.Repositories
{
    public class WorkspaceRepository : IWorkspaceRepository
    {
        private DatabaseContext _dataContext;
        public WorkspaceRepository(DatabaseContext dataContext)
        {
            _dataContext = dataContext;
        }

        public async Task Create(Workplace workplace)
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
                )
            ";
            await connection.ExecuteAsync(sql, workplace);
        }

        public async Task Delete(int id)
        {
            using var connection = _dataContext.Connection;
            var sql =
            @"
                DELETE FROM Workplaces 
                WHERE Id = @id
            ";
            await connection.ExecuteAsync(sql, new { id });
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

        public async Task Update(Workplace workplace)
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
            await connection.ExecuteAsync(sql, workplace);
        }
    }
}
