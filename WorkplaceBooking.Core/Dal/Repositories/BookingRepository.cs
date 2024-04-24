using Dapper;
using WorkplaceBooking.Core.Contracts.Entities;
using WorkplaceBooking.Core.Interfaces;

namespace WorkplaceBooking.Core.Dal.Repositories
{
    public class BookingRepository : IBookingRepository
    {
        private IDatabaseContext _dataContext;
        private const string _selectQuery =
        $@"
            SELECT
                {nameof(BookingRecord.Id)},
                {nameof(BookingRecord.UserId)},
                {nameof(BookingRecord.WorkplaceId)},
                {nameof(BookingRecord.IsCanceled)},
                {nameof(BookingRecord.StartBookingDateTime)},
                {nameof(BookingRecord.EndBookingDateTime)}
            FROM BookingRecords
        ";

        public BookingRepository(IDatabaseContext dataContext)
        {
            _dataContext = dataContext;
        }

        public async Task<int> Create(BookingRecord record)
        {
            using var connection = _dataContext.Connection;
            var sql =
            $@"
                INSERT INTO BookingRecords (
                    {nameof(BookingRecord.UserId)},
                    {nameof(BookingRecord.WorkplaceId)},
                    {nameof(BookingRecord.StartBookingDateTime)},
                    {nameof(BookingRecord.EndBookingDateTime)}
                )
                VALUES (
                    @{nameof(BookingRecord.UserId)},
                    @{nameof(BookingRecord.WorkplaceId)},
                    @{nameof(BookingRecord.StartBookingDateTime)},
                    @{nameof(BookingRecord.EndBookingDateTime)}
                )
            ";
            return await connection.ExecuteAsync(sql, record);
        }

        public async Task<int> Delete(int id)
        {
            using var connection = _dataContext.Connection;
            var sql =
            $@"
                UPDATE BookingRecords SET
                {nameof(BookingRecord.IsCanceled)} = 1
                WHERE {nameof(BookingRecord.Id)} = @id
            ";
            return await connection.ExecuteAsync(sql, new { id });
        }

        public async Task<IEnumerable<BookingRecord>> GetAll()
        {
            using var connection = _dataContext.Connection;
            return await connection.QueryAsync<BookingRecord>(_selectQuery);
        }

        public async Task<BookingRecord> GetById(int id)
        {
            using var connection = _dataContext.Connection;
            var sql =
                @$"
                    {_selectQuery}
                    WHERE {nameof(BookingRecord.Id)} = @id
                ";
            return await connection.QueryFirstOrDefaultAsync<BookingRecord>(sql, new { id });
        }

        public async Task<IEnumerable<BookingRecord>> GetByWorkplaceId(int workplaceId)
        {
            using var connection = _dataContext.Connection;
            var sql =
                $@"
                    {_selectQuery}
                    WHERE {nameof(BookingRecord.WorkplaceId)} = @workplaceId
                ";
            return await connection.QueryAsync<BookingRecord>(sql, new { workplaceId });
        }

        public async Task<IEnumerable<BookingRecord>> GetByWorkplaceId(int workplaceId, DateTime date)
        {
            using var connection = _dataContext.Connection;
            var sql =
            $@"
                {_selectQuery}
                WHERE {nameof(BookingRecord.WorkplaceId)} = @workplaceId
                AND 
                (
                    DATE({nameof(BookingRecord.StartBookingDateTime)}) = DATE(@date)
                    OR DATE({nameof(BookingRecord.EndBookingDateTime)}) = DATE(@date)
                )
            ";
            return await connection.QueryAsync<BookingRecord>(sql, new { workplaceId , date});
        }

        public async Task<IEnumerable<BookingRecord>> GetByUserId(int userId)
        {
            using var connection = _dataContext.Connection;
            var sql =
            $@"
                {_selectQuery}
                WHERE {nameof(BookingRecord.UserId)} = @userId
            ";
            return await connection.QueryAsync<BookingRecord>(sql, new { userId });
        }

        public async Task<int> Update(BookingRecord record)
        {
            using var connection = _dataContext.Connection;
            var sql =
            $@"
                UPDATE BookingRecords SET
                    {nameof(BookingRecord.StartBookingDateTime)} = @{nameof(BookingRecord.StartBookingDateTime)},
                    {nameof(BookingRecord.EndBookingDateTime)}  = @{nameof(BookingRecord.EndBookingDateTime)}
                WHERE {nameof(BookingRecord.Id)} = @{nameof(BookingRecord.Id)}
            ";
            return await connection.ExecuteAsync(sql, record);
        }
    }
}
