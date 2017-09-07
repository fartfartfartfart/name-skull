using System.Net;
using System.Web.Mvc;
using CapnSkull.Models;
using CapnSkull.Interfaces;

namespace CapnSkull.Controllers
{
    [Authorize]
    public class SequencesController : Controller
    {
        private readonly IReportService _reportService;
        private readonly ISequenceRepository _sequenceRepository;

        public SequencesController(IReportService reportService, ISequenceRepository sequenceRepository)
        {
            _reportService = reportService;
            _sequenceRepository = sequenceRepository;
        }

        public ActionResult Index()
        {
            return View(new SequenceIndexViewModel { Sequences = _sequenceRepository.Get() });
        }

        [HttpPost]
        public ActionResult Report(Person person)
        {
            return View(_reportService.GetReport(person));
        }

        public ActionResult Details(int? id)
        {
            if (id == null) return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            var sequence = _sequenceRepository.Find((int)id);
            if (sequence == null) return HttpNotFound();
            return View(sequence);
        }

        public ActionResult Create()
        {
            return View();
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "Id,Characters,DefaultInfo,BeginningInfo,MiddleInfo,EndInfo,FirstVowelInfo")] Sequence sequence)
        {
            if (!ModelState.IsValid) return View(sequence);
            _sequenceRepository.Add(sequence);
            return RedirectToAction("Index");
        }

        public ActionResult Edit(int? id)
        {
            if (id == null) return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            var sequence = _sequenceRepository.Find((int)id);
            if (sequence == null) return HttpNotFound();
            return View(sequence);
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "Id,Characters,DefaultInfo,BeginningInfo,MiddleInfo,EndInfo,FirstVowelInfo")] Sequence sequence)
        {
            if (!ModelState.IsValid) return View(sequence);
            _sequenceRepository.Update(sequence);
            return RedirectToAction("Index");
        }

        public ActionResult Delete(int? id)
        {
            if (id == null) return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            var sequence = _sequenceRepository.Find((int)id);
            if (sequence == null) return HttpNotFound();
            return View(sequence);
        }

        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            var sequence = _sequenceRepository.Find((int)id);
            if (sequence != null) _sequenceRepository.Remove(sequence);
            return RedirectToAction("Index");
        }
    }
}

