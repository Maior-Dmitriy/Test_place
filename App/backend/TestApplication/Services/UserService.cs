using AutoMapper;
using DL.RepositoryContracts;
using Model.DL;
using Models.Dto;
using PasswordManagers;
using ServiceContracts;
using System;

namespace Services
{
    public class UserService : BaseService<UserDtoModel, UserEntity>, IUserService
    {
        private IPasswordManager _passwordManager;

        public UserService(IUserRepository repository, IMapper mapper, IPasswordManager passwordManager)
            :base(repository, mapper)
        {
            _passwordManager = passwordManager;
        }

        public UserDtoModel Authenticate(string login, string password)
        {
            var hashedPassword = _passwordManager.HashPassword(password);

            var user = ((IUserRepository)_repository).Authenticate(login, hashedPassword); 

            if (user == null)
            {
                throw new ArgumentException($"Invalid login '{login}' or password");
            }

            var apiModel = _mapper.Map<UserEntity, UserDtoModel>(user);

            return apiModel;
        }
    }
}
