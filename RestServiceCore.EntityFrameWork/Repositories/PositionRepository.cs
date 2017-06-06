using RestServiceCore.Domain.Entities;
using RestServiceCore.Domain.Repositories;
using RestServiceCore.EntityFrameWork.Repositories.Base;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace RestServiceCore.EntityFrameWork.Repositories
{
    public class PositionRepository : ORMBaseRepository<Position, int>, IPositionRepository
    {
        public PositionRepository(DataContext context) : base(context)
        {
        }

        public void DeletePosition(int id)
        {
            throw new NotImplementedException();
        }

        public Task<Position> GetPosition(int id)
        {
            throw new NotImplementedException();
        }

        public Task<IEnumerable<Position>> GetPositions()
        {
            throw new NotImplementedException();
        }

        public Task<Position> InsertPosition(Position position)
        {
            throw new NotImplementedException();
        }

        public Task<Position> UpdatePosition(Position position)
        {
            throw new NotImplementedException();
        }
    }
}
