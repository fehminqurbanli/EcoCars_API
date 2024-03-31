using EcoCars_Project.Application.Repositories.RatingDataRepository;
using EcoCars_Project.Domain.Entities;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace EcoCars_Project.API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class RatingDataController : ControllerBase
    {
        private readonly IRatingDataWriteRepository _ratingDataWriteRepository;
        private readonly IRatingDataReadRepository _ratingDataReadRepository;

        public RatingDataController(IRatingDataWriteRepository ratingDataWriteRepository, IRatingDataReadRepository ratingDataReadRepository)
        {
            _ratingDataWriteRepository = ratingDataWriteRepository;
            _ratingDataReadRepository = ratingDataReadRepository;
        }



        [HttpGet]
        public IActionResult GetAll()
        {
            var result = _ratingDataReadRepository.GetAll();
            return Ok(result);
        }

        [HttpPost]
        public async Task<IActionResult> Post([FromForm] RatingData ratingData)
        {
            await _ratingDataWriteRepository.AddAsync(ratingData);
            await _ratingDataWriteRepository.SaveAsync();

            return Ok();

        }
    }
}
