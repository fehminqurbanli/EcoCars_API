using EcoCars_Project.Application.Repositories.TB_AdsImagesRepository;
using EcoCars_Project.Domain.Entities;
using EcoCars_Project.Persistance.Contexts;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EcoCars_Project.Persistance.Repositories.TB_AdsImagesRepository
{
    public class TB_AdsImagesReadRepository:ReadRepository<TB_AdsImages>,ITB_AdsImagesReadRepository
    {
        public TB_AdsImagesReadRepository(EcoCarsDbContext context):base(context)
        {

        }
    }
}
