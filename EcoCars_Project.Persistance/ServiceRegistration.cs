using EcoCars_Project.Application.Repositories.BrandRepository;
using EcoCars_Project.Application.Repositories.ModelRepository;
using EcoCars_Project.Application.Repositories.TB_AdsImagesRepository;
using EcoCars_Project.Application.Repositories.TB_AdsRepository;
using EcoCars_Project.Persistance.Contexts;
using EcoCars_Project.Persistance.Repositories.BrandRepository;
using EcoCars_Project.Persistance.Repositories.ModelRepository;
using EcoCars_Project.Persistance.Repositories.TB_AdsImagesRepository;
using EcoCars_Project.Persistance.Repositories.TB_AdsRepository;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.DependencyInjection;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EcoCars_Project.Persistance
{
    public static class ServiceRegistration
    {
        public static void AddPersistanceServices(this IServiceCollection services)
        {
            services.AddDbContext<EcoCarsDbContext>(options => 
                options.UseSqlServer(Configuration.ConnectionString));

            services.AddScoped<ITB_AdsReadRepository, TB_AdsReadRepository>();
            services.AddScoped<ITB_AdsWriteRepository, TB_AdsWriteRepository>();
            
            services.AddScoped<ITB_AdsImagesReadRepository, TB_AdsImagesReadRepository>();
            services.AddScoped<ITB_AdsImagesWriteRepository, TB_AdsImagesWriteRepository>();

            services.AddScoped<IBrandReadRepository, BrandReadRepository>();
            services.AddScoped<IModelReadRepository, ModelReadRepository>();

        }
    }
}
