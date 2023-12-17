using EcoCars_Project.API.Models;
using EcoCars_Project.Application.Repositories.TB_AdsRepository;
using EcoCars_Project.Domain.Entities;
using EcoCars_Project.Persistance.Contexts;
using Microsoft.Data.SqlClient;
using Microsoft.EntityFrameworkCore;

namespace EcoCars_Project.API.Services.Concrete
{
    public class Tb_AdsReadService
    {
        private readonly ITB_AdsReadRepository _tB_AdsReadRepository;
        private readonly EcoCarsDbContext _context;

        public Tb_AdsReadService(ITB_AdsReadRepository tB_AdsReadRepository, EcoCarsDbContext context)
        {
            _tB_AdsReadRepository = tB_AdsReadRepository;
            _context = context;
        }


        //public IQueryable<TB_Ads> GetAll() 
        //{
            
        //        var clientIdParameter = new SqlParameter("@ClientId", 4);

        //        var result = _context.Database
        //            .SqlQuery("GetResultsForCampaign @ClientId",clientIdParameter)
        //            .ToList();
            
        //    return _tB_AdsReadRepository.GetAll();
        //}

    }
}
