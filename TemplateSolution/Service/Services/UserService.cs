using Meys.Common;
using Meys.Data.Repositories.Abstraction;
using Meys.Domain.Entities;
using Meys.Service.Abstraction;
using System;

namespace Meys.Service.Services
{
    public class UserService: IUserService
    {
        private readonly IUserRepository _userRepository;
        private readonly IHashService _hashService;

        public UserService(IUserRepository userRepository, IHashService hashService)
        {
            _userRepository = userRepository;
            _hashService = hashService;
        }

        public void AddNewUser(AddNewUserDto model)
        {
            if (model.password != model.confirmPassword)
                throw new Exception("Passwords are not matched.");

            if (model.password.Length < 6)
                throw new Exception("Password is too short, min 6 chars.");

            var newUser = new User
            {
                CreatedDate = DateTime.UtcNow,
                Name = model.name,
                Surname = model.surname,
                PasswordHash = _hashService.HashePassword(model.password)
            };

            _userRepository.Add(newUser);

        }

        public void Authenticate(string email, string password)
        {
            var user = _userRepository.GetbyEmail(email);

            _hashService.Verify(password, user.PasswordHash);            
        }
    }
}
