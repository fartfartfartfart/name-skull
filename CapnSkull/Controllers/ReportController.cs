using System.Web.Mvc;
using CapnSkull.Models;

namespace CapnSkull.Controllers
{
    public class ReportController : Controller
    {
        // GET: Report
        public ActionResult Index(Person person)
        {
            return View(person);
        }
    }
}