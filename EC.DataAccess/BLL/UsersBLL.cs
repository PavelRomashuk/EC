using EC.Contracts;
using EC.Models;
using System;
using System.Collections.Generic;
using System.Linq;

namespace EC.DataAccess.BLL
{
    public class UsersBLL: IAccountContract
    {
        public UserActionResponses CreateUser(User user)
        {
            using (DatabaseAccess da = new DatabaseAccess())
            {
                User existingUser = da.Users.Where(x => x.Name == user.Name && x.EMail == user.EMail).FirstOrDefault();
                if (existingUser == null)
                {
                    try
                    {
                        da.Users.Add(user);
                        da.SaveChanges();
                        return new UserActionResponses { Message = $"User with name {user.Name} has been created.", ResponseStatus = ResponseStatus.Success };
                    }
                    catch (Exception ex)
                    {
                        return new UserActionResponses { Message = ex.Message, ResponseStatus = ResponseStatus.Error };
                    }
                }
                else
                    return new UserActionResponses { Message = $"User with name {user.Name} and email {user.EMail} already exists!", ResponseStatus = ResponseStatus.UserExists };
            }
        }

        public UserLogonResponse Logon(string userName, string userPWD)
        {
            using (DatabaseAccess da = new DatabaseAccess())
            {
                User user = da.Users.Where(x => x.Name == userName).FirstOrDefault();
                if (user == null)
                    return new UserLogonResponse { ResponseStatus = ResponseStatus.UserDoesnExists, Message = $"User with name {userName} does not exists!" };

                if (user != null && user.PWD != userPWD)
                    return new UserLogonResponse { ResponseStatus = ResponseStatus.PasswordDoesNotMatch, Message = "User name and password does not match!" };

                return new UserLogonResponse {
                    ResponseStatus = ResponseStatus.Success,
                    Message = $"User with name {userName} sucessully logged in!",
                    LoggedInUser = user
                };

            }
        }

        public List<User> GetAllUSers()
        {
            using (DatabaseAccess da = new DatabaseAccess())
            {
                return da.Users.ToList();
            }
        }
    }

}
