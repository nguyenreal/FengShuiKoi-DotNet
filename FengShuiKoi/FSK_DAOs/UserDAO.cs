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
        private FengShuiKoiDbContext dbcontext;
        private static UserDAO instance;

        public static UserDAO Instance
        {
            get
            {
                if (instance == null)
                {
                    instance = new UserDAO();
                }
                return instance;
            }
        }

        public UserDAO()
        {
            dbcontext = new FengShuiKoiDbContext();
        }

        public List<User> GetUserElements()
        {
            var listUserElement = new List<User>();
            try
            {
                using var context = new FengShuiKoiDbContext();
                listUserElement = context.Users.ToList();
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
            return listUserElement;
        }
        public static User GetUserByEmail(String email)
        {
            using var db = new FengShuiKoiDbContext();
            return db.Users.FirstOrDefault(c => c.Email.Equals(email));
        }
    }
}
