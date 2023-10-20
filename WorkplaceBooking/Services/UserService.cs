using AutoMapper;
using WorkplaceBooking.Contracts.DataContracts;
using WorkplaceBooking.Contracts.Entities;
using WorkplaceBooking.Exceptions;
using WorkplaceBooking.Interfaces;

namespace WorkplaceBooking.Services
{
    public class UserService : IUserService
    {
        private IUnitOfWork _unitOfWork;
        private readonly IJwtUtils _jwtUtils;
        private readonly IMapper _mapper;

        public UserService(IUnitOfWork unitOfWork, IMapper mapper, IJwtUtils jwtUtils)
        {
            _unitOfWork = unitOfWork;
            _mapper = mapper;
            _jwtUtils = jwtUtils;
        }

        public async Task<UserAuthResponceDC> Auth(UserAuthRequestDC contract)
        {
            var user = await _unitOfWork.UserRepository.GetByEmail(contract.Email);
            if (user == null)
                throw new KeyNotFoundException(UserMessages.UserNotFound);
            if(user.Password != contract.Password)
                throw new AppException(UserMessages.IncorrectPassword);
            var token = _jwtUtils.GenerateJwtToken(user);
            return UserExtensions.ToUserAuthResponce(user, token);
        }

        public async Task<IEnumerable<User>> GetAll()
        {
            return await _unitOfWork.UserRepository.GetAll();
        }

        public async Task<User> GetById(int id)
        {
            var user = await _unitOfWork.UserRepository.GetById(id);
            if (user == null)
                throw new KeyNotFoundException(UserMessages.UserNotFound);
            return user;
        }

        public async Task<User> GetByEmail(string email)
        {
            var user = await _unitOfWork.UserRepository.GetByEmail(email);
            if (user == null)
                throw new KeyNotFoundException(UserMessages.UserNotFound);
            return user;
        }

        public async Task Create(UserCreateRequestDC contract)
        {
            if (await _unitOfWork.UserRepository.GetByEmail(contract.Email) != null)
                throw new AppException(UserMessages.UserEmailExist);
            var user = _mapper.Map<User>(contract);
            await _unitOfWork.UserRepository.Create(user);
        }

        public async Task Update(int id, UserUpdateRequestDC contract)
        {
            var user = await _unitOfWork.UserRepository.GetById(id);
            if (user == null)
                throw new KeyNotFoundException(UserMessages.UserNotFound);
            // TODO: refactoring?
            bool emailChanged = !string.IsNullOrEmpty(contract.Email) && user.Email != contract.Email;
            if (emailChanged && await _unitOfWork.UserRepository.GetByEmail(contract.Email) != null)
                throw new AppException(UserMessages.UserEmailExist);
            _mapper.Map(contract, user);
            await _unitOfWork.UserRepository.Update(user);
        }

        public async Task Delete(int id)
        {
            await _unitOfWork.UserRepository.Delete(id);
        }
    }
}
