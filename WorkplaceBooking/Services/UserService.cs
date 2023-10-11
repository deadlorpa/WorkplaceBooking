using WorkplaceBooking.Authorization;
using WorkplaceBooking.Contracts.DataContracts;
using WorkplaceBooking.Contracts.Entities;
using WorkplaceBooking.Interfaces;

namespace WorkplaceBooking.Services
{
    public class UserService : IUserService
    {
        private IUserRepository _userRepository;
        private readonly IJwtUtils _jwtUtils;
        //private readonly IMapper _mapper;

        public UserService(IUserRepository userRepository, /*IMapper mapper,*/ IJwtUtils jwtUtils)
        {
            _userRepository = userRepository;
            //_mapper = mapper;
            _jwtUtils = jwtUtils;
        }

        public Task<UserAuthResponceDC> Auth(UserAuthRequestDC model)
        {
            throw new NotImplementedException();
        }

        public async Task<IEnumerable<User>> GetAll()
        {
            return await _userRepository.GetAll();
        }

        public async Task<User> GetById(int id)
        {
            return await _userRepository.GetById(id);
        }

        public async Task<User> GetByEmail(string email)
        {
            var user = await _userRepository.GetByEmail(email);
            if (user == null)
                throw new KeyNotFoundException("User not found");
            return user;
        }

        public Task Create(UserCreateRequestDC contract)
        {
            throw new NotImplementedException();
        }

        public Task Update(int id, UserUpdateRequestDC contract)
        {
            throw new NotImplementedException();
        }

        public async Task Delete(int id)
        {
            await _userRepository.Delete(id);
        }
    }
}
