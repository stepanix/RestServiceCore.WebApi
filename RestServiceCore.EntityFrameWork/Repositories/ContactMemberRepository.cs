using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using RestServiceCore.Domain.Entities;
using RestServiceCore.Domain.Repositories;
using RestServiceCore.EntityFrameWork.Repositories.Base;
using System.Linq;
using Microsoft.EntityFrameworkCore;

namespace RestServiceCore.EntityFrameWork.Repositories
{
    public class ContactMemberRepository : ORMBaseRepository<ContactMember, int>, IContactMemberRepository
    {
        DataContext context;
        public ContactMemberRepository(DataContext context) : base(context)
        {
            this.context = context;
        }

        public void DeleteContactMember(int id)
        {
            throw new NotImplementedException();
        }
       

        public Task<IEnumerable<ContactMember>> GetContactMembers()
        {
            throw new NotImplementedException();
        }

        public async Task<IEnumerable<ContactMember>> GetContactMembers(int contactId)
        {
            return await context.ContactMembers
                .Where(cid => cid.ContactId == contactId)
                .Include(tg=>tg.Tag)
                .ToListAsync();
        }

        public async Task<IEnumerable<ContactMember>> GetContactMembersByTag(int tagId)
        {
            return await context.ContactMembers
                .Where(cid => cid.TagId == tagId)                
                .Include(ct => ct.Contact)
                .Include(ct => ct.Contact.Position)
                .Include(ct => ct.Tag)
                .ToListAsync();
        }

        public Task<ContactMember> InsertContactMember(ContactMember ContactMember)
        {
            throw new NotImplementedException();
        }

        public Task<ContactMember> UpdateContactMember(ContactMember ContactMember)
        {
            throw new NotImplementedException();
        }

        

        Task<ContactMember> IContactMemberRepository.GetContactMember(int id)
        {
            throw new NotImplementedException();
        }
    }
}
