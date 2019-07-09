using System;
using System.IdentityModel.Tokens.Jwt;
using System.Security.Claims;
using System.Text;
using System.Threading.Tasks;
using BelaSport.Models;
using BelaSport.Models.ApplicationSettings;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Options;
using Microsoft.IdentityModel.Tokens;

namespace BelaSport.WebApi.Controllers
{
    [Route("api/login")]
    [ApiController]
    public class LogInController : ControllerBase
    {

       // private readonly UserManager<IdentityUser> _userManager;
        private readonly SignInManager<IdentityUser> _signinManager;
        private readonly ApplicationSettings _appSettings;
        public LogInController(IOptions<ApplicationSettings> appSettings, SignInManager<IdentityUser> signinManager)
        {
            //UserManager<IdentityUser> userManager,  _userManager = userManager;
            _appSettings = appSettings.Value;
            _signinManager = signinManager;
        }

        [HttpPost]
        public async Task<IActionResult> Login(Host host)
        {
            if (ModelState.IsValid)
            {
                var result = await _signinManager.PasswordSignInAsync(host.DniHost.ToString(), host.PasswordHost, false, lockoutOnFailure: true);
                if (result.Succeeded)
                {
                    var tokenDescriptor = new SecurityTokenDescriptor
                    {
                        Subject = new ClaimsIdentity(new Claim[] {
                        new Claim("DniHost", host.DniHost.ToString())
                    }),
                        Expires = DateTime.UtcNow.AddMinutes(5),
                        SigningCredentials = new SigningCredentials(new SymmetricSecurityKey(Encoding.UTF8.GetBytes(_appSettings.JWT_Secret)), SecurityAlgorithms.HmacSha256Signature)
                    };

                    var tokenHandler = new JwtSecurityTokenHandler();
                    var securityToken = tokenHandler.CreateToken(tokenDescriptor);
                    var token = tokenHandler.WriteToken(securityToken);
                    return Ok(new { token });
                }
                else
                    return BadRequest(new { message = "Username or password is incorrect" });
            }
            else
                return BadRequest(new { message = "Username or password is incorrect" });
            //var hostDni = await _userManager.FindByIdAsync(host.DniHost.ToString());

            //if (hostDni!= null && await _userManager.CheckPasswordAsync(host, host.PasswordHost))
            //{
            //    var tokenDescriptor = new SecurityTokenDescriptor
            //    {
            //        Subject = new ClaimsIdentity(new Claim[] {
            //            new Claim("DniHost", hostDni.DniHost.ToString())
            //        }),
            //        Expires = DateTime.UtcNow.AddMinutes(5),
            //        SigningCredentials = new SigningCredentials(new SymmetricSecurityKey(Encoding.UTF8.GetBytes(_appSettings.JWT_Secret)), SecurityAlgorithms.HmacSha256Signature)
            //    };
            //    var tokenHandler = new JwtSecurityTokenHandler();
            //    var securityToken = tokenHandler.CreateToken(tokenDescriptor);
            //    var token = tokenHandler.WriteToken(securityToken);
            //    return Ok(new { token });
            //}
            //else
            //    return BadRequest(new { message = "Username or password is incorrect" });
        }
    }
}