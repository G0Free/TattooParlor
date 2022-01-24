using AutoMapper;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using TattooParlor.Models;
using TattooParlor.Models.DTO;

namespace TattooParlor.Endpoint.Profiles
{
    public class TattooProfile : Profile
    {
        public TattooProfile()
        {
            CreateMap<TattooDto, Tattoo>()
                .ForMember(
                dest => dest.TattooId,
                opt => opt.MapFrom(src => src.TattooId))
                .ForMember(
                dest => dest.FantasyName,
                opt => opt.MapFrom(src => src.FantasyName))
                .ForMember(
                dest => dest.jobsDoneId,
                opt => opt.MapFrom(src => src.jobsDoneId))
                .ForMember(
                dest => dest.IsDeleted,
                opt => opt.MapFrom(src => src.IsDeleted));
        }
    }
}
