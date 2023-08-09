using Microsoft.AspNetCore.Mvc;

namespace HomeBankingTest.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ClientController : Controller
    {
        public IActionResult Index()
        {
            return View();
        }
    }
}
