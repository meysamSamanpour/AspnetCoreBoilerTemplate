namespace Meys.Service.Abstraction
{
    /// <summary>
    /// Serive to hash and the password or any other secret key
    /// </summary>
    public interface IHashService
    {
        /// <summary>
        /// Hashe the raw password
        /// </summary>
        /// <param name="password"> unhashed password</param>
        /// <returns>the hashed password, which contains the password and the slat </returns>
        string HashePassword(string password);

        /// <summary>
        /// Verify the hashed password to see if it is equal to the provided password.
        /// </summary>
        /// <param name="password"> The provided password</param>
        /// <param name="hashedPasword"> Usually, the hashed password in the DB</param>
        /// <returns>if the password is not valid then this method throw exception </returns>
        void Verify(string password, string hashedPasword); 
    }
}
