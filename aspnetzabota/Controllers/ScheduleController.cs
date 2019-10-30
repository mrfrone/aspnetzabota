using Microsoft.AspNetCore.Mvc;
using aspnetzabota.Data.Interfaces;
using aspnetzabota.ViewModels;
using System.Linq;

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
            ScheduleViewModel obj = new ScheduleViewModel();
            obj.SingleSchedule = _DoctorSchedule.AllSchedules.Where(c => c.doctors.id == id.ToString()).FirstOrDefault();
            return View(obj);
        }
        public ViewResult Doctor()
        {
            return View();

        }
        public ViewResult All()
        {
            return View();

        }
    }
}
