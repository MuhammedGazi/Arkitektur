using Arkitektur.Entity.Entities.Common;

namespace Arkitektur.Entity.Entities
{
    public class Project:BaseEntity
    {
        public string Title { get; set; }
        public string Description { get; set; }
        public string ImageUrl { get; set; }
        public string Item1 { get; set; }
        public string Item2 { get; set; }
        public string Item3 { get; set; }

        public int CategoryId { get; set; }
        public Category Category { get; set; }
    }
}
