using Dapper;
using WorkplaceBooking.Contracts.Entities;
using WorkplaceBooking.Interfaces;

namespace WorkplaceBooking.Dal.Repositories
{
    public class BookingRepository : IBookingRepository
    {
        private DatabaseContext _dataContext;
        public BookingRepository(DatabaseContext dataContext)
        {
            _dataContext = dataContext;
        }

        public async Task Create(BookingRecord record)
        {
            using var connection = _dataContext.Connection;
            var sql =
            @"
                INSERT INTO BookingRecords (
                    UserId,
                    WorkplaceId,
                    StartBookingDateTime,
                    EndBookingDateTime
                )
                VALUES (
                   @UserId,
                   @WorkplaceId,
                   @StartBookingDateTime,
                   @EndBookingDateTime
                )
            ";
            await connection.ExecuteAsync(sql, record);
        }

        public async Task Delete(int id)
        {
            using var connection = _dataContext.Connection;
            var sql =
            @"
                UPDATE BookingRecords SET
                    IsCanceled = 1
                WHERE Id = @id
            ";
            await connection.ExecuteAsync(sql, new { id });
        }

        public async Task<IEnumerable<BookingRecord>> GetAll()
        {
            using var connection = _dataContext.Connection;
            var sql =
            @"
                SELECT * FROM BookingRecords
            ";
            return await connection.QueryAsync<BookingRecord>(sql);
        }

        public async Task<BookingRecord> GetById(int id)
        {
            using var connection = _dataContext.Connection;
            var sql =
            @"
                SELECT * FROM BookingRecords
                WHERE Id = @id
            ";
            return await connection.QueryFirstOrDefaultAsync<BookingRecord>(sql, new { id });
        }

        public async Task<IEnumerable<BookingRecord>> GetByWorkplaceId(int workplaceId)
        {
            using var connection = _dataContext.Connection;
            var sql =
            @"
                SELECT * FROM BookingRecords
                WHERE WorkplaceId = @workplaceId
            ";
            return await connection.QueryAsync<BookingRecord>(sql, new { workplaceId });
        }

        public async Task<IEnumerable<BookingRecord>> GetByUserId(int userId)
        {
            using var connection = _dataContext.Connection;
            var sql =
            @"
                SELECT * FROM BookingRecords
                WHERE UserId = @userId
            ";
            return await connection.QueryAsync<BookingRecord>(sql, new { userId });
        }

        public async Task Update(BookingRecord record)
        {
            using var connection = _dataContext.Connection;
            var sql =
            @"
                UPDATE BookingRecords SET
                    StartBookingDateTime = @StartBookingDateTime,
                    EndBookingDateTime  = @EndBookingDateTime
                WHERE Id = @Id
            ";
            await connection.ExecuteAsync(sql, record);
        }
    }
}
