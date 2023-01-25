using AngularERPApi.Models;
using AngularERPApi.Models.AccountViewModels;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Configuration;
using Microsoft.IdentityModel.Tokens;
using System;
using System.Collections.Generic;
using System.IdentityModel.Tokens.Jwt;
using System.Security.Claims;
using System.Text;
using System.Threading.Tasks;

namespace AngularERPApi.Controllers
{
    [Route("api/Authenticate")]
    [ApiController]
    public class AuthenticateController : ControllerBase
    {
        private readonly UserManager<ApplicationUser> _userManager;
        private readonly RoleManager<IdentityRole> _roleManager;
        private readonly IConfiguration _configuration;

        public AuthenticateController(UserManager<ApplicationUser> userManager,
                RoleManager<IdentityRole> roleManager, IConfiguration configuration)
        {
            _userManager = userManager;
            _roleManager = roleManager;
            _configuration = configuration;
        }


        [HttpPost]
        [Route("regester")]
        public async Task<IActionResult> Register([FromBody] RegisterViewModel registerModel)
        {
            var userExists = await _userManager.FindByNameAsync(registerModel.Username);
            if (userExists != null) return StatusCode(StatusCodes.Status500InternalServerError,
                new Response { Status="Error", Message ="User alredy exists" });

            ApplicationUser user = new()
            {
                Email = registerModel.Email,
                SecurityStamp = Guid.NewGuid().ToString(),
                UserName = registerModel.Username
            };

            var result = await _userManager.CreateAsync(user, registerModel.Password);
            if (!result.Succeeded) return StatusCode(StatusCodes.Status500InternalServerError,
                new  Response { Status = "Error", Message = "User creation failed! Please check user details & try again."});

            return Ok(new Response { Status = "Error", Message = "User created successfully!" });

        }


        [HttpPost]
        [Route("regester-admin")]
        public async Task<IActionResult> RegisterAdmin([FromBody] RegisterViewModel registerModel)
        {
            var userExists = await _userManager.FindByNameAsync(registerModel.Username);
            if (userExists != null) return StatusCode(StatusCodes.Status500InternalServerError,
                new Response { Status = "Error", Message = "User alredy exists" });

            ApplicationUser user = new()
            {
                Email = registerModel.Email,
                SecurityStamp = Guid.NewGuid().ToString(),
                UserName = registerModel.Username
            };

            var result = await _userManager.CreateAsync(user, registerModel.Password);
            if (!result.Succeeded) return StatusCode(StatusCodes.Status500InternalServerError,
                new Response { Status = "Error", Message = "User creation failed! Please check user details & try again." });

            if (!await _roleManager.RoleExistsAsync(UserRoleViewModel.Admin))
                await _roleManager.CreateAsync(new IdentityRole(UserRoleViewModel.Admin));

            if (!await _roleManager.RoleExistsAsync(UserRoleViewModel.User))
                await _roleManager.CreateAsync(new IdentityRole(UserRoleViewModel.User));

            if (!await _roleManager.RoleExistsAsync(UserRoleViewModel.Admin))
                await _userManager.AddToRoleAsync(user, UserRoleViewModel.Admin);

            return Ok(new Response { Status = "Success", Message = "User created successfully!" });
        }

        [HttpPost]
        [Route("login")]
        public async Task<IActionResult> Login([FromBody] LoginViewModel loginModel)
        {
            var user = await _userManager.FindByNameAsync(loginModel.Username);
            if (user !=null  && await _userManager.CheckPasswordAsync(user, loginModel.Password))
            {
                var userRoles = await _userManager.GetRolesAsync(user);

                var authClaims = new List<Claim>
                {
                    new Claim(ClaimTypes.Name, user.UserName),
                    new Claim(JwtRegisteredClaimNames.Jti, Guid.NewGuid().ToString())
                };

                foreach (var userRole in userRoles)
                {
                    authClaims.Add(new Claim(ClaimTypes.Role, userRole));
                }

                var authSigningKey = new SymmetricSecurityKey(Encoding.UTF8.GetBytes(_configuration["JWT:SecretKey"]));

                    var token = new JwtSecurityToken(
                    issuer: _configuration["JWT:ValidIssuer"],
                    audience: _configuration["JWT:ValidAudience"],
                    expires: DateTime.Now.AddHours(3),
                    claims: authClaims,
                    signingCredentials: new SigningCredentials(authSigningKey, SecurityAlgorithms.HmacSha256)
               );

                return Ok(new { token = new JwtSecurityTokenHandler().WriteToken(token), expiration = token.ValidTo });
            }

            return Unauthorized();
        }


    }
}
