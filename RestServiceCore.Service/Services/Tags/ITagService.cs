using RestServiceCore.Domain.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace RestServiceCore.Service.Services.Tags
{
    public interface ITagService
    {
        Task<IEnumerable<TagModel>> GetTagsAsync();
        Task<TagModel> GetTagAsync(int id);
        Task<TagModel> InsertTagAsync(TagModel contact);
        Task<TagModel> UpdateTagAsync(TagModel contact);
        void DeleteTag(int id);
    }
}
