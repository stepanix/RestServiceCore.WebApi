﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using RestServiceCore.WebApi.Controllers.Base;
using RestServiceCore.Service.Services.Tags;
using AutoMapper;
using RestServiceCore.Domain.Models;


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

        [HttpGet]
        public async Task<IEnumerable<TagModel>> ReadAll()
        {
            var created = await tagService.GetTagsAsync();
            return created;
        }
    }
}
