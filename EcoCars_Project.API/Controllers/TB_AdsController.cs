using EcoCars_Project.Application.Repositories.BrandRepository;
using EcoCars_Project.Application.Repositories.ModelRepository;
using EcoCars_Project.Application.Repositories.TB_AdsImagesRepository;
using EcoCars_Project.Application.Repositories.TB_AdsRepository;
using EcoCars_Project.Domain.Entities;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Session;
using Microsoft.SqlServer.Server;
using System.Net.Http.Headers;
using System.Web;

namespace EcoCars_Project.API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class TB_AdsController : ControllerBase
    {
        private readonly ITB_AdsWriteRepository _tB_AdsWriteRepository;
        private readonly ITB_AdsImagesWriteRepository _tB_AdsImagesWriteRepository;
        private readonly ITB_AdsReadRepository _tB_AdsReadRepository;
        private readonly IBrandReadRepository _brandReadRepository;
        private readonly IModelReadRepository _modelReadRepository;
        private readonly IWebHostEnvironment _env;
        public TB_AdsController(ITB_AdsWriteRepository tB_AdsWriteRepository,
            ITB_AdsReadRepository tB_AdsReadRepository,
            IBrandReadRepository brandReadRepository,
            IModelReadRepository modelReadRepository,
            IWebHostEnvironment env,
            ITB_AdsImagesWriteRepository tB_AdsImagesWriteRepository)
        {
            _tB_AdsWriteRepository = tB_AdsWriteRepository;
            _tB_AdsReadRepository = tB_AdsReadRepository;
            _brandReadRepository = brandReadRepository;
            _modelReadRepository = modelReadRepository;
            _env = env;
            _tB_AdsImagesWriteRepository = tB_AdsImagesWriteRepository;
        }


        [HttpGet]
        public IActionResult Get()
        {
            var result = _tB_AdsReadRepository.GetAll();
            return Ok(result);
        }

        [HttpGet("GetById")]
        public async Task<IActionResult> GetById(string id)
        {
            var result = await _tB_AdsReadRepository.GetByIdAsync(id);
            return Ok(result);
        }


        [HttpPost]
        public async Task<IActionResult> Post([FromForm] FormData formData)
        {
            
            //model.CreatedDate = DateTime.Now;
            //model.UpdatedDate = DateTime.Now;

           
            //await _tB_AdsWriteRepository.AddAsync(model);
            //await _tB_AdsWriteRepository.SaveAsync();

            //var adsId = _tB_AdsReadRepository.GetAll().OrderByDescending(x=>x.CreatedDate).FirstOrDefault().Id;
            //List<TB_AdsImages> tB_AdsImages = new List<TB_AdsImages>();
            //foreach (var item in model.TB_AdsImages)
            //{
            //    tB_AdsImages.Add(new TB_AdsImages() { CarImagePath = item.CarImagePath, Ads_Id = adsId });
            //}
            //await _tB_AdsImagesWriteRepository.AddRangeAsync(tB_AdsImages);

            return Ok();

        }

        [HttpGet("GetBrandNames")]
        public IActionResult GetBrandNames()
        {
            var result = _brandReadRepository.GetAll();
            
            return Ok(result);
        }

        [HttpGet("GetModelNames")]
        public IActionResult GetModelNames(string brandId)
        {
            IQueryable<Model> result = null;
            //Guid brandId = _brandReadRepository.GetAll().Where(x => x.BrandName == brandName).FirstOrDefault().Id;
            if (brandId != null)
            {
                result = _modelReadRepository.GetAll().Where(x => x.BrandId ==Guid.Parse(brandId));
            }
            return Ok(result);
        }

        //[HttpPost("Upload"), DisableRequestSizeLimit]
        //public async Task<IActionResult> Upload()
        //{
        //    try
        //    {
        //        var formCollection = await Request.ReadFormAsync();
        //        var file = formCollection.Files.First();

        //        //var file = Request.Form.Files[0];
        //        var folderName = Path.Combine("Resources", "Images");
        //        var pathToSave = Path.Combine(Directory.GetCurrentDirectory(), folderName);
        //        if (file.Length > 0)
        //        {
        //            var fileName = ContentDispositionHeaderValue.Parse(file.ContentDisposition).FileName.Trim('"');
        //            var fullPath = Path.Combine(pathToSave, fileName);
        //            var dbPath = Path.Combine(folderName, fileName);
        //            using (var stream = new FileStream(fullPath, FileMode.Create))
        //            {
        //                file.CopyTo(stream);
        //            }
        //            return Ok(new { dbPath });
        //        }
        //        else
        //        {
        //            return BadRequest();
        //        }
        //    }
        //    catch (Exception ex)
        //    {
        //        return StatusCode(500, $"Internal server error: {ex}");
        //    }
        //}


        [HttpPost("Upload")]
        public JsonResult Upload()
        {
            try
            {
                var httpRequest = Request.Form;
                var postedFile = httpRequest.Files[0];
                string filename = postedFile.FileName;
                var physicalPath = _env.ContentRootPath + "/Resources/Images/" + filename;

                //Session["username"] = physicalPath;
                using (var stream = new FileStream(physicalPath, FileMode.Create))
                {
                    stream.CopyTo(stream);
                }

                return new JsonResult(filename);
            }
            catch (Exception)
            {
                return new JsonResult("anonymous.png");
            }
        }
    }

    public class FormData
    {
        public Guid model_id { get; set; }
        public int ban_type { get; set; }
        public int distance_id { get; set; }
        public int distance { get; set; }
        public int color_id { get; set; }
        public int price { get; set; }
        public int speed_box { get; set; }
        public int currency_id { get; set; }
        public int seat_count { get; set; }
        ////public bool Credit_Have { get; set; }
        ////public bool Barter { get; set; }

        public int transmission_id { get; set; }
        public int year { get; set; }

        public string note { get; set; }
        public bool leather_salon { get; set; }
        public bool park_radar { get; set; }
        public bool lyuk { get; set; }
        public bool condisioner { get; set; }
        public bool rear_camera { get; set; }
        public bool seat_heating { get; set; }
        public string name { get; set; }
        public string city { get; set; }
        public string email { get; set; }

        public string phonenumber { get; set; }
        public List<IFormFile> imageFile { get; set; }
    }

}
