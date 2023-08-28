using EcoCars_Project.Domain.Entities.Common;

using System.ComponentModel.DataAnnotations.Schema;


namespace EcoCars_Project.Domain.Entities
{
    public class TB_Ads:BaseEntity
    {
        //[Required(ErrorMessage = "Modeli daxil edin")]
        public Guid Model_Id { get; set; }
        //[Required(ErrorMessage = "Ban növünü daxil edin")]
        public int Ban_Type { get; set; }
        //[Required(ErrorMessage = "Yürüşü daxil edin")]
        public int Distance { get; set; }
        //[Required(ErrorMessage = "Rəngi daxil edin")]
        public int Color_Id { get; set; }
        //[Required(ErrorMessage = "Qiyməti daxil edin")]
        public int Price { get; set; }

        //[Required(ErrorMessage = "Sürətlər qutusunu daxil edin")]
        public int Speed_Box { get; set; }
        public int Currency_Id { get; set; }
        public bool Credit_Have { get; set; }
        public bool Barter { get; set; }

        //[Required(ErrorMessage = "Ötürücünü daxil edin")]
        public int Transmission_Id { get; set; }
        //[Required(ErrorMessage = "İli daxil edin")]
        public int Year { get; set; }

        public string Note { get; set; }
        public bool Leather_Salon { get; set; }
        public bool Park_Radar { get; set; }
        public bool Lyuk { get; set; }
        public bool Condisioner { get; set; }
        public bool Rear_Camera { get; set; }
        public bool Seat_Heating { get; set; }
        //[Required(ErrorMessage = "Adı daxil edin")]
        public string Name { get; set; }
        //[Required(ErrorMessage = "Şəhəri daxil edin")]
        public string City { get; set; }
        //[Required(ErrorMessage = "Emaili daxil edin")]
        public string Email { get; set; }

        //[Required(ErrorMessage = "Telefon nomresi daxil edin")]
        public string PhoneNumber { get; set; }


        [ForeignKey("Ads_Id")]
        public List<TB_AdsImages> TB_AdsImages { get; set; }
        //public List<GeneralInfoModel> generalInfo { get; set; }
    }
}
