using DynamicTimetable.Models;
using DynamicTimetable.Services;
using Microsoft.AspNetCore.Mvc;

namespace DynamicTimetable.Controllers
{
    public class TimetableController : Controller
    {
        [HttpGet]
        public IActionResult Index()
        {
            return View();
        }

        [HttpPost]
        public IActionResult AllocateSubjects(TimetableInput input)
        {
            if (!ModelState.IsValid)
                return View("Index", input);

            return View("AllocateSubjects", input);
        }

        [HttpPost]
        public IActionResult GenerateTimetable(TimetableInput input, List<SubjectAllocation> subjects)
        {
            if (subjects.Sum(s => s.Hours) != input.TotalHours)
                return BadRequest("Total hours mismatch!");

            var timetable = TimetableService.Generate(input, subjects);
            return View("Timetable", timetable);
        }
    }
}
