using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using RestServiceCore.Domain.Models;
using RestServiceCore.Domain.Repositories;
using AutoMapper;
using RestServiceCore.Domain.Entities;

namespace RestServiceCore.Service.Services.Positions
{
    public class PositionService : IPositionService
    {
        IPositionRepository positionRepository;
        IMapper mapper;

        public PositionService(IMapper mapper, IPositionRepository positionRepository)
        {
            this.mapper = mapper;
            this.positionRepository = positionRepository;
        }


        public void DeletePosition(int id)
        {
            throw new NotImplementedException();
        }

        public async Task<PositionModel> GetPositionAsync(int id)
        {
            return mapper.Map<PositionModel>(await positionRepository.GetAsync(id));
        }

        public async Task<IEnumerable<PositionModel>> GetPositionsAsync()
        {
            return mapper.Map<IEnumerable<PositionModel>>(await positionRepository.GetAllAsync());
        }

        public async Task<PositionModel> InsertPositionAsync(PositionModel position)
        {
            var newPosition = await positionRepository.InsertAsync(mapper.Map<Position>(position));
            await positionRepository.SaveChangesAsync();
            return mapper.Map<PositionModel>(newPosition);
        }

        public async Task<PositionModel> UpdatePositionAsync(PositionModel position)
        {
            var positionForUpdate = await positionRepository.GetAsync(position.Id);
            positionForUpdate.ModifiedDate = DateTime.Now;
            positionForUpdate.Description = position.Description;
            await positionRepository.SaveChangesAsync();
            return mapper.Map<PositionModel>(positionForUpdate);
        }
    }
}
