using System;
using System.Collections.Generic;
using System.IdentityModel.Tokens.Jwt;
using System.Linq;
using System.Security.Claims;
using System.Text;
using System.Threading.Tasks;
using EC.Contracts;
using EC.Models;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.IdentityModel.Tokens;

namespace EC.WebCore.Controllers.Concrete
{
    [Produces("application/json")]
    [Route("api/Concrete")]
    public class ConcreteController : Controller
    {
        protected IAccountContract _accountContract;
        public ConcreteController(IAccountContract accountContract)
        {
            _accountContract = accountContract;
        }

        [Route("/token")]
        [HttpPost]
        public IActionResult Create(string username, string password)
        {
            UserLogonResponse  userLogonResponse = _accountContract.Logon(username, password);
            if (userLogonResponse.ResponseStatus == ResponseStatus.Success)
                return new ObjectResult(GenerateToken(userLogonResponse.LoggedInUser));
            return BadRequest();
        }

        protected string GenerateToken(User user)
        {
            var claims = new Claim[] {
                new Claim(ClaimTypes.Name, user.Name),
                new Claim(JwtRegisteredClaimNames.Email, user.EMail),
                new Claim(JwtRegisteredClaimNames.Exp, $"{new DateTimeOffset(DateTime.Now.AddDays(1)).ToUnixTimeSeconds()}"),
                new Claim(JwtRegisteredClaimNames.Nbf, $"{new DateTimeOffset(DateTime.Now).ToUnixTimeSeconds()}")
            };
            var secretKey = new SymmetricSecurityKey(Encoding.UTF8.GetBytes("a secret that needs to be at least 16 characters long"));
            var token = new JwtSecurityToken(new JwtHeader(new SigningCredentials(secretKey, SecurityAlgorithms.HmacSha256)), new JwtPayload(claims));
            string jwtToken = new JwtSecurityTokenHandler().WriteToken(token);
            return jwtToken;
        }
    }
}