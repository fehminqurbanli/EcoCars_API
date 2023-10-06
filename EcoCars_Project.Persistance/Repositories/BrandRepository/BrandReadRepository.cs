using EcoCars_Project.Application.Repositories.BrandRepository;
using EcoCars_Project.Domain.Entities;
using EcoCars_Project.Persistance.Contexts;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EcoCars_Project.Persistance.Repositories.BrandRepository
{
    public class BrandReadRepository:ReadRepository<Brand>,IBrandReadRepository
    {
        public BrandReadRepository(EcoCarsDbContext context):base(context)
        {
                
        }
    }
}
