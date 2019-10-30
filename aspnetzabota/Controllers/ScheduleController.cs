using Microsoft.AspNetCore.Mvc;
using aspnetzabota.Data.Interfaces;
using aspnetzabota.ViewModels;
using System.Linq;
using aspnetzabota.Data.Models;


namespace aspnetzabota.Controllers
{
    public class ScheduleController : Controller
    {
        private readonly IDoctorSchedule _DoctorSchedule;

        public ScheduleController(IDoctorSchedule doctorSchedule)
        {
            _DoctorSchedule = doctorSchedule;
        }
        public ViewResult Single(int id)
        {
            ScheduleViewModel obj = new ScheduleViewModel
            {
                SingleSchedule = _DoctorSchedule.AllSchedules.FirstOrDefault(c => c.doctors.id == id.ToString())
            };
            return View(obj);
        }
        public ViewResult Doctor(int cat_id)
        {
            ScheduleViewModel obj = new ScheduleViewModel
            {
                Schedule = _DoctorSchedule.AllSchedules.Where(c => c.cat_id == cat_id.ToString())
            };
            return View(obj);

        }
        public ViewResult All()
        {
            return View();

        }
    }
}
