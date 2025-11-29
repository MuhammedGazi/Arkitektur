using Arkitektur.Entity.Entities.Common;

namespace Arkitektur.Entity.Entities
{
    public class Testimonial:BaseEntity
    {
        public string NameSurname { get; set; }
        public string Title { get; set; }
        public string ImageUrl { get; set; }
        public string Comment { get; set; }
    }
}
