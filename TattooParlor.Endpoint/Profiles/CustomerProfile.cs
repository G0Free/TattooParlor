using AutoMapper;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using TattooParlor.Models;
using TattooParlor.Models.DTO;

namespace TattooParlor.Endpoint.Profiles
{
    public class CustomerProfile : Profile
    {
        public CustomerProfile()
        {
            CreateMap<CustomerDto, Customer>()
                .ForMember(
                dest => dest.CustomerId,
                opt => opt.MapFrom(src => src.CustomerId))
                .ForMember(
                dest => dest.FirstName,
                opt => opt.MapFrom(src =>src.FirstName))
                .ForMember(
                dest => dest.LastName,
                opt => opt.MapFrom(src => src.LastName))
                .ForMember(
                dest => dest.Email,
                opt => opt.MapFrom(src => src.Email))
                .ForMember(
                dest => dest.BirthYear,
                opt => opt.MapFrom(src => src.BirthYear))
                .ForMember(
                dest => dest.JobsDoneId,
                opt => opt.MapFrom(src => src.JobsDoneId))
                .ForMember(
                dest => dest.IsDeleted,
                opt => opt.MapFrom(src => src.IsDeleted)
                );
        }
    }
}
