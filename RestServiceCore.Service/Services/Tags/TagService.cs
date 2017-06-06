using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using RestServiceCore.Domain.Models;
using RestServiceCore.Domain.Repositories;
using AutoMapper;

namespace RestServiceCore.Service.Services.Tags
{
    public class TagService : ITagService
    {
        ITagRepository tagRepository;
        IMapper mapper;

        public TagService(IMapper mapper, ITagRepository tagRepository)
        {
            this.mapper = mapper;
            this.tagRepository = tagRepository;
        }

        public void DeleteTag(int id)
        {
            throw new NotImplementedException();
        }

        public Task<TagModel> GetTagAsync(int id)
        {
            throw new NotImplementedException();
        }

        public async Task<IEnumerable<TagModel>> GetTagsAsync()
        {
            return mapper.Map<IEnumerable<TagModel>>(await tagRepository.GetAllAsync());
        }

        public Task<TagModel> InsertTagAsync(TagModel contact)
        {
            throw new NotImplementedException();
        }

        public Task<TagModel> UpdateTagAsync(TagModel contact)
        {
            throw new NotImplementedException();
        }
    }
}
