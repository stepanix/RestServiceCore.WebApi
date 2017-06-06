using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using RestServiceCore.Domain.Models;
using AutoMapper;
using RestServiceCore.Domain.Repositories;
using RestServiceCore.Domain.Entities;

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

        public async Task<ContactModel> GetContactAsync(int id)
        {
            return mapper.Map<ContactModel>(await contactRepository.GetContact(id));
        }

        public async Task<IEnumerable<ContactModel>> GetContactsAsync()
        {
            return mapper.Map<IEnumerable<ContactModel>>(await contactRepository.GetContacts());
        }

        public  async Task<ContactModel> InsertContactAsync(ContactModel contact)
        {
            var newContact = await contactRepository.InsertAsync(mapper.Map<Contact>(contact));
            await contactRepository.SaveChangesAsync();
            return mapper.Map<ContactModel>(newContact);
        }

        public async Task<ContactModel> UpdateContactAsync(ContactModel contact)
        {
            var contactForUpdate = await contactRepository.GetAsync(contact.Id);
            contactForUpdate.ModifiedDate = DateTime.Now;
            contactForUpdate.PositionId = contact.PositionId;
            contactForUpdate.Surname = contact.Surname;
            contactForUpdate.FirstName = contact.FirstName;
            await contactRepository.SaveChangesAsync();
            return mapper.Map<ContactModel>(contactForUpdate);
        }
    }
}
