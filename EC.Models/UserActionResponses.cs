using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EC.Models
{

    public class UserActionResponses
    {
        public string Message { get; set; }
        public ResponseStatus ResponseStatus { get; set; }
    }

    public class UserLogonResponse
    {
        public string Message { get; set; }
        public ResponseStatus ResponseStatus { get; set; }
        public User LoggedInUser { get; set; }
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
