using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace RestServiceCore.WebApi.Dto.Contacts.Dto.In
{
    public class ContactDtoIn
    {
        public int Id { get; set; }
        public string FirstName { get; set; }
        public string Surname { get; set; }
        public int PositionId { get; set; }
    }
}
