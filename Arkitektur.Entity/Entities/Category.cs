using Arkitektur.Entity.Entities.Common;

namespace Arkitektur.Entity.Entities
{
    public class Category : BaseEntity
    {
        public string CategoryName { get; set; }
        public IList<Project> Projects { get; set; }
    }
}
