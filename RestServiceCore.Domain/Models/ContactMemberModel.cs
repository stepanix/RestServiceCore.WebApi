using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace RestServiceCore.Domain.Models
{
    public class ContactMemberModel
    {
        public int Id { get; set; }
        public int ContactId { get; set; }
        public ContactModel Contact { get; set; }
        public int TagId { get; set; }
        public TagModel Tag { get; set; }
    }
}
