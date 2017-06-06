
using System.Collections.Generic;

using Microsoft.AspNetCore.Mvc;
using RestServiceCore.Service.Services.ContactMembers;
using AutoMapper;
using System.Threading.Tasks;
using RestServiceCore.WebApi.Dto.ContactMembers.Dto.In;
using RestServiceCore.Domain.Models;

// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace RestServiceCore.WebApi.Controllers
{
    [Route("api/contactmember")]
    public class ContactMemberController : Controller
    {
        IContactMemberService ContactMemberService;
        IMapper mapper;

        public ContactMemberController(IMapper mapper, IContactMemberService ContactMemberService)
        {
            this.ContactMemberService = ContactMemberService;
            this.mapper = mapper;
        }

        [HttpGet("{id:int}")]
        public async Task<ObjectResult> Read(int id)
        {
            var created = await ContactMemberService.GetContactMemberAsync(id);
            return Ok(created);
        }

        [HttpGet]
        public async Task<ObjectResult> ReadAll()
        {
            var created = await ContactMemberService.GetContactMembersAsync();
            return Ok(created);
        }

        [HttpPost]
        public async Task<ObjectResult> Post([FromBody]ContactMemberDtoIn ContactMember)
        {
            var created = await ContactMemberService.InsertContactMemberAsync(mapper.Map<ContactMemberModel>(ContactMember));
            return Ok(created);
        }

        [HttpPut]
        public async Task<ObjectResult> Put([FromBody]ContactMemberDtoIn ContactMember)
        {
            var created = await ContactMemberService.UpdateContactMemberAsync(mapper.Map<ContactMemberModel>(ContactMember));
            return Ok(created);
        }
    }
}
