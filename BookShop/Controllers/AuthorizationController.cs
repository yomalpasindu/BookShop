using BookShop.Models;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.IdentityModel.Tokens;
using System.IdentityModel.Tokens.Jwt;
using System.Security.Claims;
using System.Text;

namespace BookShop.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class AuthorizationController : ControllerBase
    {
        [HttpGet]
        public IActionResult Authenticate(string username, string password)
        {
            throw new NotImplementedException();
            //if (username == "a" && password == "a")
            //{
            //    var claims = new[]
            //    {
            //        new Claim("User","Yomal Pasindu"),
            //        new Claim("Id","3086265")
            //    };

            //    var key = new SymmetricSecurityKey(Encoding.UTF8.GetBytes(Constant.Secret));

            //    var signingCredentials = new SigningCredentials(key,SecurityAlgorithms.HmacSha256);

            //    var token=new JwtSecurityToken(
            //        Constant.Issuer,
            //        Constant.Audience,
            //        claims,
            //        notBefore:DateTime.Now,
            //        expires:DateTime.Now.AddMinutes(20),
            //        signingCredentials);

            //    var tokenString= new JwtSecurityTokenHandler().WriteToken(token);
            //    return Ok(tokenString);
            //}
            //return BadRequest();
        }
    }
}
