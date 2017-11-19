using EC.Models;
using System.Collections.Generic;

namespace EC.Contracts
{
    public interface IAccountContract
    {
        UserActionResponses CreateUser(User user);
        UserLogonResponse Logon(string userName, string userPWD);
        List<User> GetAllUSers();
    }
}
