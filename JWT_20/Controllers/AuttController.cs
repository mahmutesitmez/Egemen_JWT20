
using JWT_20.Data;
using JWT_20.Model;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using Microsoft.IdentityModel.Tokens;
using System;
using System.Collections.Generic;
using System.IdentityModel.Tokens.Jwt;
using System.Security.Claims;
using System.Text;
using System.Threading.Tasks;

namespace JWT_20.Controllers
{
    [Route("[controller]")]
    [ApiController]
    //[Authorize]
    public class AuttController : ControllerBase
    {
        private UserManager<ApplicationUser> userManager;

        public AuttController(UserManager<ApplicationUser> userManager)
        {
            this.userManager = userManager;
        }

        [HttpPost]
        public async Task<IActionResult> Login([FromBody] LoginModel model)
        {
            var user = await userManager.FindByNameAsync(model.UserName);
            if (user != null && await userManager.CheckPasswordAsync(user, model.Password))
            {
                var claims = new List<Claim>
                    {
                        new Claim(JwtRegisteredClaimNames.Sub, user.UserName),
                        new Claim(JwtRegisteredClaimNames.Jti, Guid.NewGuid().ToString())
                    };
                var signinKey = new SymmetricSecurityKey(Encoding.UTF8.GetBytes("AspNetCoreDersim"));
                var token = new JwtSecurityToken(
                    issuer: "https://localhost:44311",
                    audience: "https://localhost:44311",
                    expires: DateTime.Now.AddHours(1),
                    claims: claims,
                    signingCredentials: new SigningCredentials(signinKey, SecurityAlgorithms.HmacSha256)
                    );
                return Ok(new
                {
                    token = new JwtSecurityTokenHandler().WriteToken(token),
                    expiration = token.ValidTo,
                    message = "Giriş Başarılı"
                });
            }
            else
            {
                return BadRequest(new
                {
                    message = "Kullanıcı adı ve parola yanlış"
                });
            }
        }
    }
}
    
    
