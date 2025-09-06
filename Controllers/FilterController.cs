using EDU.Filters;
using Microsoft.AspNetCore.Mvc;

namespace EDU.Controllers
{
    public class FilterController : Controller
    {
        [HandleError]
        public IActionResult Index()
        {
            throw new Exception("Exeption From Index");
        }
    }
}
