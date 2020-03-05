using Microsoft.AspNetCore.Mvc;
using aspnetzabota.Web.ViewModels;
using aspnetzabota.Web.Style;
using aspnetzabota.Content.Services.Schedule;
using System.Threading.Tasks;

namespace aspnetzabota.Controllers
{
    public class ScheduleController : Controller
    {
        private readonly ISchedule _doctorSchedule;

        public ScheduleController(ISchedule idoctorSchedule)
        {
            _doctorSchedule = idoctorSchedule;
        }
        public async Task<IActionResult> Single(int id)
        {
            var result = new ScheduleViewModel
            {
                SingleSchedule =  await _doctorSchedule.Single(id)
            };
            return View(result);
        }
        public async Task<IActionResult> Doctor(int id)
        {
            var result = new ScheduleViewModel
            {
                Schedule = await _doctorSchedule.ScheduleFromSinglePost(id)
            };
            return View(result);

        }
        public async Task<ViewResult> List()
        {
            var result = new ScheduleViewModel
            {
                Schedule = await _doctorSchedule.Get(),
                Posts = await _doctorSchedule.Posts()
            };
            return View(result);

        }
        public async Task<ViewResult> DoctorsList()
        {
            var result = new ScheduleViewModel
            {
                Schedule = await _doctorSchedule.GetPagedList(1, 8),
                PaginationOptions = PaginationStyle.PagedListOptions
            };
            return View(result);
        }
        public async Task<IActionResult> PagedDoctorsList(int? page)
        {
            var pageNumber = page ?? 1;
            var result = new ScheduleViewModel
            {
                Schedule = await _doctorSchedule.GetPagedList(pageNumber, 8),
                PaginationOptions = PaginationStyle.PagedListOptionsAjax
            };
            return PartialView(result);
        }
    }
}
