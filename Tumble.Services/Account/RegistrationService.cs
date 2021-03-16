using System;
using Microsoft.Extensions.Logging;
using System.Collections.Generic;
using System.Text;
using Tumble.Core.Services.Interface.Account;
using System.Threading.Tasks;
using Tumble.Core.DataAccess.Interface.Account;
using Tumble.DTO.Model.Account;
using Tumble.DTO.Entity;
using AutoMapper;
using Tumble.DTO.Enum.Account;
using Tumble.Core.Services.Interface.Email;
using Tumble.DTO.Model.Email;
using System.Security.Cryptography;
using Tumble.Services.Helper;
using Tumble.DTO.Enum;

namespace Tumble.Services.Account
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
            catch (Exception ex) {
                _logger.LogError((int)LogEvents.Error, exception: ex, "CreateUser");
                throw ex;
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
