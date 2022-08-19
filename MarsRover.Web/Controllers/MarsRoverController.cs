using CsvHelper;
using CsvHelper.Configuration;
using MarsRover.Core.Models;
using MarsRover.Core.Services;
using Microsoft.AspNetCore.Mvc;
using System.Globalization;

namespace MarsRover.Web.Controllers
{
    public class MarsRoverController : Controller
    {
        private readonly IMarsRoverService service;

        public MarsRoverController(IMarsRoverService service)
        {
            this.service = service;
        }

        public IActionResult Index()
        {
            return View();
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

            return PartialView();
        }
    }
}
