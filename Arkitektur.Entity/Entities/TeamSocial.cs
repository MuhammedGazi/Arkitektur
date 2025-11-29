using Arkitektur.Entity.Entities.Common;

namespace Arkitektur.Entity.Entities
{
    public class TeamSocial : BaseEntity
    {
        public string Title { get; set; }
        public string Icon { get; set; }
        public string Url { get; set; }

        public int TeamId { get; set; }
        public Team Team { get; set; }
    }
}
