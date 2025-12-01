using Arkitektur.Business.Base;
using Arkitektur.Business.DTOs.CategoryDtos;

namespace Arkitektur.Business.DTOs.ProjectDtos
{
    public class ResultProjectDto : BaseDto
    {
        public string Title { get; set; }
        public string Description { get; set; }
        public string ImageUrl { get; set; }
        public string Item1 { get; set; }
        public string Item2 { get; set; }
        public string Item3 { get; set; }

        public int CategoryId { get; set; }
        public ResultCategoryDto Category { get; set; }
    }
}
