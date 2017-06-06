using RestServiceCore.Domain.Entities;
using RestServiceCore.Domain.Repositories;
using RestServiceCore.EntityFrameWork.Repositories.Base;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace RestServiceCore.EntityFrameWork.Repositories
{
    public class TagRepository : ORMBaseRepository<Tag, int>, ITagRepository
    {
        public TagRepository(DataContext context) : base(context)
        {
        }

        public void DeleteTag(int id)
        {
            throw new NotImplementedException();
        }

        public Task<Contact> GetTag(int id)
        {
            throw new NotImplementedException();
        }

        public Task<IEnumerable<Tag>> GetTags()
        {
            throw new NotImplementedException();
        }

        public Task<Tag> InsertTag(Tag tag)
        {
            throw new NotImplementedException();
        }

        public Task<Tag> UpdateTag(Tag tag)
        {
            throw new NotImplementedException();
        }
    }
}
