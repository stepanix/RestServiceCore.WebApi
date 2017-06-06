
using System.Collections.Generic;


namespace RestServiceCore.Domain.Models
{
    public class ContactModel
    {
        public int Id { get; set; }
        public string FirstName { get; set; }
        public string Surname { get; set; }
        public int PositionId { get; set; }
        public PositionModel Position { get; set; }
        public List<TagModel> Tags { get; set; }
    }
}
