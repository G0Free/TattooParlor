using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using TattooParlor.Models;
using TattooParlor.Models.DTO;
using AutoMapper;

namespace TattooParlor.Endpoint.Profiles
{
    public class ModelsProfile : Profile
    {
        public ModelsProfile()
        {
            CreateMap<CustomerDto, Customer>();
            CreateMap<Customer, CustomerDto>();

            CreateMap<TattooDto, Tattoo>();
            CreateMap<Tattoo, TattooDto>();

            CreateMap<JobsDoneDto, JobsDone>();
            CreateMap<JobsDone, JobsDoneDto>();
        }
    }
}
