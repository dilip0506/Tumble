using AutoMapper;
using Tumble.User.Domain.Entity;
using Tumble.User.Domain.Model.Account;

namespace Tumble.User.Application.Account
{
    class MappingAccount : Profile
    {
        public MappingAccount()
        {
            CreateMap<RegistrationModel, TumbleUser>();
            CreateMap<AddressModel, Address>();
        }
    }
}
