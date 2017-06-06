using RestServiceCore.Domain.Models;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace RestServiceCore.Service.Services.Positions
{
    public interface IPositionService
    {
        Task<IEnumerable<PositionModel>> GetPositionsAsync();
        Task<PositionModel> GetPositionAsync(int id);
        Task<PositionModel> InsertPositionAsync(PositionModel position);
        Task<PositionModel> UpdatePositionAsync(PositionModel position);
        void DeletePosition(int id);
    }
}
