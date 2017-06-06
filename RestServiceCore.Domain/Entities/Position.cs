using RestServiceCore.Domain.Entity;


namespace RestServiceCore.Domain.Entities
{
    public class Position : BaseEntity<int>
    {
        public string Description { get; set; }
    }
}
