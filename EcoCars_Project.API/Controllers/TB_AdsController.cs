using EcoCars_Project.Application.Repositories.BrandRepository;
using EcoCars_Project.Application.Repositories.ModelRepository;
using EcoCars_Project.Application.Repositories.TB_AdsImagesRepository;
using EcoCars_Project.Application.Repositories.TB_AdsRepository;
using EcoCars_Project.Domain.Entities;
using EcoCars_Project.Domain.Entities.Common;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Session;
using Microsoft.EntityFrameworkCore;
using Microsoft.SqlServer.Server;
using System.Net.Http.Headers;
using System.Security.Cryptography;
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
            var result = _tB_AdsReadRepository.GetAll().OrderByDescending(x=>x.CreatedDate).Include<TB_Ads>("TB_AdsImages").ToList();
            return Ok(result);
        }


        [HttpGet("GetTopThreeCars")]
        public IActionResult GetTopThreeCars()
        {
            var result = _tB_AdsReadRepository.GetAll().OrderByDescending(x=>x.CreatedDate).Where(x => x.Price > 50000 && x.Year > 2020 && x.CreatedDate.Month == DateTime.Now.Month).Take(3).Include<TB_Ads>("TB_AdsImages").ToList();
            return Ok(result);
        }




        [HttpGet("GetById")]
        public IActionResult GetById(string id)
        {
            //var result = await _tB_AdsReadRepository.GetByIdAsync(id);
            var result = _tB_AdsReadRepository.GetAll().Include("TB_AdsImages").FirstOrDefault(x => x.Id == Guid.Parse(id));


            return Ok(result);
        }

        [HttpGet("GetByBrandId")]
        public IActionResult GetByBrandId(string brandId,string modelId)
        {
            var result=new List<TB_Ads>();
            if (brandId=="undefined" && modelId == "undefined")
            {
                result = _tB_AdsReadRepository.GetAll().Include<TB_Ads>("TB_AdsImages").ToList();
            }
            else if (brandId != "undefined" && modelId == "undefined")
            {
                result = _tB_AdsReadRepository.GetAll().Where(x => x.Brand_Id == Guid.Parse(brandId)).Include("TB_AdsImages").ToList();

            }
            else
            {
                result = _tB_AdsReadRepository.GetAll().Where(x => x.Brand_Id == Guid.Parse(brandId) && x.Model_Id == Guid.Parse(modelId)).Include("TB_AdsImages").ToList();
            }
            //var bId = _modelReadRepository.GetAll().FirstOrDefault(x => x.BrandId == Guid.Parse(brandId));


            return Ok(result);
        }


        [HttpPost]
        public async Task<IActionResult> Post([FromForm] FormData formData)
        {

            formData.CreatedDate = DateTime.Now;
            formData.UpdatedDate = DateTime.Now;

            var tb_Ads = new TB_Ads()
            {
                Ban_Type = formData.ban_type,
                city = formData.city,
                Color_Id = formData.color_id,
                Condisioner = formData.condisioner,
                CreatedDate = formData.CreatedDate,
                Currency_Id = formData.currency_id,
                Distance = formData.distance,
                Distance_Id = formData.distance_id,
                email = formData.email,
                Leather_Salon = formData.leather_salon,
                Lyuk = formData.lyuk,
                Model_Id = formData.model_id,
                Brand_Id = formData.brand_id,
                name = formData.name,
                Note = formData.note,
                Park_Radar = formData.park_radar,
                phonenumber = formData.phonenumber,
                Price = formData.price,
                Rear_Camera = formData.rear_camera,
                seat_count = formData.seat_count,
                Seat_Heating = formData.seat_heating,
                Speed_Box = formData.speed_box,
                Transmission_Id = formData.transmission_id,
                UpdatedDate = formData.UpdatedDate,
                Year = formData.year,
            };

            await _tB_AdsWriteRepository.AddAsync(tb_Ads);
            await _tB_AdsWriteRepository.SaveAsync();




            List<byte[]> imageDatas = new List<byte[]>();
            using (MemoryStream memoryStream = new MemoryStream())
            {
                foreach (var file in formData.imageFile)
                {
                    file.CopyTo(memoryStream);
                    imageDatas.Add(memoryStream.ToArray());
                    memoryStream.Seek(0, SeekOrigin.Begin);
                }
            }



            //using (var ms = new MemoryStream())
            //{

            //    for (int i = 0; i < formData.imageFile.Count; i++)
            //    {
            //        await formData.imageFile[i].CopyToAsync(ms);
            //    }
            //    var imageData = new ImageData
            //    {
            //        Name = name,
            //        Data = ms.ToArray()
            //    };
            //    _context.Images.Add(imageData);
            //    await _context.SaveChangesAsync();
            //    return Ok("Image uploaded successfully.");

            //    var adsId = _tB_AdsReadRepository.GetAll().OrderByDescending(x => x.CreatedDate).FirstOrDefault().Id;
            //    List<TB_AdsImages> tB_AdsImages = new List<TB_AdsImages>();
            //    foreach (var item in imageDatas)
            //    {
            //        tB_AdsImages.Add(new TB_AdsImages() { CarImagePath = "test", Ads_Id = adsId, imageData = item });
            //    }




            //    await _tB_AdsImagesWriteRepository.AddRangeAsync(tB_AdsImages);
            //    await _tB_AdsImagesWriteRepository.SaveAsync();


            //    TB_AdsImages adsimg = new TB_AdsImages()
            //    {
            //        Ads_Id = adsId,
            //        imageData = imageData,
            //        CarImagePath = "test"
            //    };
            //    await _tB_AdsImagesWriteRepository.AddAsync(adsimg);
            //    await _tB_AdsImagesWriteRepository.SaveAsync();

            //}



            var adsId = _tB_AdsReadRepository.GetAll().OrderByDescending(x => x.CreatedDate).FirstOrDefault().Id;
            List<TB_AdsImages> tB_AdsImages = new List<TB_AdsImages>();
            foreach (var item in imageDatas)
            {
                tB_AdsImages.Add(new TB_AdsImages() { CarImagePath = "test", Ads_Id = adsId, imageData = item });
            }




            await _tB_AdsImagesWriteRepository.AddRangeAsync(tB_AdsImages);
            await _tB_AdsImagesWriteRepository.SaveAsync();

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

                result = _modelReadRepository.GetAll().Where(x => x.BrandId == Guid.Parse(brandId));
            }
            return Ok(result);
        }

        [HttpGet("GetModelAndBrand")]
        public IActionResult GetModelAndBrand(string modelId)
        {
            Model model = new Model();
            ModelAndBrand modelAndBrand = new ModelAndBrand();
            if (modelId != null)
            {
                model = _modelReadRepository.GetAll().Include("Brand").FirstOrDefault(x => x.Id == Guid.Parse(modelId));
                modelAndBrand.modelName = model.ModelName;
                modelAndBrand.brandName = model.Brand.BrandName;

            }
            return Ok(modelAndBrand);
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

    public class FormData : BaseEntity
    {
        public Guid model_id { get; set; }
        public Guid brand_id { get; set; }
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
        //public byte[] imageData { get; set; }
        public List<IFormFile> imageFile { get; set; }
    }

    public class ModelAndBrand
    {
        public string brandName { get; set; }
        public string modelName { get; set; }
    }

}
