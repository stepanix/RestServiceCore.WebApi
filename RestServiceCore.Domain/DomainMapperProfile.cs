using AutoMapper;
using RestServiceCore.Domain.Entities;
using RestServiceCore.Domain.Models;


namespace RestServiceCore.Domain
{
    public class DomainMapperProfile : Profile
    {
        public DomainMapperProfile()
        {
            CreateMap<Contact, ContactModel>().ReverseMap();
            CreateMap<Position, PositionModel>().ReverseMap();
            CreateMap<Tag, TagModel>().ReverseMap();
            CreateMap<ContactMember, ContactMemberModel>().ReverseMap();
        }
    }
}
