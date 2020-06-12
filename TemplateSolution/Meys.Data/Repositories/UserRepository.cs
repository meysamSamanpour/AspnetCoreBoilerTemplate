using Meys.Data.Repositories.Abstraction;
using Meys.Data.UnitOfWorkAndGeneralRepo;
using Meys.Domain.Entities;
using System.Linq;

namespace Meys.Data.Repositories
{
    public class UserRepository : Repository<User>, IUserRepository
    {
        public UserRepository(ApplicationDbContext context) : base(context)
        {
        }

        public User GetbyEmail(string email) => Find(x => x.Email == email).First();
        
    }
}
