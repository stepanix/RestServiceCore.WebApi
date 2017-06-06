using RestServiceCore.Domain.Entity;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;

namespace RestServiceCore.Domain.Entities
{
    public class ContactMember : BaseEntity<int>
    {
        [ForeignKey("Contact")]
        public int ContactId {get;set;}
        public Contact Contact { get; set; }
        [ForeignKey("Tag")]
        public int TagId { get; set; }
        public Tag Tag { get; set; }
    }
}
