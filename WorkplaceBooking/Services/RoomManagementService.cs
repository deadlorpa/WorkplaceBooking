using AutoMapper;
using WorkplaceBooking.Contracts.DataContracts;
using WorkplaceBooking.Contracts.DataContracts.Extensions;
using WorkplaceBooking.Contracts.Entities;
using WorkplaceBooking.Interfaces;

namespace WorkplaceBooking.Services
{
    public class RoomManagementService : IRoomManagementService
    {
        private IRoomRepository _roomRepository;
        private IWorkplaceRepository _workspaceRepository;
        private readonly IMapper _mapper;

        public RoomManagementService(IRoomRepository roomRepository, IWorkplaceRepository workspaceRepository, IMapper mapper)
        {
            _roomRepository = roomRepository;
            _workspaceRepository = workspaceRepository;
            _mapper = mapper;
        }

        public async Task<Room> CreateRoom(RoomCreateRequestDC request)
        {
            var room = _mapper.Map<Room>(request);
            room = await _roomRepository.Create(room);
            return room;
        }

        public async Task<Workplace> CreateWorkplace(WorkplaceCreateRequestDC request)
        {
            var workplace = _mapper.Map<Workplace>(request);
            workplace = await _workspaceRepository.Create(workplace);
            return workplace;
        }

        public async Task DeleteRoom(int roomId)
        {
            await _roomRepository.Delete(roomId);
        }

        public async Task DeleteWorkplace(int idWorkplace)
        {
            await _workspaceRepository.Delete(idWorkplace);
        }

        public async Task<IEnumerable<Room>> GetAllRooms()
        {
            return await _roomRepository.GetAll();
        }

        public async Task<IEnumerable<RoomFullResponceDC>> GetFull()
        {
            var rooms = await _roomRepository.GetAll();
            return rooms.Select(x => RoomExtensions.ToRoomFullResponce(x, _workspaceRepository.GetByRoomId(x.Id).Result));
        }

        public async Task<IEnumerable<Workplace>> GetWorkplacesByRoomId(int roomId)
        {
            return await _workspaceRepository.GetByRoomId(roomId);
        }

        public async Task<Room> UpdateRoom(int idRoom, RoomUpdateRequestDC request)
        {
            var room = await _roomRepository.GetById(idRoom);
            if(room == null)
                throw new KeyNotFoundException(RoomMessages.RoomNotFound);
            _mapper.Map(request, room);
            await _roomRepository.Update(room);
            return room;
        }

        public async Task<Workplace> UpdateWorkplace(int idWorkplace, WorkplaceUpdateRequestDC request)
        {
            var workplace = await _workspaceRepository.GetById(idWorkplace);
            if (workplace == null)
                throw new KeyNotFoundException(WorkplaceMessages.WorplaceNotFound);
            _mapper.Map(request, workplace);
            await _workspaceRepository.Update(workplace);
            return workplace;
        }
    }
}
