using AutoMapper;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using TattooParlor.Models;
using TattooParlor.Models.DTO;

namespace TattooParlor.Endpoint.Profiles
{
    public class JobsDoneProfile : Profile
    {
        public JobsDoneProfile()
        {
            CreateMap<JobsDoneDto, JobsDone>()
                .ForMember(
                dest => dest.JobsDoneId,
                opt => opt.MapFrom(src => src.JobsDoneId))
                .ForMember(
                dest => dest.customerId,
                opt => opt.MapFrom(src => src.customerId))
                .ForMember(
                dest => dest.TattooId,
                opt => opt.MapFrom(src => src.TattooId))
                .ForMember(
                dest => dest.jobDate,
                opt => opt.MapFrom(src => src.jobDate))
                .ForMember(
                dest => dest.Cost,
                opt => opt.MapFrom(src => src.Cost))
                .ForMember(
                dest => dest.IsDeleted,
                opt => opt.MapFrom(src => src.IsDeleted)
                );
        }
    }
}
