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
        IPositionRepository positionRepository;
        IContactMemberRepository contactMemberRepository;
        IMapper mapper;

        public ContactService(IMapper mapper, IPositionRepository positionRepository, IContactRepository contactRepository, IContactMemberRepository contactMemberRepository)
        {
            this.mapper = mapper;
            this.positionRepository = positionRepository;
            this.contactRepository = contactRepository;
            this.contactMemberRepository = contactMemberRepository;
        }

        public void DeleteContact(int id)
        {
            throw new NotImplementedException();
        }

        public async Task<ContactModel> GetContactAsync(int id)
        {
            var contact = mapper.Map<ContactModel>(await contactRepository.GetContact(id));
            contact.Tags = await GetAllContactTags(contact.Id);
            return contact;
        }

        public async Task<IEnumerable<SearchModel>> SearchContactsDynamicallyAsync(string search)
        {
            List<SearchModel> searchModelList = new List<SearchModel>();
            var contacts = mapper.Map<IEnumerable<ContactModel>>(await contactRepository.SearchContacts(search));
            var positions = mapper.Map<IEnumerable<PositionModel>>(await positionRepository.SearchPositions(search));
            foreach (var contact in contacts)
            {
                searchModelList.Add(new SearchModel
                {
                    Id = contact.Id,
                    Description = contact.FirstName + "  " + contact.Surname,
                    SearchType = "contact"
                });
            }
            foreach (var position in positions)
            {
                searchModelList.Add(new SearchModel
                {
                    Id = position.Id,
                    Description = position.Description,
                    SearchType = "position"
                });
            }
            return searchModelList;
        }

        public async Task<IEnumerable<ContactModel>> GetContactsByPositionAsync(int positionId)
        {
            List<ContactModel> newContactList = new List<ContactModel>();
            var contacts = mapper.Map<IEnumerable<ContactModel>>(await contactRepository.GetContactsByPosition(positionId));
            foreach(var contact in contacts)
            {
                newContactList.Add(new ContactModel
                {
                    Id = contact.Id,
                    FirstName = contact.FirstName,
                    Surname = contact.Surname,
                    PositionId = contact.Position.Id,
                    Position = contact.Position,
                    Tags = await GetAllContactTags(contact.Id)
                });
            }
            return newContactList;
        }

        public async Task<IEnumerable<ContactModel>> GetContactsAsync(int tagId)
        {
            List<ContactModel> newContactList = new List<ContactModel>();

            var contactMembers = mapper.Map<IEnumerable<ContactMemberModel>>(await contactMemberRepository.GetContactMembersByTag(tagId));
            foreach (var contactMember in contactMembers)
            {
                //Build Ideal Contact Model
                newContactList.Add(new ContactModel {
                    Id = contactMember.Contact.Id,
                    FirstName = contactMember.Contact.FirstName,
                    Surname = contactMember.Contact.Surname,
                    PositionId = contactMember.Contact.Position.Id,
                    Position = contactMember.Contact.Position,
                    Tags = await GetAllContactTags(contactMember.Contact.Id)
                });
            }
            return newContactList;
        }

        private async Task<List<TagModel>> GetAllContactTags(int contactId)
        {
            List<TagModel> newTagList = new List<TagModel>();
            //Get All Tags for this contact
            var ContactMembers = mapper.Map<IEnumerable<ContactMemberModel>>(await contactMemberRepository.GetContactMembers(contactId));
            foreach (var ContactMember in ContactMembers)
            {
                //Get all other Tags including selected tag for contact
                newTagList.Add(ContactMember.Tag);
            }
            return newTagList;
        }


        public async Task<IEnumerable<ContactModel>> GetContactsAsync()
        {
            List<ContactModel> newContactList = new List<ContactModel>();
            List<TagModel> newTagList = new List<TagModel>();

            var contacts = mapper.Map<IEnumerable<ContactModel>>(await contactRepository.GetContacts());
            foreach (var contact in contacts)
            {
                var ContactMembers = mapper.Map <IEnumerable<ContactMemberModel>>(await contactMemberRepository.GetContactMembers(contact.Id));
                foreach(var ContactMember in ContactMembers)
                {
                    newTagList.Add(ContactMember.Tag);
                }
                contact.Tags = newTagList;
                newContactList.Add(contact);
            }
            return newContactList;
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
