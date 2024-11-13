using FSK_BusinessObjects;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FSK_Services
{
    public interface IUserService
    {
        User GetUserByEmail(String email);

        bool AddUser(User user);
    }
}
