using Microsoft.AspNetCore.Mvc;
using aspnetzabota.ViewModels;
using aspnetzabota.ComponentStyles;

namespace aspnetzabota.Controllers
{
    public class ScheduleController : Controller
    {
        private readonly Data.Interfaces.IDoctorSchedule _doctorSchedule;

        public ScheduleController(Data.Interfaces.IDoctorSchedule idoctorSchedule)
        {
            _doctorSchedule = idoctorSchedule;
        }
        public ViewResult Single(int id)
        {
            var result = new ScheduleViewModel
            {
                SingleSchedule = _doctorSchedule.Single(id)
            };
            return View(result);
        }
        public ViewResult Doctor(int id)
        {
            var result = new ScheduleViewModel
            {
                Schedule = _doctorSchedule.ScheduleFromSinglePost(id)
            };
            return View(result);

        }
        public ViewResult List()
        {
            var result = new ScheduleViewModel
            {
                Schedule = _doctorSchedule.Take,
                Posts = _doctorSchedule.Posts
            };
            return View(result);

        }
        public ViewResult DoctorsList()
        {
            var result = new ScheduleViewModel
            {
                Schedule = _doctorSchedule.GetPagedList(1, 8),
                PaginationOptions = PaginationStyle.PagedListOptions
            };
            return View(result);
        }
        public ActionResult PagedDoctorsList(int? page)
        {
            var pageNumber = page ?? 1;
            var result = new ScheduleViewModel
            {
                Schedule = _doctorSchedule.GetPagedList(pageNumber, 8),
                PaginationOptions = PaginationStyle.PagedListOptionsAjax
            };
            return PartialView(result);
        }
    }
}
