using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using RestServiceCore.Domain.Models;
using RestServiceCore.Domain.Repositories;
using AutoMapper;
using RestServiceCore.Domain.Entities;

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

        public async Task<TagModel> GetTagAsync(int id)
        {
            return mapper.Map<TagModel>(await tagRepository.GetAsync(id));
        }

        public async Task<IEnumerable<TagModel>> GetTagsAsync()
        {
            return mapper.Map<IEnumerable<TagModel>>(await tagRepository.GetAllAsync());
        }

        public async Task<TagModel> InsertTagAsync(TagModel tag)
        {
            var newTag = await tagRepository.InsertAsync(mapper.Map<Tag>(tag));
            await tagRepository.SaveChangesAsync();
            return mapper.Map<TagModel>(newTag);
        }

        public async Task<TagModel> UpdateTagAsync(TagModel tag)
        {
            var tagForUpdate = await tagRepository.GetAsync(tag.Id);
            tagForUpdate.ModifiedDate = DateTime.Now;
            tagForUpdate.Description = tag.Description;
            await tagRepository.SaveChangesAsync();
            return mapper.Map<TagModel>(tagForUpdate);
        }
    }
}
