using Arkitektur.Entity.Entities.Common;

namespace Arkitektur.Entity.Entities
{
    public class UserMessage:BaseEntity
    {
        public string NameSurname { get; set; }
        public string Email { get; set; }
        public string Subject { get; set; }
        public string MessageBody { get; set; }
        public bool IsRead { get; set; }
    }
}
