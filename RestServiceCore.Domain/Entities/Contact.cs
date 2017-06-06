using System.ComponentModel.DataAnnotations.Schema;
using RestServiceCore.Domain.Entity;
using System.Collections.Generic;

namespace RestServiceCore.Domain.Entities
{
    public class Contact : BaseEntity<int>
    {
        public string FirstName { get; set; }
        public string Surname { get; set; }
        [ForeignKey("Position")]
        public int PositionId { get; set; }
        public Position Position { get; set; }
        public ICollection<Tag> Tags { get; set; }
    }
}
