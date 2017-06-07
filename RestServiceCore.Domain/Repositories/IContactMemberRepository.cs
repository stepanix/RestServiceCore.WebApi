using RestServiceCore.Domain.Entities;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace RestServiceCore.Domain.Repositories
{
    public interface IContactMemberRepository : IBaseRepository<ContactMember>
    {
        Task<IEnumerable<ContactMember>> GetContactMembers();
        Task<IEnumerable<ContactMember>> GetContactMembers(int contactId);
        Task<IEnumerable<ContactMember>> GetContactMembersByTag(int tagId);
        Task<ContactMember> GetContactMember(int id);
        Task<ContactMember> InsertContactMember(ContactMember ContactMember);
        Task<ContactMember> UpdateContactMember(ContactMember ContactMember);
        void DeleteContactMember(int id);
    }
}
