﻿using EcoCars_Project.Domain.Entities.Common;

namespace EcoCars_Project.Domain.Entities
{
    public class TB_AdsImages:BaseEntity
    {
        //[Key]
        public int Id { get; set; }
        public string CarImagePath { get; set; }
        //[DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int Ads_Id { get; set; }
        public TB_Ads TB_Ads { get; set; }
        //[NotMapped]
        //public List<IFormFile> Photos { get; set; }
    }
}