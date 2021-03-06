﻿
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using RestServiceCore.Service.Services;
using AutoMapper;
using RestServiceCore.WebApi.Dto.Contacts.Dto.In;
using RestServiceCore.Domain.Models;
using System;

// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace RestServiceCore.WebApi.Controllers
{
    [Route("api/contact")]
    public class ContactController : Controller
    {
        IContactService contactService;
        IMapper mapper;

        public ContactController(IMapper mapper, IContactService contactService)
        {
            this.contactService = contactService;
            this.mapper = mapper;
        }

        [HttpGet("{id:int}")]
        [Route("byid")]
        public async Task<ObjectResult> Read(int id)
        {
            var created = await contactService.GetContactAsync(id);
            return Ok(created);
        }

        [HttpGet("{id:int}")]
        [Route("bytag")]
        public async Task<ObjectResult> ReadContactMembersByTag(int tagId)
        {
            var created = await contactService.GetContactsAsync(tagId);
            return Ok(created);
        }

        [HttpGet("{id:int}")]
        [Route("byposition")]
        public async Task<ObjectResult> ReadContactMembersByPosition(int id)
        {
            var created = await contactService.GetContactsByPositionAsync(id);
            return Ok(created);
        }

        [HttpGet("id")]
        [Route("search")]
        public async Task<ObjectResult> SearchContact(string searchVar)
        {
            var created = await contactService.SearchContactsDynamicallyAsync(searchVar);
            return Ok(created);
        }

        [HttpGet]
        public async Task<ObjectResult> ReadAll()
        {
            var created = await contactService.GetContactsAsync();
            return Ok(created);
        }

        [HttpPost]
        public async Task<ObjectResult> Post([FromBody]ContactDtoIn contact)
        {
            var created = await contactService.InsertContactAsync(mapper.Map<ContactModel>(contact));
            return Ok(created);
        }

        [HttpPut]
        public async Task<ObjectResult> Put([FromBody]ContactDtoIn contact)
        {
            var created = await contactService.UpdateContactAsync(mapper.Map<ContactModel>(contact));
            return Ok(created);
        }
    }
}
