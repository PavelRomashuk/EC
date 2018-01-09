using EC.Contracts;
using EC.Models;
using System;
using System.Collections.Generic;
using System.Linq;

namespace EC.DataAccess.BLL
{
    public class UsersBLL : IAccountContract, IDisposable
    {
        protected DatabaseAccess _databaseAccess = null;
        public UsersBLL(DatabaseAccess databaseAccess)
        {
            this._databaseAccess = databaseAccess;
        }
        public UserActionResponses CreateUser(User user)
        {
            User existingUser = this._databaseAccess.Users.Where(x => x.Name == user.Name && x.EMail == user.EMail).FirstOrDefault();
            if (existingUser == null)
            {
                try
                {
                    this._databaseAccess.Users.Add(user);
                    this._databaseAccess.SaveChanges();
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

        public UserLogonResponse Logon(string userName, string userPWD)
        {

            User user = this._databaseAccess.Users.Where(x => x.Name == userName).FirstOrDefault();
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

        public List<User> GetAllUSers()
        {
            return this._databaseAccess.Users.ToList();
        }

        public void Dispose()
        {
            if (this._databaseAccess != null)
                this._databaseAccess.Dispose();
        }
    }

}
