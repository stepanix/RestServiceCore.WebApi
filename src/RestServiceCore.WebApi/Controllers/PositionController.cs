using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using RestServiceCore.Service.Services.Positions;
using AutoMapper;
using RestServiceCore.WebApi.Dto.Positions.In;
using RestServiceCore.Domain.Models;

// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace RestServiceCore.WebApi.Controllers
{
    [Route("api/position")]
    public class PositionController : Controller
    {
        IPositionService positionService;
        IMapper mapper;

        public PositionController(IMapper mapper, IPositionService positionService)
        {
            this.positionService = positionService;
            this.mapper = mapper;
        }

        [HttpGet("{id:int}")]
        public async Task<ObjectResult> Read(int id)
        {
            var created = await positionService.GetPositionAsync(id);
            return Ok(created);
        }

        [HttpGet]
        public async Task<ObjectResult> ReadAll()
        {
            var created = await positionService.GetPositionsAsync();
            return Ok(created);
        }

        [HttpPost]
        public async Task<ObjectResult> Post([FromBody]PositionDtoIn position)
        {
            var created = await positionService.InsertPositionAsync(mapper.Map<PositionModel>(position));
            return Ok(created);
        }

        [HttpPut]
        public async Task<ObjectResult> Put([FromBody]PositionDtoIn position)
        {
            var created = await positionService.UpdatePositionAsync(mapper.Map<PositionModel>(position));
            return Ok(created);
        }

    }
}
