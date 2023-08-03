using EcoCars_Project.Domain.Entities.Common;


namespace EcoCars_Project.Domain.Entities
{
    public class GeneralType:BaseEntity
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public List<GeneralInfo> GeneralInfo { get; set; }
    }
}
