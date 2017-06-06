using Microsoft.EntityFrameworkCore;
using RestServiceCore.Domain.Entities;
using RestServiceCore.Domain.Repositories;
using RestServiceCore.EntityFrameWork.Repositories.Base;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;


namespace RestServiceCore.EntityFrameWork.Repositories
{
    public class ContactRepository : ORMBaseRepository<Contact, int>, IContactRepository
    {
        DataContext context;

        public ContactRepository(DataContext context) : base(context)
        {
            this.context = context;
        }

        public void DeleteContact(int id)
        {
            throw new NotImplementedException();
        }

        public async Task<Contact> GetContact(int id)
        {
            return await context.Contacts
                .Include(p => p.Position)
                .Include(tg => tg.Tags)
                .FirstOrDefaultAsync(uid => uid.Id==id);
        }

        public async Task<IEnumerable<Contact>> GetContacts()
        {
            return await context.Contacts
                .Include(p => p.Position)
                .Include(tg => tg.Tags)
                .ToListAsync();
        }

        public Task<Contact> InsertContact(Contact contact)
        {
            throw new NotImplementedException();
        }

        public Task<Contact> UpdateContact(Contact contact)
        {
            throw new NotImplementedException();
        }
    }
}
