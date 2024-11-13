using FSK_BusinessObjects;
using FSK_Repositories;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FSK_Services
{
    public class UserService : IUserService
    {
        private readonly IUserRepo iUserRepo;
        public UserService()
        {
            iUserRepo = new UserRepo();
        }
        public User GetUserByEmail(string email)
        {
            return iUserRepo.GetUserByEmail(email);
        }

        public bool AddUser(User user)
        {
            return iUserRepo.AddUser(user);
        }
    }
}
