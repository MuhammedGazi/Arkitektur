using Arkitektur.Entity.Entities.Common;

namespace Arkitektur.Entity.Entities
{
    public class About: BaseEntity
    {
        public string Title { get; set; }
        public string Description { get; set; }
        public int StartYear { get; set; }
        public string ImageUrl { get; set; }
    }
}
