using AutoMapper;
using Microsoft.Extensions.Localization;
using WorkplaceBooking.Contracts.DataContracts;
using WorkplaceBooking.Contracts.DataContracts.Extensions;
using WorkplaceBooking.Contracts.Entities;
using WorkplaceBooking.Interfaces;

namespace WorkplaceBooking.Services
{
    public class RoomManagementService : IRoomManagementService
    {
        private IUnitOfWork _unitOfWork;
        private readonly IMapper _mapper;
        private readonly IStringLocalizer<RoomManagementService> _localizer;

        public RoomManagementService(IUnitOfWork unitOfWork,
            IMapper mapper,
            IStringLocalizer<RoomManagementService> localizer)
        {
            _unitOfWork = unitOfWork;
            _mapper = mapper;
            _localizer = localizer;
        }

        public async Task<Room> CreateRoom(RoomCreateRequestDC request)
        {
            var room = _mapper.Map<Room>(request);
            room.Id = await _unitOfWork.RoomRepository.Create(room);
            return room;
        }

        public async Task<Workplace> CreateWorkplace(WorkplaceCreateRequestDC request)
        {
            var workplace = _mapper.Map<Workplace>(request);
            workplace.Id = await _unitOfWork.WorkplaceRepository.Create(workplace);
            return workplace;
        }

        public async Task DeleteRoom(int roomId)
        {
            await _unitOfWork.RoomRepository.Delete(roomId);
        }

        public async Task DeleteWorkplace(int idWorkplace)
        {
            await _unitOfWork.WorkplaceRepository.Delete(idWorkplace);
        }

        public async Task<IEnumerable<Room>> GetAllRooms()
        {
            return await _unitOfWork.RoomRepository.GetAll();
        }

        public async Task<IEnumerable<RoomFullResponceDC>> GetFull()
        {
            var rooms = await _unitOfWork.RoomRepository.GetAll();
            return rooms.Select(x => RoomExtensions.ToRoomFullResponce(x, _unitOfWork.WorkplaceRepository.GetByRoomId(x.Id).Result));
        }

        public async Task<IEnumerable<Workplace>> GetWorkplacesByRoomId(int roomId)
        {
            return await _unitOfWork.WorkplaceRepository.GetByRoomId(roomId);
        }

        public async Task<Room> UpdateRoom(int idRoom, RoomUpdateRequestDC request)
        {
            var room = await _unitOfWork.RoomRepository.GetById(idRoom);
            if(room == null)
                throw new KeyNotFoundException(_localizer["RoomNotFound"].Value);
            _mapper.Map(request, room);
            await _unitOfWork.RoomRepository.Update(room);
            return room;
        }

        public async Task<Workplace> UpdateWorkplace(int idWorkplace, WorkplaceUpdateRequestDC request)
        {
            var workplace = await _unitOfWork.WorkplaceRepository.GetById(idWorkplace);
            if (workplace == null)
                throw new KeyNotFoundException(_localizer["WorplaceNotFound"].Value);
            _mapper.Map(request, workplace);
            await _unitOfWork.WorkplaceRepository.Update(workplace);
            return workplace;
        }
    }
}
