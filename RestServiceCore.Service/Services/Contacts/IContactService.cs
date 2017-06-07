using RestServiceCore.Domain.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace RestServiceCore.Service.Services
{
    public interface IContactService
    {
        Task<IEnumerable<SearchModel>> SearchContactsDynamicallyAsync(string search);
        Task<IEnumerable<ContactModel>> GetContactsAsync();
        Task<IEnumerable<ContactModel>> GetContactsByPositionAsync(int positionId);
        Task<IEnumerable<ContactModel>> GetContactsAsync(int tagId);
        Task<ContactModel> GetContactAsync(int id);
        Task<ContactModel> InsertContactAsync(ContactModel contact);
        Task<ContactModel> UpdateContactAsync(ContactModel contact);
        void DeleteContact(int id);
    }
}
