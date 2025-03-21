using AutoMapper;
using System;
using System.Collections.Generic;
using System.Text;
using Tumble.DTO.Entity;
using Tumble.DTO.Model.Account;

namespace Tumble.Services.Account
{
    class MappingAccount : Profile {
        public MappingAccount()
        {
            CreateMap<RegistrationModel, TumbleUser>();
            CreateMap<AddressModel, Address>();
        }
    }
}
