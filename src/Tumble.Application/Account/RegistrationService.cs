using AutoMapper;
using Microsoft.Extensions.Logging;
using System;
using System.Security.Cryptography;
using System.Text;
using System.Threading.Tasks;
using Tumble.Domain.Entity;
using Tumble.Domain.Model.Email;
using Tumble.User.Application.Helper;
using Tumble.User.Domain.DataAccess.Interface.Account;
using Tumble.User.Domain.Entity;
using Tumble.User.Domain.Enum;
using Tumble.User.Domain.Enum.Account;
using Tumble.User.Domain.Model.Account;
using Tumble.User.Domain.Services.Interface.Account;
using Tumble.User.Domain.Services.Interface.Email;

namespace Tumble.User.Application.Account
{
    class RegistrationService : IRegistrationService
    {
        private readonly ILogger<RegistrationService> _logger;
        private readonly IDARegistrartion _daRegistrartion;
        private readonly IMapper _mapper;
        private readonly ISendEmail _sendEmail;


        public RegistrationService(ILogger<RegistrationService> logger,
            IDARegistrartion daRegistrartion,
            IMapper mapper,
            ISendEmail sendEmail)
        {
            _logger = logger;
            _daRegistrartion = daRegistrartion;
            _mapper = mapper;
            _sendEmail = sendEmail;
        }
        public async Task<UserRegistrationResponse> CreateUser(RegistrationModel tumbleUser)
        {
            _logger.LogInformation("CreateUser");
            try
            {
                using var txScope = TransactionScopeAsync.CreateAsyncTransactionScope();
                var userDetails = _mapper.Map<TumbleUser>(tumbleUser);

                userDetails.AddressId = await _daRegistrartion.InsertAddress(userDetails.Address); ;

                CreatePasswordHash(tumbleUser.Password, out byte[] passwordHash, out byte[] passwordSalt);

                userDetails.PasswordHash = Convert.ToBase64String(passwordHash);
                userDetails.PasswordSalt = Convert.ToBase64String(passwordSalt);

                int userId = await _daRegistrartion.InsertUser(userDetails);

                int registrationCode = GenerateRegistrationPin();

                _ = await _daRegistrartion.InsertRegistrationPin(new UserRegistrationVerification()
                {
                    UserId = userId,
                    StatusCode = UserRegistrationStatusCode.RegistrationPending,
                    VerficationCode = registrationCode
                });

                txScope.Complete();

                await _sendEmail.SendEmailAsync(new EmailRequest
                {
                    ToEmail = userDetails.Email,
                    ToName = userDetails.FirstName,
                    Subject = "Welcome to tumble",
                    Body = $"Your Pin is {registrationCode}"
                });

                return new UserRegistrationResponse
                {
                    UserId = userId,
                    RegistrationStutus = UserRegistrationStatusCode.RegistrationPending
                };
            }
            catch (Exception ex)
            {
                _logger.LogError((int)LogEvents.Error, exception: ex, "CreateUser");
                throw;
            }
        }

        private static void CreatePasswordHash(string password, out byte[] passwordHash, out byte[] passwordSalt)
        {
            using var hmac = new HMACSHA512();
            passwordSalt = hmac.Key;
            passwordHash = hmac.ComputeHash(Encoding.UTF8.GetBytes(password));
        }

        private static int GenerateRegistrationPin()
        {
            Random random = new Random();
            return random.Next(100000, 999999);
        }
    }
}
