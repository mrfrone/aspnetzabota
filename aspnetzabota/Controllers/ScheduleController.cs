using Microsoft.AspNetCore.Mvc;
using aspnetzabota.Data.Interfaces;
using aspnetzabota.ViewModels;
using aspnetzabota.Data.Mapping;

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
                SingleSchedule = DoctorsMapping.Single(id, _doctorSchedule.Take)
            };
            return View(result);
        }
        public ViewResult Doctor(int id)
        {
            var result = new ScheduleViewModel
            {
                Schedule = DoctorsMapping.ScheduleFromSinglePost(id, _doctorSchedule.Take)
            };
            return View(result);

        }
        public ViewResult All()
        {
            var result = new ScheduleViewModel
            {
                Schedule = _doctorSchedule.Take,
                Posts = DoctorsMapping.Posts(_doctorSchedule.Take)
            };
            return View(result);

        }
        public ViewResult AllDoctors()
        {
            var result = new ScheduleViewModel
            {
                Schedule = _doctorSchedule.Take
            };
            return View(result);

        }
    }
}
