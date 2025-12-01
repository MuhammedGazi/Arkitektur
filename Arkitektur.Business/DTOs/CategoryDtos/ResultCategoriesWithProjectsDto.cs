using Arkitektur.Business.DTOs.ProjectDtos;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Arkitektur.Business.DTOs.CategoryDtos
{
    public record ResultCategoriesWithProjectsDto
        (
        int Id,
        string CategoryName,
        IList<ProjectDto> Projects
        );

}
