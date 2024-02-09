using AutoMapper;
using Microsoft.Extensions.Localization;
using WorkplaceBooking.Core.Contracts.DataContracts;
using WorkplaceBooking.Core.Contracts.Entities;
using WorkplaceBooking.Core.Exceptions;
using WorkplaceBooking.Core.Interfaces;

namespace WorkplaceBooking.Core.Services
{
    public class UserService : IUserService
    {
        private IUnitOfWork _unitOfWork;
        private readonly IJwtUtils _jwtUtils;
        private readonly IMapper _mapper;
        private readonly IStringLocalizer<UserService> _localizer;

        public UserService(IUnitOfWork unitOfWork,
            IMapper mapper,
            IJwtUtils jwtUtils,
            IStringLocalizer<UserService> localizer)
        {
            _unitOfWork = unitOfWork;
            _mapper = mapper;
            _jwtUtils = jwtUtils;
            _localizer = localizer;
        }

        public async Task<UserAuthResponceDC> Auth(UserAuthRequestDC contract)
        {
            var user = await _unitOfWork.UserRepository.GetByEmail(contract.Email);
            if (user == null)
                throw new KeyNotFoundException(_localizer["NotFound"].Value);
            if(user.Password != contract.Password)
                throw new AppException(_localizer["WrongPassword"].Value);
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
                throw new KeyNotFoundException(_localizer["NotFound"].Value);
            return user;
        }

        public async Task<User> GetByEmail(string email)
        {
            var user = await _unitOfWork.UserRepository.GetByEmail(email);
            if (user == null)
                throw new KeyNotFoundException(_localizer["NotFound"].Value);
            return user;
        }

        public async Task Create(UserCreateRequestDC contract)
        {
            if (await _unitOfWork.UserRepository.GetByEmail(contract.Email) != null)
                throw new AppException(_localizer["EmailBusy"].Value);
            var user = _mapper.Map<User>(contract);
            await _unitOfWork.UserRepository.Create(user);
        }

        public async Task Update(int id, UserUpdateRequestDC contract)
        {
            var user = await _unitOfWork.UserRepository.GetById(id);
            if (user == null)
                throw new KeyNotFoundException(_localizer["NotFound"].Value);
            // TODO: refactoring?
            bool emailChanged = !string.IsNullOrEmpty(contract.Email) && user.Email != contract.Email;
            if (emailChanged && await _unitOfWork.UserRepository.GetByEmail(contract.Email) != null)
                throw new AppException(_localizer["EmailBusy"].Value);
            _mapper.Map(contract, user);
            await _unitOfWork.UserRepository.Update(user);
        }

        public async Task Delete(int id)
        {
            await _unitOfWork.UserRepository.Delete(id);
        }
    }
}
