
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using RestServiceCore.Service.Services.Tags;
using AutoMapper;
using RestServiceCore.Domain.Models;
using RestServiceCore.WebApi.Dto.Tags.In;


// For more information on enabling Web API for empty projects, visit http://go.microsoft.com/fwlink/?LinkID=397860

namespace RestServiceCore.WebApi.Controllers
{
    [Route("api/tag")]
    public class TagController : Controller
    {
        ITagService tagService;
        IMapper mapper;
        public TagController(IMapper mapper, ITagService tagService)
        {
            this.tagService = tagService;
            this.mapper = mapper;
        }

        [HttpGet("{id:int}")]
        public async Task<ObjectResult> Read(int id)
        {
            var created = await tagService.GetTagAsync(id);
            return Ok(created);
        }

        [HttpGet]
        public async Task<ObjectResult> ReadAll()
        {
            var created = await tagService.GetTagsAsync();
            return Ok(created);
        }

        [HttpPost]
        public async Task<ObjectResult> Post([FromBody]TagDtoIn tag)
        {
            var created = await tagService.InsertTagAsync(mapper.Map<TagModel>(tag));
            return Ok(created);
        }

        [HttpPut]
        public async Task<ObjectResult> Put([FromBody]TagDtoIn tag)
        {
            var created = await tagService.UpdateTagAsync(mapper.Map<TagModel>(tag));
            return Ok(created);
        }
    }
}
