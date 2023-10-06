using EcoCars_Project.Application.Repositories.BrandRepository;
using EcoCars_Project.Application.Repositories.ModelRepository;
using EcoCars_Project.Application.Repositories.TB_AdsRepository;
using EcoCars_Project.Domain.Entities;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace EcoCars_Project.API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class TB_AdsController : ControllerBase
    {
        private readonly ITB_AdsWriteRepository _tB_AdsWriteRepository;
        private readonly ITB_AdsReadRepository _tB_AdsReadRepository;
        private readonly IBrandReadRepository _brandReadRepository;
        private readonly IModelReadRepository _modelReadRepository;

        public TB_AdsController(ITB_AdsWriteRepository tB_AdsWriteRepository,
            ITB_AdsReadRepository tB_AdsReadRepository,
            IBrandReadRepository brandReadRepository,
            IModelReadRepository modelReadRepository)
        {
            _tB_AdsWriteRepository = tB_AdsWriteRepository;
            _tB_AdsReadRepository = tB_AdsReadRepository;
            _brandReadRepository = brandReadRepository;
            _modelReadRepository = modelReadRepository;
        }


        [HttpGet]
        public IActionResult Get()
        {
            var result = _tB_AdsReadRepository.GetAll();
            return Ok(result);
        }

        [HttpPost]
        public async Task<IActionResult> Post(TB_Ads model)
        {
            model.CreatedDate = DateTime.Now;
            model.UpdatedDate = DateTime.Now;
            model.Model_Id = Guid.Parse("954102DC-95AC-4E8D-9363-02299E6DDB1C");
            model.Ban_Type = 1;
            model.Distance = 1;
            model.Color_Id = 1;
            model.Price = 1;
            model.Speed_Box = 1;
            model.Currency_Id = 1;
            model.Transmission_Id = 1;
            model.Year = 1;
            model.Note = "asd";
            await _tB_AdsWriteRepository.AddAsync(model);
            await _tB_AdsWriteRepository.SaveAsync();

            return Ok();

        }

        [HttpGet("GetBrandNames")]
        public IActionResult GetBrandNames()
        {
            var result = _brandReadRepository.GetAll();
            
            return Ok(result);
        }

        [HttpGet("GetModelNames")]
        public IActionResult GetModelNames(Guid? brandId)
        {
            IQueryable<Model> result = null;

            if (brandId != null)
            {
                result = _modelReadRepository.GetWhere(x => x.BrandId == brandId);
            }
            return Ok(result);
        }


    }

    class BrandDto
    {
        public Guid Id { get; set; }
        public string BrandName { get; set; }
    }
}
