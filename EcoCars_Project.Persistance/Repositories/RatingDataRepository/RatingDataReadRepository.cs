using EcoCars_Project.Application.Repositories.RatingDataRepository;
using EcoCars_Project.Domain.Entities;
using EcoCars_Project.Persistance.Contexts;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EcoCars_Project.Persistance.Repositories.RatingDataRepository
{
    public class RatingDataReadRepository : ReadRepository<RatingData>, IRatingDataReadRepository
    {
        public RatingDataReadRepository(EcoCarsDbContext context) : base(context)
        {
        }
    }
}
