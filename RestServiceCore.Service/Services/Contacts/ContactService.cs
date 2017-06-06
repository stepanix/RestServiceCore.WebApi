using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using RestServiceCore.Domain.Models;
using AutoMapper;
using RestServiceCore.Domain.Repositories;

namespace RestServiceCore.Service.Services
{
    public class ContactService : IContactService
    {
        IContactRepository contactRepository;
        IMapper mapper;

        public ContactService(IMapper mapper, IContactRepository contactRepository)
        {
            this.mapper = mapper;
            this.contactRepository = contactRepository;
        }

        public void DeleteContact(int id)
        {
            throw new NotImplementedException();
        }

        public Task<ContactModel> GetContactAsync(int id)
        {
            throw new NotImplementedException();
        }

        public async Task<IEnumerable<ContactModel>> GetContactsAsync()
        {
            return mapper.Map<IEnumerable<ContactModel>>(await contactRepository.GetAllAsync());
        }

        public Task<ContactModel> InsertContactAsync(ContactModel contact)
        {
            throw new NotImplementedException();
        }

        public Task<ContactModel> UpdateContactAsync(ContactModel contact)
        {
            throw new NotImplementedException();
        }
    }
}
