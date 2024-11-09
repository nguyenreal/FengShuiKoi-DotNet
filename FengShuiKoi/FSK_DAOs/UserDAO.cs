using FSK_BusinessObjects;
using Microsoft.Identity.Client;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FSK_DAOs
{
    public class UserDAO
    {
        public static User GetUserByEmail(String email)
        {
            using var db = new FengShuiKoiDbContext();
            return db.Users.FirstOrDefault(c => c.Email.Equals(email));
        }
    }
}
