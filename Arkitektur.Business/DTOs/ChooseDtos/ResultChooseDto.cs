using Arkitektur.Business.Base;

namespace Arkitektur.Business.DTOs.ChooseDtos
{
    public class ResultChooseDto : BaseDto
    {
        public string Title { get; set; }
        public string Description { get; set; }
        public string Icon { get; set; }
    }
}
