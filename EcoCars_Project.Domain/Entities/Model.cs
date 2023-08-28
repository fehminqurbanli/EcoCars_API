using EcoCars_Project.Domain.Entities.Common;

namespace EcoCars_Project.Domain.Entities
{
    public class Model:BaseEntity
    {
        public string ModelName { get; set; }
        public Guid BrandId { get; set; }
        public Brand Brand { get; set; }
    }
}
