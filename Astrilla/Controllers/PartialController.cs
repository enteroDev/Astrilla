using Microsoft.AspNetCore.Mvc;

namespace Astrilla.Controllers
{
    public class PartialController : Controller
    {
        public ActionResult ZodiacInformation(string sign)
        {
            ViewBag.Sign = sign;
            return PartialView("~/Views/Partial/ZodiacInformation.cshtml");
        }
    }
}
