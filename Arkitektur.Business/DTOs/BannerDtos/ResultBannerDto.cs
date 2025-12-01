using Arkitektur.Business.Base;

namespace Arkitektur.Business.DTOs.BannerDtos
{
    public class ResultBannerDto : BaseDto
    {
        public string Title { get; set; }
        public string Description { get; set; }
        public string ImageUrl { get; set; }
    }
}
