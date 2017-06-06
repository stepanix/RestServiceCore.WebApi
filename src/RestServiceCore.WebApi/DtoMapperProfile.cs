using AutoMapper;
using RestServiceCore.Domain.Models;
using RestServiceCore.WebApi.Dto.Contacts.Dto.In;
using RestServiceCore.WebApi.Dto.ContactMembers.Dto.In;
using RestServiceCore.WebApi.Dto.Positions.In;
using RestServiceCore.WebApi.Dto.Tags.In;

namespace RestServiceCore.WebApi
{
    public class DtoMapperProfile : Profile
    {
        public DtoMapperProfile()
        {
            CreateMap<TagModel, TagDtoIn>().ReverseMap();
            CreateMap<PositionModel, PositionDtoIn>().ReverseMap();
            CreateMap<ContactModel, ContactDtoIn>().ReverseMap();
            CreateMap<ContactMemberModel, ContactMemberDtoIn>().ReverseMap();
        }
    }
}
