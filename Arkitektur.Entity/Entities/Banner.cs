using Arkitektur.Entity.Entities.Common;

namespace Arkitektur.Entity.Entities
{
    public class Banner : BaseEntity
    {
        public string Title { get; set; }
        public string Description { get; set; }
        public string ImageUrl { get; set; }
    }
}
