using aspnetzabota.Data.Interfaces;
using aspnetzabota.Data.Models;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Threading.Tasks;

namespace aspnetzabota.Data.Services
{
    public class DoctorSchedule : IDoctorSchedule
    {
        private readonly Random random = new Random();
        private IEnumerable<DoctorScheduleModel> RemoveNoReception(IEnumerable<DoctorScheduleModel> model)
        {
            string symb = "-";
            foreach (var mod in model)
            {
                if (mod.doctors.schedule.mon == "нет приема")
                    mod.doctors.schedule.mon = symb;
                if (mod.doctors.schedule.tue == "нет приема")
                    mod.doctors.schedule.tue = symb;
                if (mod.doctors.schedule.wed == "нет приема")
                    mod.doctors.schedule.wed = symb;
                if (mod.doctors.schedule.thu == "нет приема")
                    mod.doctors.schedule.thu = symb;
                if (mod.doctors.schedule.fri == "нет приема")
                    mod.doctors.schedule.fri = symb;
                if (mod.doctors.schedule.sat == "нет приема")
                    mod.doctors.schedule.sat = symb;
                if (mod.doctors.schedule.sun == "нет приема")
                    mod.doctors.schedule.sun = symb;
            }
            return model;
        }
        private IEnumerable<DoctorScheduleModel> JsonSchedule
        {
            get
            {
                using (StreamReader sr = new StreamReader("wwwroot/json/schedule.json"))
                {
                    return RemoveNoReception(JsonConvert.DeserializeObject<IEnumerable<DoctorScheduleModel>>(sr.ReadToEnd())).OrderBy(c => c.category);
                }
            }
        }

        public IEnumerable<DoctorScheduleModel> AllSchedules => JsonSchedule;
        public IEnumerable<DoctorScheduleModel> RandomSchedules => JsonSchedule.OrderBy(x => random.Next()).TakeLast(4);

        public IEnumerable<DoctorScheduleModel> DoctorsSchedule(int cat_id) => JsonSchedule.Where(c => c.cat_id == cat_id.ToString());

        public DoctorScheduleModel SingleSchedule(int id) => JsonSchedule.FirstOrDefault(c => c.doctors.id == id.ToString());
        public List<string> PostsArray => JsonSchedule.Select(c => c.category).Distinct().ToList();
        
    }
}
