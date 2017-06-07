using Microsoft.EntityFrameworkCore;
using RestServiceCore.Domain.Entities;
using RestServiceCore.Domain.Repositories;
using RestServiceCore.EntityFrameWork.Repositories.Base;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using System.Linq;
namespace RestServiceCore.EntityFrameWork.Repositories
{
    public class PositionRepository : ORMBaseRepository<Position, int>, IPositionRepository
    {
        DataContext context;
        public PositionRepository(DataContext context) : base(context)
        {
            this.context = context;
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

        public async Task<IEnumerable<Position>> SearchPositions(string search)
        {
            return await context.Positions
                 .Where(nm => nm.Description.ToLower().Contains(search)).ToListAsync();

        }

        public Task<Position> UpdatePosition(Position position)
        {
            throw new NotImplementedException();
        }
    }
}
