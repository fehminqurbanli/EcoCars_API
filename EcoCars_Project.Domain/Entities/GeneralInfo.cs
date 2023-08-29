using EcoCars_Project.Domain.Entities.Common;


namespace EcoCars_Project.Domain.Entities
{
    public class GeneralInfo:BaseEntity
    {
        public string Name { get; set; }
        public Guid TypeId { get; set; }
        public GeneralType GeneralType { get; set; }
    }
}
