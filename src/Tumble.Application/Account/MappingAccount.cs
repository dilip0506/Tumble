using AutoMapper;
using Tumble.Domain.Entity;
using Tumble.Domain.Model.Account;

namespace Tumble.Application.Account
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
