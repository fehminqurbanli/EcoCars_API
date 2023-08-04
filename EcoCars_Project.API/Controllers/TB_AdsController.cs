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

        public TB_AdsController(ITB_AdsWriteRepository tB_AdsWriteRepository,
            ITB_AdsReadRepository tB_AdsReadRepository)
        {
            _tB_AdsWriteRepository = tB_AdsWriteRepository;
            _tB_AdsReadRepository = tB_AdsReadRepository;
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
            await _tB_AdsWriteRepository.AddAsync(model);
            await _tB_AdsWriteRepository.SaveAsync();

            return Ok();

        }
    }
}
