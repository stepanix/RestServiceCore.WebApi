using RestServiceCore.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace RestServiceCore.Domain.Repositories
{
    public interface IContactRepository : IBaseRepository<Contact>
    {
        Task<IEnumerable<Contact>> SearchContacts(string search);
        Task<IEnumerable<Contact>> GetContacts();
        Task<IEnumerable<Contact>> GetContactsByPosition(int poistionId);
        Task<Contact> GetContact(int id);
        Task<Contact> InsertContact(Contact contact);
        Task<Contact> UpdateContact(Contact contact);
        void DeleteContact(int id);
    }
}
