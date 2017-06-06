using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace RestServiceCore.Domain.Models
{
    public class ContactModel
    {
        public int Id { get; set; }
        public string FirstName { get; set; }
        public string Surname { get; set; }
        public int PositionId { get; set; }
        public PositionModel Position { get; set; }
        public ICollection<TagModel> Tags { get; set; }
    }
}
