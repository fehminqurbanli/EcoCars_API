using EcoCars_Project.Domain.Entities.Common;
using System.Text.Json.Serialization;

namespace EcoCars_Project.Domain.Entities
{
    public class TB_AdsImages:BaseEntity
    {
        //[Key]
        public string CarImagePath { get; set; }
        //[DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public Guid Ads_Id { get; set; }
        public TB_Ads TB_Ads { get; set; }
        //[NotMapped]
        //public List<IFormFile> Photos { get; set; }
    }
}
