using Meys.Common.Dto;

namespace Meys.Service.Abstraction
{
    /// <summary>
    /// A general service for manage users
    /// </summary>
    public interface IUserService
    {
        /// <summary>
        /// Adding a new User to the Db
        /// </summary>
        /// <param name="model"> a DTO model that comes from the frontend</param>
        public void AddNewUser(AddNewUserDto model);

        /// <summary>
        /// Autheticate the user. 
        /// </summary>
        /// <param name="email"></param>
        /// <param name="password"></param>
        void Authenticate(string email, string password);
    }
}
