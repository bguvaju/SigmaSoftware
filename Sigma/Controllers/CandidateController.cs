using Microsoft.AspNetCore.Mvc;

namespace Sigma.Controllers
{
    public class CandidateController : Controller
    {
        public IActionResult Index()
        {
            return View();
        }
    }
}
