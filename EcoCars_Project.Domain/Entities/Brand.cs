using EcoCars_Project.Domain.Entities.Common;


namespace EcoCars_Project.Domain.Entities
{
    public class Brand:BaseEntity
    {
        public Brand()
        {
            Models = new List<Model>();
        }

        public string BrandName { get; set; }
        public List<Model> Models { get; set; }
    }
}
