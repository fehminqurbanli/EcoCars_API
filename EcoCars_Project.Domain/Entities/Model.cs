using EcoCars_Project.Domain.Entities.Common;
using System.Text.Json.Serialization;

namespace EcoCars_Project.Domain.Entities
{
    public class Model:BaseEntity
    {
        public string ModelName { get; set; }
        public Guid BrandId { get; set; }
        [JsonIgnore]
        public Brand Brand { get; set; }
    }
}
