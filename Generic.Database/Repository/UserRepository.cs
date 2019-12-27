using Generic.Database.Poco;
using Generic.Framework;
using System.Linq;

namespace Generic.Database.Repository
{
    public class UserRepository : BaseRepository<GenericDbContext, Users>, IUserRepository
    {

        public bool Login(string username, string password)
        {
            return GetAll().ToList().Any(a => a.UserName == username && a.Password == password);
        }
    }
}
