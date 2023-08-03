using EcoCars_Project.Domain.Entities.Common;


namespace EcoCars_Project.Domain.Entities
{
    public class GeneralInfo:BaseEntity
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public int TypeId { get; set; }
        public GeneralType GeneralType { get; set; }
    }
}
