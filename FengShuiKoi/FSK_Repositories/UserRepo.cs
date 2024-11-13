using FSK_BusinessObjects;
using FSK_DAOs;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FSK_Repositories
{
    public class UserRepo : IUserRepo
    {
        public bool AddUser(User user) => UserDAO.AddUser(user);

        public User GetUserByEmail(string email) => UserDAO.GetUserByEmail(email);
    }
}
