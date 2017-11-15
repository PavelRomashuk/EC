using EC.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EC.DataAccess.BLL
{
    public class UsersBLL
    {
        public UserCreatorResponseStatus CreateUser(User user)
        {
            using (DataAccess da = new DataAccess())
            {
                User existingUser = da.Users.Where(x => x.Name == user.Name && x.EMail == user.EMail).FirstOrDefault();
                if (existingUser == null)
                {
                    try
                    {
                        da.Users.Add(user);
                        return UserCreatorResponseStatus.Success;
                    }
                    catch
                    {
                        return UserCreatorResponseStatus.Error;
                    }
                }
                else
                    return UserCreatorResponseStatus.UserExists;
            }
        }

        public enum UserCreatorResponseStatus
        {
            Success,
            UserExists,
            Error
        }
    }
}
