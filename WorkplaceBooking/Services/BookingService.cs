using AutoMapper;
using WorkplaceBooking.Authorization;
using WorkplaceBooking.Contracts.DataContracts;
using WorkplaceBooking.Contracts.Entities;
using WorkplaceBooking.Dal.Repositories;
using WorkplaceBooking.Interfaces;

namespace WorkplaceBooking.Services
{
    public class BookingService : IBookingService
    {
        private IBookingRepository _bookingRepository;
        private readonly IMapper _mapper;

        public BookingService(IBookingRepository bookingRepository, IMapper mapper)
        {
            _bookingRepository = bookingRepository;
            _mapper = mapper;
        }

        public async Task Create(BookingRecordCreateDC contract)
        {
            // TODO: add conditions
            var record = _mapper.Map<BookingRecord>(contract);
            await _bookingRepository.Create(record);
        }

        public async Task Delete(int id)
        {
            await _bookingRepository.Delete(id);
        }

        public async Task<IEnumerable<BookingRecord>> GetAll()
        {
            return await _bookingRepository.GetAll();
        }

        public async Task<BookingRecord> GetById(int id)
        {
            var record = await _bookingRepository.GetById(id);
            if (record == null)
                throw new KeyNotFoundException(BookingRecordMessages.RecordNotFound);
            return record;
        }

        public async Task<IEnumerable<BookingRecord>> GetByWorkplaceId(int workplaceId)
        {
            var record = await _bookingRepository.GetByWorkplaceId(workplaceId);
            if (record == null)
                throw new KeyNotFoundException(BookingRecordMessages.RecordNotFound);
            return record;
        }

        public async Task<IEnumerable<BookingRecord>> GetByUserId(int idUser)
        {
            var record = await _bookingRepository.GetByUserId(idUser);
            if (record == null)
                throw new KeyNotFoundException(BookingRecordMessages.RecordNotFound);
            return record;
        }

        public async Task Update(int id,BookingRecordUpdateDC contract)
        {
            // TODO: add conditions
            var record = _mapper.Map<BookingRecord>(contract);
            await _bookingRepository.Create(record);
        }
    }
}
