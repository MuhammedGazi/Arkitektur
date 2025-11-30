using System.Text.Json.Serialization;

namespace Arkitektur.Entity.Entities.Common
{
    public class BaseEntity
    {
        public int Id { get; set; }
        public DateTime CreatedAt { get; set; }
        public DateTime UpdatedAt { get; set; }

        [JsonIgnore]
        public bool IsDeleted { get; set; }
    }
}
