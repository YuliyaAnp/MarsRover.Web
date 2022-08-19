using CsvHelper;
using CsvHelper.Configuration;
using MarsRover.Core.Models;
using MarsRover.Core.Services;
using Microsoft.AspNetCore.Mvc;
using System.Globalization;

namespace MarsRover.Web.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class MarsRoverCommandController : Controller
    {
        private readonly IMarsRoverService service;

        public MarsRoverCommandController(IMarsRoverService service)
        {
            this.service = service;
        }

        [HttpGet]
        public IActionResult Index()
        {
            return View();
        }


        [HttpPost]
        [Route("PreviewCsv")]
        public IActionResult PreviewCsv(IFormFile file)
        {
            var config = new CsvConfiguration(CultureInfo.InvariantCulture)
            {
                Delimiter = "|",
                HasHeaderRecord = false
            };

            var records = new List<CsvInputRecord>();
            using (var reader = new StreamReader(file.OpenReadStream()))
            using (var csv = new CsvReader(reader, config))
            {
                records = csv.GetRecords<CsvInputRecord>().ToList();
            }

            return Json(records);
        }

        [HttpPost]
        [Route("UploadFile")]
        public IActionResult UploadFile(IFormFile file)
        {
            var config = new CsvConfiguration(CultureInfo.InvariantCulture)
            {
                Delimiter = "|",
                HasHeaderRecord = false
            };

            var records = new List<CsvInputRecord>();
            using (var reader = new StreamReader(file.OpenReadStream()))
            using (var csv = new CsvReader(reader, config))
            {
                records = csv.GetRecords<CsvInputRecord>().ToList();
            }

            service.Run(records);

            return Json(service.FinalRoverCoordinates);
        }
    }
}
