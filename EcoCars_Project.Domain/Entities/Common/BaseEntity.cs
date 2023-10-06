using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.Json.Serialization;
using System.Threading.Tasks;

namespace EcoCars_Project.Domain.Entities.Common
{
    public class BaseEntity
    {
        //[JsonIgnore]
        public Guid Id { get; set; }
        //[JsonIgnore]
        public DateTime CreatedDate { get; set; }
        //[JsonIgnore]
        virtual public DateTime UpdatedDate { get; set; }
    }
}
