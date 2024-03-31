using EcoCars_Project.Application.Repositories.RatingDataRepository;
using EcoCars_Project.Application.Repositories.TB_AdsRepository;
using EcoCars_Project.Domain.Entities;
using EcoCars_Project.Persistance.Contexts;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EcoCars_Project.Persistance.Repositories.RatingDataRepository
{
    public class RatingDataWriteRepository : WriteRepository<RatingData>, IRatingDataWriteRepository
    {
        public RatingDataWriteRepository(EcoCarsDbContext context) : base(context)
        {
        }
    }
}
