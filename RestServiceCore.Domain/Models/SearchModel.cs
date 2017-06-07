using System;
using System.Collections.Generic;
using System.Text;

namespace RestServiceCore.Domain.Models
{
    public class SearchModel
    {
        public int Id { get; set; }
        public string Description { get; set; }
        public string SearchType { get; set; }
    }
}
