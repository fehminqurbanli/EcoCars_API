using EcoCars_Project.Application.Repositories.TB_AdsImagesRepository;
using EcoCars_Project.Domain.Entities;
using EcoCars_Project.Persistance.Contexts;


namespace EcoCars_Project.Persistance.Repositories.TB_AdsImagesRepository
{
    public class TB_AdsImagesWriteRepository:WriteRepository<TB_AdsImages>,ITB_AdsImagesWriteRepository
    {
        public TB_AdsImagesWriteRepository(EcoCarsDbContext context):base(context)
        {

        }
    }
}
