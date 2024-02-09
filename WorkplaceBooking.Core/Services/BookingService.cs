using AutoMapper;
using Microsoft.Extensions.Localization;
using WorkplaceBooking.Core.Contracts.DataContracts;
using WorkplaceBooking.Core.Contracts.Entities;
using WorkplaceBooking.Core.Contracts.Extensions;
using WorkplaceBooking.Core.Interfaces;

namespace WorkplaceBooking.Core.Services
{
    public class BookingService : IBookingService
    {
        private IUnitOfWork _unitOfWork;
        private readonly IMapper _mapper;
        private readonly IStringLocalizer<BookingService> _localizer;
        public BookingService(IUnitOfWork unitOfWork,
            IMapper mapper,
            IStringLocalizer<BookingService> localizer)
        {
            _unitOfWork = unitOfWork;
            _mapper = mapper;
            _localizer = localizer;
        }

        public async Task Create(BookingRecordCreateDC contract)
        {
            var record = _mapper.Map<BookingRecord>(contract);
            await DateIntervalValidation(record);
            await _unitOfWork.BookingRepository.Create(record);
        }

        public async Task Delete(int id)
        {
            await _unitOfWork.BookingRepository.Delete(id);
        }

        public async Task<IEnumerable<BookingRecord>> GetAll()
        {
            return await _unitOfWork.BookingRepository.GetAll();
        }

        public async Task<BookingRecord> GetById(int id)
        {
            var record = await _unitOfWork.BookingRepository.GetById(id);
            if (record == null)
                throw new KeyNotFoundException(_localizer["NotFound"].Value);
            return record;
        }

        public async Task<IEnumerable<BookingRecord>> GetByWorkplaceId(int workplaceId)
        {
            var records = await _unitOfWork.BookingRepository.GetByWorkplaceId(workplaceId);
            if (records == null)
                throw new KeyNotFoundException(_localizer["NotFound"].Value);
            return records;
        }

        public async Task<IEnumerable<BookingRecord>> GetByUserId(int idUser)
        {
            var record = await _unitOfWork.BookingRepository.GetByUserId(idUser);
            if (record == null)
                throw new KeyNotFoundException(_localizer["NotFound"].Value);
            return record;
        }

        public async Task<IEnumerable<BookingRecord>> GetByWorkplaceId(int workplaceId, DateTime date)
        {
            var records = await _unitOfWork.BookingRepository.GetByWorkplaceId(workplaceId, date);
            if (records == null)
                throw new KeyNotFoundException(_localizer["NotFound"].Value);
            return records;
        }

        public async Task Update(int id,BookingRecordUpdateDC contract)
        {
            var record = _mapper.Map<BookingRecord>(contract);
            await DateIntervalValidation(record);
            await _unitOfWork.BookingRepository.Update(record);
        }

        #region private methods

        /// <summary>
        /// Проверка корректности и конфликтов интервала дат контракта
        /// </summary>
        /// <param name="record"></param>
        /// <returns></returns>
        /// <exception cref="ArgumentException"></exception>
        private async Task DateIntervalValidation(BookingRecord record)
        {
            if (record.StartBookingDateTime >= record.EndBookingDateTime)
            {
                throw new ArgumentException(_localizer["IncorrectDateInterval"].Value);
            }
            if (record.StartBookingDateTime.Date != record.EndBookingDateTime.Date)
            {
                throw new ArgumentException(_localizer["IncorrectDateIntervalDate"].Value);
            }
            var targetDateRecords = await _unitOfWork.BookingRepository.GetByWorkplaceId(record.WorkplaceId, record.StartBookingDateTime);
            var conflictedRecords = targetDateRecords.Where(rec => !rec.IsCanceled && rec.HasDateConflict(record));
            if (conflictedRecords?.Count() > 0)
            {
                throw new ArgumentException(_localizer["DateIntervalConflict"].Value);
            }
        }

        #endregion
    }
}
