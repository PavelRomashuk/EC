using System.ComponentModel.DataAnnotations;

namespace EC.Web.Models
{
    public class LogonModel
    {
        public int UserId { get; set; }
        [Required]
        public string UserName { get; set; }
        [DataType(DataType.Password)]
        public string Password { get; set; }
        public bool RememberMe { get; set; }
    }
}