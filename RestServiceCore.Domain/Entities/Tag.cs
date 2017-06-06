using RestServiceCore.Domain.Entity;

namespace RestServiceCore.Domain.Entities
{
    public class Tag : BaseEntity<int>
    {
        public string Description {get;set;}
    }
}
