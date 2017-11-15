using EC.Models;
using EC.Web.Models;
using AutoMapper;

namespace EC.Web.Convertors
{
    public class UserViewModelToUserCovertor
    {
        public UserViewModelToUserCovertor()
        {

        }
        public User Convert(LogonModel logonModel)
        {
            return Mapper.Map<LogonModel, User>(logonModel);
        }

        public User Convert(RegisterModel registerModel)
        {
            return Mapper.Map<RegisterModel, User>(registerModel);
        }
    }
}