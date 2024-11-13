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

        public static User GetUser(String userID)
        {
            using var db = new FengShuiKoiDbContext();
            return db.Users.FirstOrDefault(c => c.UserId.Equals(userID));
        }

        public static bool AddUser(User user)
        {
            bool isSuccess = false;
            using var context = new FengShuiKoiDbContext();
            if(GetUserByEmail(user.Email) == null && GetUser(user.UserId) == null)
            {
                    context.Users.Add(user);
                    context.SaveChanges();
                    isSuccess = true;
            }
            return isSuccess;
        }
    }
}
