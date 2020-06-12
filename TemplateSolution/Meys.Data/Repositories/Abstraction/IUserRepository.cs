using Meys.Data.UnitOfWorkAndGeneralRepo;
using Meys.Domain.Entities;

namespace Meys.Data.Repositories.Abstraction
{
    public interface IUserRepository : IRepository<User>
    {
        User GetbyEmail(string email);
    }
}
