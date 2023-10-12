using AutoMapper;
using WorkplaceBooking.Authorization;
using WorkplaceBooking.Contracts.DataContracts;
using WorkplaceBooking.Contracts.Entities;
using WorkplaceBooking.Exceptions;
using WorkplaceBooking.Interfaces;

namespace WorkplaceBooking.Services
{
    public class UserService : IUserService
    {
        private IUserRepository _userRepository;
        private readonly IJwtUtils _jwtUtils;
        private readonly IMapper _mapper;

        public UserService(IUserRepository userRepository, IMapper mapper, IJwtUtils jwtUtils)
        {
            _userRepository = userRepository;
            _mapper = mapper;
            _jwtUtils = jwtUtils;
        }

        public async Task<UserAuthResponceDC> Auth(UserAuthRequestDC contract)
        {
            var user = await _userRepository.GetByEmail(contract.Email);
            if (user == null)
                throw new KeyNotFoundException(UserMessages.UserNotFound);
            if(user.Password != contract.Password)
                throw new AppException(UserMessages.IncorrectPassword);
            var token = _jwtUtils.GenerateJwtToken(user);
            return UserExtensions.ToUserAuthResponce(user, token);
        }

        public async Task<IEnumerable<User>> GetAll()
        {
            return await _userRepository.GetAll();
        }

        public async Task<User> GetById(int id)
        {
            var user = await _userRepository.GetById(id);
            if (user == null)
                throw new KeyNotFoundException(UserMessages.UserNotFound);
            return user;
        }

        public async Task<User> GetByEmail(string email)
        {
            var user = await _userRepository.GetByEmail(email);
            if (user == null)
                throw new KeyNotFoundException(UserMessages.UserNotFound);
            return user;
        }

        public async Task Create(UserCreateRequestDC contract)
        {
            if (await _userRepository.GetByEmail(contract.Email) != null)
                throw new AppException(UserMessages.UserEmailExist);
            var user = _mapper.Map<User>(contract);
            await _userRepository.Create(user);
        }

        public async Task Update(int id, UserUpdateRequestDC contract)
        {
            var user = await _userRepository.GetById(id);
            if (user == null)
                throw new KeyNotFoundException(UserMessages.UserNotFound);
            // TODO: покумекать?
            bool emailChanged = !string.IsNullOrEmpty(contract.Email) && user.Email != contract.Email;
            if (emailChanged && await _userRepository.GetByEmail(contract.Email) != null)
                throw new AppException(UserMessages.UserEmailExist);
            _mapper.Map<User>(contract);
            await _userRepository.Update(user);
        }

        public async Task Delete(int id)
        {
            await _userRepository.Delete(id);
        }
    }
}
