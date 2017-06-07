using RestServiceCore.Domain.Models;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace RestServiceCore.Service.Services.ContactMembers
{
    public interface IContactMemberService
    {
        Task<IEnumerable<ContactMemberModel>> GetContactMembersAsync();
        Task<ContactMemberModel> GetContactMemberAsync(int id);
        Task<IEnumerable<ContactMemberModel>> GetContactMembersByTagAsync(int tagId);
        Task<ContactMemberModel> InsertContactMemberAsync(ContactMemberModel ContactMember);
        Task<ContactMemberModel> UpdateContactMemberAsync(ContactMemberModel ContactMember);
        void DeleteContactMember(int id);
    }
}
