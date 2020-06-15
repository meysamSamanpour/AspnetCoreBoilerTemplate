using Meys.Common;
using Meys.Data.Repositories.Abstraction;
using Meys.Data.UnitOfWork;
using Meys.Domain.Entities;
using Meys.Service.Abstraction;
using Meys.Service.Services;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using Moq;
using System;

namespace Meys.Service.Tests
{
    [TestClass]
    public class UserServiceTests
    {

        private Mock<IUserRepository> _userRepository;
        private Mock<IHashService> _hashService;
        private UserService _service;
        private Mock<IUnitOfWork> _unitOfWork;

        [TestInitialize]
        public void Initialize()
        {
            _userRepository = new Mock<IUserRepository>();
            _hashService = new Mock<IHashService>();
            _unitOfWork = new Mock<IUnitOfWork>(); 
            _service = new UserService(_userRepository.Object, _hashService.Object);
        }

        [TestMethod]
        [ExpectedException(typeof(Exception))]
        public void AddNewUser_ThorwException_WhenPasswords_AreNotMatched()
        {
            var model = new AddNewUserDto
            {
                name = "",
                surname ="",
                confirmPassword ="2",
                password = "1"
            };
    
            _service.AddNewUser(model); 
        }

        [TestMethod]
        [ExpectedException(typeof(Exception))]
        public void AddNewUser_ThrowException_WhenMinPassLengthNotMet()
        {
            var model = GenerateUserModel(); 

            _service.AddNewUser(model);
        }

        [TestMethod]
        public void AddNewUser_CallAddMethod_OfRepository_And_HashPassword()
        {
            var model = GenerateUserModel();

            _service.AddNewUser(model);
            
            _userRepository.Verify(x => x.Add(It.IsAny<User>()), Times.Once);
            _hashService.Verify(x => x.HashePassword(It.IsAny<string>()));             
        }

        [TestMethod]
        public void VerifyPassword_ShouldCall_VerifyPassword_SaveChanges()
        {
            var email = "blabla@bla.com";
            var password = "password";

            _service.Authenticate(email, password);

            _hashService.Verify(x => x.Verify(It.IsAny<string>(), It.IsAny<string>()), Times.Once);
            _unitOfWork.Verify(x => x.SaveChanges(), Times.Once); 
        }

        private AddNewUserDto GenerateUserModel() =>
            new AddNewUserDto
            {
                name = "Meysam",
                surname = "Saman",
                confirmPassword = "12345",
                password = "12345"
            };

    }


}
