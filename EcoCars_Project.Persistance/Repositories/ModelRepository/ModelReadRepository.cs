using EcoCars_Project.Application.Repositories.ModelRepository;
using EcoCars_Project.Domain.Entities;
using EcoCars_Project.Persistance.Contexts;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EcoCars_Project.Persistance.Repositories.ModelRepository
{
    public class ModelReadRepository : ReadRepository<Model>, IModelReadRepository
    {
        public ModelReadRepository(EcoCarsDbContext context) : base(context)
        {

        }
    }
}
