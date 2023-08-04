﻿using EcoCars_Project.Application.Repositories.TB_AdsRepository;
using EcoCars_Project.Domain.Entities;
using EcoCars_Project.Persistance.Contexts;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EcoCars_Project.Persistance.Repositories.TB_AdsRepository
{
    public class TB_AdsWriteRepository:WriteRepository<TB_Ads>,ITB_AdsWriteRepository
    {
        public TB_AdsWriteRepository(EcoCarsDbContext context):base(context)
        {

        }
    }
}
