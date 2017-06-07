using Microsoft.EntityFrameworkCore;
using RestServiceCore.Domain.Entities;
using RestServiceCore.Domain.Repositories;
using RestServiceCore.EntityFrameWork.Repositories.Base;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using System.Linq;



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
                .Where(uid => uid.Id == id)
                .Include(p => p.Position)                
                .FirstOrDefaultAsync();
        }

        public async Task<IEnumerable<Contact>> GetContacts()
        {
            return await context.Contacts
                .Include(p => p.Position)
                .ToListAsync();
        }

        public async Task<IEnumerable<Contact>> GetContactsByPosition(int poistionId)
        {
            return await context.Contacts
                .Where(pid => pid.PositionId== poistionId)
                .Include(p => p.Position)
                .ToListAsync();
        }

        public Task<Contact> InsertContact(Contact contact)
        {
            throw new NotImplementedException();
        }

        public async Task<IEnumerable<Contact>> SearchContacts(string search)
        {
            return await context.Contacts
                .Where(nm => nm.FirstName.ToLower().Contains(search)
                || nm.Surname.ToLower().Contains(search))
                .Include(p => p.Position)
                .ToListAsync();
        }

        public Task<Contact> UpdateContact(Contact contact)
        {
            throw new NotImplementedException();
        }
    }
}
