using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;
using RestServiceCore.Domain.Models;
using RestServiceCore.Domain.Repositories;
using AutoMapper;
using RestServiceCore.Domain.Entities;

namespace RestServiceCore.Service.Services.ContactMembers
{
    public class ContactMemberService : IContactMemberService
    {

        IContactMemberRepository ContactMemberRepository;
        IMapper mapper;

        public ContactMemberService(IMapper mapper, IContactMemberRepository ContactMemberRepository)
        {
            this.mapper = mapper;
            this.ContactMemberRepository = ContactMemberRepository;
        }

        public void DeleteContactMember(int id)
        {
            throw new NotImplementedException();
        }

        public async Task<ContactMemberModel> GetContactMemberAsync(int id)
        {
            return mapper.Map<ContactMemberModel>(await ContactMemberRepository.GetAsync(id));
        }

        public async Task<IEnumerable<ContactMemberModel>> GetContactMembersAsync()
        {
            List<ContactModel> newContactList = new List<ContactModel>();
            var contacts = await ContactMemberRepository.GetAllAsync();
            foreach(var contact in contacts) { 
}

            return mapper.Map<IEnumerable<ContactMemberModel>>(await ContactMemberRepository.GetAllAsync());
        }

        public async Task<ContactMemberModel> InsertContactMemberAsync(ContactMemberModel ContactMember)
        {
            var newContactMember = await ContactMemberRepository.InsertAsync(mapper.Map<ContactMember>(ContactMember));
            await ContactMemberRepository.SaveChangesAsync();
            return mapper.Map<ContactMemberModel>(newContactMember);
        }

        public async Task<ContactMemberModel> UpdateContactMemberAsync(ContactMemberModel ContactMember)
        {
            var ContactMemberForUpdate = await ContactMemberRepository.GetAsync(ContactMember.Id);
            ContactMemberForUpdate.ModifiedDate = DateTime.Now;
            ContactMemberForUpdate.ContactId = ContactMember.ContactId;
            ContactMemberForUpdate.TagId = ContactMember.TagId;
            await ContactMemberRepository.SaveChangesAsync();
            return mapper.Map<ContactMemberModel>(ContactMemberForUpdate);
        }
    }
}
