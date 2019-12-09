using Microsoft.AspNetCore.Mvc;
using aspnetzabota.Data.Interfaces;
using aspnetzabota.ViewModels;
using aspnetzabota.ComponentStyles;

namespace aspnetzabota.Controllers
{
    public class ScheduleController : Controller
    {
        private readonly IDoctorSchedule _doctorSchedule;

        public ScheduleController(IDoctorSchedule idoctorSchedule)
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
        public ViewResult All()
        {
            var result = new ScheduleViewModel
            {
                Schedule = _doctorSchedule.Take,
                Posts = _doctorSchedule.Posts
            };
            return View(result);

        }
        public ViewResult AllDoctors(int? page)
        {
            var pageNumber = page ?? 1;
            var result = new ScheduleViewModel
            {
                Schedule = _doctorSchedule.GetPagedList(pageNumber, 8),
                PaginationOptions = PaginationStyle.PagedListOptions
            };

            return View(result);

        }
    }
}
