﻿using System;
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
        IContactMemberRepository contactMemberRepository;
        IMapper mapper;

        public ContactService(IMapper mapper, IContactRepository contactRepository, IContactMemberRepository contactMemberRepository)
        {
            this.mapper = mapper;
            this.contactRepository = contactRepository;
            this.contactMemberRepository = contactMemberRepository;
        }

        public void DeleteContact(int id)
        {
            throw new NotImplementedException();
        }

        public async Task<ContactModel> GetContactAsync(int id)
        {
            return mapper.Map<ContactModel>(await contactRepository.GetContact(id));
        }


        public async Task<IEnumerable<ContactModel>> GetContactsAsync(int tagId)
        {
            List<ContactModel> newContactList = new List<ContactModel>();
            List<TagModel> newTagList = new List<TagModel>();

            var contacts = mapper.Map<IEnumerable<ContactModel>>(await contactRepository.GetContacts());
            foreach (var contact in contacts)
            {
                var ContactMembers = mapper.Map<IEnumerable<ContactMemberModel>>(await contactMemberRepository.GetContactMembers(contact.Id));
                foreach (var ContactMember in ContactMembers)
                {
                    //Get all other ags including selected tag for contact
                    newTagList.Add(ContactMember.Tag);
                }
                contact.Tags = newTagList.Distinct().ToList<TagModel>();
                newContactList.Add(contact);
                //clear list to avoid duplicates
                newTagList.Clear();
            }
            return newContactList;
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
