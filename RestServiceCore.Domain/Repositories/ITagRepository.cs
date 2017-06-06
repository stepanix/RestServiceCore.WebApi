using RestServiceCore.Domain.Entities;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace RestServiceCore.Domain.Repositories
{
    public interface ITagRepository : IBaseRepository<Tag>
    {
        Task<IEnumerable<Tag>> GetTags();
        Task<Contact> GetTag(int id);
        Task<Tag> InsertTag(Tag tag);
        Task<Tag> UpdateTag(Tag tag);
        void DeleteTag(int id);
    }
}
