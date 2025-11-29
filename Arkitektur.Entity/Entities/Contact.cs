using Arkitektur.Entity.Entities.Common;

namespace Arkitektur.Entity.Entities
{
    public class Contact : BaseEntity
    {
        public string Address { get; set; }
        public string PhoneNumber { get; set; }
        public string Email { get; set; }
        public string MapUrl { get; set; }
    }
}
