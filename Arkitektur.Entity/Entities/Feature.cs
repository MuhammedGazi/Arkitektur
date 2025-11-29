using Arkitektur.Entity.Entities.Common;

namespace Arkitektur.Entity.Entities
{
    public class Feature : BaseEntity
    {
        public string Title { get; set; }
        public string Description { get; set; }
        public string BackgroundImage { get; set; }
        public string Icon { get; set; }
    }
}
