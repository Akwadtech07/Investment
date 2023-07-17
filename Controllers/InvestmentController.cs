using Microsoft.AspNetCore.Mvc;

namespace New_folder.Controllers
{
    public class InvestmentController : Controller
    {
        public IActionResult Index()
        {
            return View();
        }
    }
}
