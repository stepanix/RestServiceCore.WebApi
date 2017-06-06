using AutoMapper;
using RestServiceCore.Domain.Models;
using RestServiceCore.WebApi.Dto.Contacts.Dto.In;
using RestServiceCore.WebApi.Dto.Positions.In;
using RestServiceCore.WebApi.Dto.Tags.In;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace RestServiceCore.WebApi
{
    public class DtoMapperProfile : Profile
    {
        public DtoMapperProfile()
        {
            CreateMap<TagModel, TagDtoIn>().ReverseMap();
            CreateMap<PositionModel, PositionDtoIn>().ReverseMap();
            CreateMap<ContactModel, ContactDtoIn>().ReverseMap();
        }
    }
}
