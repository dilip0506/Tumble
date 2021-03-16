using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;
using Tumble.Core.DataAccess.Interface.Account;
using Tumble.Core.Services.Interface.Account;
using Tumble.DTO.Entity;
using Tumble.DTO.Model.Account;
using System.Security.Cryptography;
using Tumble.Services.CustomException;
using Microsoft.Extensions.Logging;
using Tumble.DTO.Enum;

namespace Tumble.Services.Account
{
    class AuthenticationService : IAuthenticationService
    {
        private readonly ILogger<AuthenticationService> _logger;
        private readonly IUserService _userService;

        public AuthenticationService(ILogger<AuthenticationService> logger,
            IUserService userService)
        {
            _logger = logger;
            _userService = userService;
        }
        public async Task<TumbleUser> AuthenticateUser(AuthenticationModel loginDetails)
        {

            try
            {
                var user = await _userService.GetUserByEmail(loginDetails.Email);

                if (user == null)
                    throw new UserNotFoundException("The Email address does not exists");

                if (!VerifyPasswordHash(loginDetails.Password, Convert.FromBase64String(user.PasswordHash), Convert.FromBase64String(user.PasswordSalt)))
                    throw new InvalidPassword("You have entered incorrect password");

                return user;
            }
            catch (Exception ex) {
                _logger.LogError((int)LogEvents.Error,exception: ex, "AuthenticateUser");
                throw ex;
            }
        }



        private static bool VerifyPasswordHash(string password, byte[] storedHash, byte[] storedSalt)
        {
            if (storedHash.Length != 64) throw new ArgumentException("Invalid length of password hash (64 bytes expected).", "passwordHash");
            if (storedSalt.Length != 128) throw new ArgumentException("Invalid length of password salt (128 bytes expected).", "passwordHash");

            using (var hmac = new HMACSHA512(storedSalt))
            {
                var computedHash = hmac.ComputeHash(Encoding.UTF8.GetBytes(password));
                for (int i = 0; i < computedHash.Length; i++)
                {
                    if (computedHash[i] != storedHash[i]) return false;
                }
            }

            return true;
        }
    }
}
