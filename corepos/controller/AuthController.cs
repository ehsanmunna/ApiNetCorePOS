using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using corepos.Models;
using corepos.Services;
using Microsoft.AspNetCore.Mvc;
using System.IdentityModel.Tokens.Jwt;
using System.Text;
using Microsoft.IdentityModel.Tokens;
using System.Security.Claims;
using AutoMapper;

namespace corepos.controller
{
    [Route("api/[controller]")]
    [ApiController]
    public class AuthController : Controller
    {
        private IAuthRepository _authRepo;
        public AuthController(IAuthRepository authRepo)
        {
            _authRepo = authRepo;
        }

        [HttpPost("login")]
        public IActionResult Login([FromBody] LoginDto req)
        {
            var user = _authRepo.GetPosUserByUserName(req.UserName);
            var userView = Mapper.Map<PosUserViewDto>(user);
            if (user == null)
            {
                return BadRequest(new { message = "Username is incorrect" });
            }
            if (user.Password != req.Password)
            {
                return BadRequest(new { message = "password is incorrect" });
            }
            
            var _secret = "THIS IS USED TO SIGN AND VERIFY JWT TOKENS, REPLACE IT WITH YOUR OWN SECRET, IT CAN BE ANY STRING";
            var tokenHandler = new JwtSecurityTokenHandler();
            var _key = Encoding.ASCII.GetBytes(_secret);
            var tokenDescriptor = new SecurityTokenDescriptor
            {
                Subject = new ClaimsIdentity(new Claim[] {
                    new Claim(ClaimTypes.Name, user.UserId)
                }),
                Expires = DateTime.UtcNow.AddDays(7),
                SigningCredentials = new SigningCredentials(new SymmetricSecurityKey(_key), SecurityAlgorithms.HmacSha256Signature)
            };

            var token = tokenHandler.CreateToken(tokenDescriptor);
            var tokenStr = tokenHandler.WriteToken(token);
            var tokenObj = new { accessToken = tokenStr, user = userView, expiration = tokenDescriptor.Expires};


            return Ok(tokenObj);
        }
    }
}