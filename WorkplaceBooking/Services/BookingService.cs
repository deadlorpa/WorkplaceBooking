using AutoMapper;
using Microsoft.Extensions.Localization;
using WorkplaceBooking.Contracts.DataContracts;
using WorkplaceBooking.Contracts.Entities;
using WorkplaceBooking.Interfaces;

namespace WorkplaceBooking.Services
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
            //  TODO: add datetime range conditions
            var record = _mapper.Map<BookingRecord>(contract);
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
            var record = await _unitOfWork.BookingRepository.GetByWorkplaceId(workplaceId);
            if (record == null)
                throw new KeyNotFoundException(_localizer["NotFound"].Value);
            return record;
        }

        public async Task<IEnumerable<BookingRecord>> GetByUserId(int idUser)
        {
            var record = await _unitOfWork.BookingRepository.GetByUserId(idUser);
            if (record == null)
                throw new KeyNotFoundException(_localizer["NotFound"].Value);
            return record;
        }

        public async Task Update(int id,BookingRecordUpdateDC contract)
        {
            // TODO: add datetime range conditions
            var record = _mapper.Map<BookingRecord>(contract);
            await _unitOfWork.BookingRepository.Update(record);
        }
    }
}
