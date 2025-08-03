using Microsoft.AspNetCore.Mvc;
using MVC02.Filters;

namespace MVC02.Controllers
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
