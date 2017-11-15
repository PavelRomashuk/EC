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
        public UserCreatorResponse CreateUser(User user)
        {
            using (DataAccess da = new DataAccess())
            {
                User existingUser = da.Users.Where(x => x.Name == user.Name && x.EMail == user.EMail).FirstOrDefault();
                if (existingUser == null)
                {
                    try
                    {
                        da.Users.Add(user);
                        da.SaveChanges();
                        return new UserCreatorResponse { Message = $"User with name {user.Name} has been created.", ResponseStatus = ResponseStatus.Success};
                    }
                    catch(Exception ex)
                    {
                        return new UserCreatorResponse { Message = ex.Message, ResponseStatus = ResponseStatus.Error };
                    }
                }
                else
                    return new UserCreatorResponse { Message = $"User with name {user.Name} and email {user.EMail} already exists!", ResponseStatus = ResponseStatus.UserExists };
            }
        }

        public UserLogonResponse Logon(string userName, string userPWD)
        {
            using (DataAccess da = new DataAccess())
            {
                User user = da.Users.Where(x => x.Name == userName).FirstOrDefault();
                if (user == null)
                    return new UserLogonResponse { ResponseStatus = ResponseStatus.UserDoesnExists, Message = $"User with name {userName} does not exists!"};

                if (user != null && user.PWD != userPWD)
                    return new UserLogonResponse { ResponseStatus = ResponseStatus.PasswordDoesNotMatch, Message = "User name and password does not match!" };

                return new UserLogonResponse { ResponseStatus = ResponseStatus.Success, Message = $"User with name {userName} sucessully logged in!" };

            }
        }
    }

    public class UserCreatorResponse
    {
        public string Message { get; set; }
        public ResponseStatus ResponseStatus { get; set; }
    }

    public class UserLogonResponse
    {
        public string Message { get; set; }
        public ResponseStatus ResponseStatus { get;set;}
    }

    public enum ResponseStatus
    {
        Success,
        UserExists,
        UserDoesnExists,
        PasswordDoesNotMatch,
        Error
    }
}
