using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.Logging;
using Microsoft.IdentityModel.Tokens;
using System;
using System.Collections.Generic;
using System.IdentityModel.Tokens.Jwt;
using System.Linq;
using System.Security.Claims;
using System.Text;
using System.Threading.Tasks;
using Tumble.Core.Services.Interface.Account;
using Tumble.DTO.Entity;
using Tumble.DTO.Enum;
using Tumble.DTO.Model.Account;


namespace Tumble.Api.Controllers
{
    [AllowAnonymous]
    [ApiController]
    [Route("api/[controller]/")]
    public class AccountController : ControllerBase
    {

        private readonly ILogger<AccountController> _logger;
        private readonly IConfiguration _configuration;
        private readonly IRegistrationService _registrationService;
        private readonly IUserService _userService;
        private readonly IAuthenticationService _authenticationService;

        public AccountController(ILogger<AccountController> logger,
            IConfiguration configuration,
            IRegistrationService registrationService,
            IUserService userService,
            IAuthenticationService authenticationService)
        {
            _logger = logger;
            _configuration = configuration;
            _registrationService = registrationService;
            _userService = userService;
            _authenticationService = authenticationService;
        }

        [HttpPost]
        [Route("register")]
        public async Task<IActionResult> CreateUser([FromBody] RegistrationModel tumbleUser)
        {
            _logger.LogInformation("Create User Controller call");
            try
            {
                var isExistingUser = await _userService.GetUserByEmail(tumbleUser.Email);
                if (isExistingUser == null)
                {
                    var result = await _registrationService.CreateUser(tumbleUser);
                    result.Token = CreateAuthnenticationToken(result.UserId);
                    return Ok(result);
                }
                else
                {
                    return StatusCode(409, "Emailid already exists");
                }
            }
            catch (Exception ex)
            {
                return StatusCode(500, ex.Message);
            }
        }

        [HttpPost]
        [Route("login")]
        public async Task<IActionResult> Login([FromBody] AuthenticationModel loginDetails)
        {
            _logger.LogInformation("Login Controller call");
            try
            {
                var user = await _authenticationService.AuthenticateUser(loginDetails);
                return Ok(CreateAuthnenticationToken(user.UserId));
            }
            catch (Exception ex)
            {
                return StatusCode((int)LogEvents.Error, ex.Message);
            }
        }

        private string CreateAuthnenticationToken(int userId)
        {
            try
            {
               
                var tokenHandler = new JwtSecurityTokenHandler();
                var key = Encoding.ASCII.GetBytes(_configuration["TokenEncryptionkey"]);
                var tokenDescriptor = new SecurityTokenDescriptor
                {
                    Subject = new ClaimsIdentity(new Claim[]
                    {
                    new Claim(ClaimTypes.Name, userId.ToString())
                    }),
                    Expires = DateTime.UtcNow.AddDays(7),
                    SigningCredentials = new SigningCredentials(new SymmetricSecurityKey(key), SecurityAlgorithms.HmacSha256Signature)
                };
                var token = tokenHandler.CreateToken(tokenDescriptor);
                return tokenHandler.WriteToken(token);
            }
            catch (Exception ex)
            {
                _logger.LogError((int)LogEvents.Error, exception: ex, "CreateAuthnenticationToken");
                throw ex;
            }
        }
    }
}
