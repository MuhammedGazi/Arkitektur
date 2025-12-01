using Arkitektur.Business.Base;
using Arkitektur.Business.DTOs.ProjectDtos;
using Arkitektur.Entity.Entities;

namespace Arkitektur.Business.DTOs.CategoryDtos
{
    public class ResultCategoryDto : BaseDto
    {
        public string CategoryName { get; set; }
        //public IList<ResultProjectDto> Projects { get; set; }
    }
}
