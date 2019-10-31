using Microsoft.AspNetCore.Mvc;
using aspnetzabota.Data.Interfaces;
using aspnetzabota.ViewModels;
using System.Linq;
using aspnetzabota.Data.Models;


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
                SingleSchedule = _doctorSchedule.SingleSchedule(id)
            };
            return View(result);
        }
        public ViewResult Doctor(int cat_id)
        {
            var result = new ScheduleViewModel
            {
                Schedule = _doctorSchedule.DoctorsSchedule(cat_id)
            };
            return View(result);

        }
        public ViewResult All()
        {
            return View();

        }
    }
}
