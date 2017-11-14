using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EC.Models
{
    public class User: BaseModel
    {
        public int UserId { get; set; }
        public string Name { get; set; }
        public string EMail { get; set; }
        public string Phone { get; set; }
        public UserType UserType { get; set; }
        public string  PWD { get; set; }
    }

    public enum UserType
    {
        Admin,
        Teacher,
        Student
    }
}
