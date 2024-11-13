using FSK_BusinessObjects;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FSK_Repositories
{
    public interface IUserRepo
    {
        User GetUserByEmail(String email);

        bool AddUser(User user);
    }
}
