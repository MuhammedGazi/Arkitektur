using Arkitektur.Business.Base;

namespace Arkitektur.Business.DTOs.FeatureDtos
{
    public class ResultFeatureDto : BaseDto
    {
        public string Title { get; set; }
        public string Description { get; set; }
        public string BackgroundImage { get; set; }
        public string Icon { get; set; }
    }
}
