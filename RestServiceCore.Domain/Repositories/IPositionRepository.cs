using RestServiceCore.Domain.Entities;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace RestServiceCore.Domain.Repositories
{
    public interface IPositionRepository : IBaseRepository<Position>
    {
        Task<IEnumerable<Position>> SearchPositions(string search);
        Task<IEnumerable<Position>> GetPositions();
        Task<Position> GetPosition(int id);
        Task<Position> InsertPosition(Position position);
        Task<Position> UpdatePosition(Position position);
        void DeletePosition(int id);
    }
}
