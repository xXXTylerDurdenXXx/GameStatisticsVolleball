using GameStatisticsVolleball.Models;

namespace GameStatisticsVolleball.Repositories
{
    public class UserRepository : IUserRepository
    {
        private readonly APIDBContext _context;

        public UserRepository(APIDBContext context)
        {
            _context = context;
        }
        public User AddUser(User user)
        {
            _context.Users.Add(user);
            _context.SaveChanges();
            return user;
        }

        public bool DeleteUser(int id)
        {
            throw new NotImplementedException();
        }

        public User ExistUser(string loginOrEmail)
        {
            throw new NotImplementedException();
        }

        public User GetUserById(int id)
        {
            throw new NotImplementedException();
        }

        public Role? RoleExists(int id)
        {
            throw new NotImplementedException();
        }

        public User UpdateUser(int id, User user)
        {
            throw new NotImplementedException();
        }
    }
}
