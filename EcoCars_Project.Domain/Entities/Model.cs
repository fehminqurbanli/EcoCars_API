using EcoCars_Project.Domain.Entities.Common;

namespace EcoCars_Project.Domain.Entities
{
    public class Model:BaseEntity
    {
        public int Id { get; set; }
        public string ModelName { get; set; }
        public int BrandId { get; set; }
        public Brand brand { get; set; }
    }
}
