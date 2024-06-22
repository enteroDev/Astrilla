using Microsoft.AspNetCore.Mvc;
using System.Linq;
using Newtonsoft.Json;
using Astrilla_Logic;
using Microsoft.Extensions.FileProviders;

namespace Astrilla.Controllers
{
    public class PartialController : Controller
    {
        private readonly IWebHostEnvironment _environment;

        public PartialController(IWebHostEnvironment environment)
        {
            _environment = environment;
        }

        public class ZodiacData
        {
            public List<ZodiacInformation> Zodiacs { get; set; }
        }

        public ActionResult ZodiacInformation(string sign)
        {
            ViewBag.Sign = sign;
            return PartialView("~/Views/Partial/ZodiacInformation.cshtml");
        }


        [HttpGet]
        public ActionResult GetZodiacInfo(string id)
        {
            var filePath = Path.Combine(_environment.WebRootPath, "js", "zodiacTexts.json");
            var json = System.IO.File.ReadAllText(filePath);
            var zodiacs = JsonConvert.DeserializeObject<ZodiacData>(json);

            if (zodiacs?.Zodiacs == null)
            {
                Console.WriteLine("Failed to deserialize JSON or Zodiacs is null.");
                return Json(new { success = false, message = "Failed to load zodiac data." });
            }

            var zodiacInfo = zodiacs.Zodiacs.FirstOrDefault(z => !string.IsNullOrEmpty(z.ID) && z.ID.Equals(id, StringComparison.OrdinalIgnoreCase));

            if (zodiacInfo == null)
            {
                Console.WriteLine($"Zodiac with ID '{id}' not found.");
                return Json(new { success = false, message = "Zodiac not found." });
            }

            Console.WriteLine($"Returning data for zodiac with ID '{id}'");
            return Json(new { success = true, data = zodiacInfo });
        }


        [HttpPost]
        public ActionResult UpdateZodiacInfo([FromBody] ZodiacInformation zodiacInfo)
        {
            var filePath = Path.Combine(_environment.WebRootPath, "js", "zodiacTexts.json");
            var json = System.IO.File.ReadAllText(filePath);
            var zodiacs = JsonConvert.DeserializeObject<ZodiacData>(json);

            var index = zodiacs.Zodiacs.FindIndex(z => z.ID.ToLower() == zodiacInfo.ID.ToLower());
            if (index != -1)
            {
                zodiacs.Zodiacs[index] = zodiacInfo;
                var updatedJson = JsonConvert.SerializeObject(zodiacs);
                System.IO.File.WriteAllText(filePath, updatedJson);
                return Json(new { success = true, message = "Zodiac information updated successfully!" });
            }

            return Json(new { success = false, message = "Zodiac not found." });
        }
    }
}