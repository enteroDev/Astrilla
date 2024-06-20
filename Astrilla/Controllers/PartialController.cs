using Microsoft.AspNetCore.Mvc;
using System.Net.Http;
using System.Threading.Tasks;
using HtmlAgilityPack;
using Newtonsoft.Json;
using Astrilla_Logic;
using Microsoft.Extensions.FileProviders;



namespace Astrilla.Controllers
{
    public class PartialController : Controller
    {
        private readonly IFileProvider _fileProvider;

        public PartialController(IFileProvider fileProvider)
        {
            _fileProvider = fileProvider;
        }

        public ActionResult ZodiacInformation(string sign)
        {
            ViewBag.Sign = sign;
            return PartialView("~/Views/Partial/ZodiacInformation.cshtml");
        }

        // Fetch Zodiac Texts from the Website
        [HttpGet("Partial/GetZodiacInfo")]
        public async Task<JsonResult> GetZodiacInfo(string id)
        {
            string baseUrl = "https://localhost:7030";
            string url = $"{baseUrl}/Partial/ZodiacInformation?sign={id}";

            var zodiacInfo = new ZodiacInformation();
            try
            {
                using (HttpClient client = new HttpClient())
                {
                    var response = await client.GetStringAsync(url);
                    var document = new HtmlDocument();
                    document.LoadHtml(response);

                    // Assuming the text is within specific HTML elements
                    var summaryNode = document.DocumentNode.SelectSingleNode($"//p[@id='summary-{id}']");
                    var textNode1 = document.DocumentNode.SelectSingleNode($"//p[@id='text1-{id}']");
                    var textNode2 = document.DocumentNode.SelectSingleNode($"//p[@id='text2-{id}']");
                    var textNode3 = document.DocumentNode.SelectSingleNode($"//p[@id='text3-{id}']");
                    var textNode4 = document.DocumentNode.SelectSingleNode($"//p[@id='text4-{id}']");
                    var textNode5 = document.DocumentNode.SelectSingleNode($"//p[@id='text5-{id}']");
                    var textNode6 = document.DocumentNode.SelectSingleNode($"//p[@id='text6-{id}']");

                    zodiacInfo = new ZodiacInformation
                    {
                        IDZodiac = id,
                        SummaryZodiac = summaryNode?.InnerText,
                        TextZodiac1 = textNode1?.InnerText,
                        TextZodiac2 = textNode2?.InnerText,
                        TextZodiac3 = textNode3?.InnerText,
                        TextZodiac4 = textNode4?.InnerText,
                        TextZodiac5 = textNode5?.InnerText,
                        TextZodiac6 = textNode6?.InnerText,
                    };
                }
            }
            catch (Exception ex)
            {
                return Json(new { error = "An unexpected error occurred." });
            }
            return Json(zodiacInfo);
        }

        // Update Website with edited Texts
        [HttpPost("Partial/UpdateZodiacInfo")]
        public async Task<JsonResult> UpdateZodiacInfo([FromBody] ZodiacInformation zodiacInfo)
        {
            // Implement logic to update the zodiac information here

            // Simulate success
            return Json(new { success = true });
        }
    }
}
