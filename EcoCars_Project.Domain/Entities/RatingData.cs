using EcoCars_Project.Domain.Entities.Common;


namespace EcoCars_Project.Domain.Entities
{
    public class RatingData: BaseEntity
    {
        public string UserName { get; set; }
        public int RatingStar { get; set; }
        public string Description { get; set; }
    }
}
