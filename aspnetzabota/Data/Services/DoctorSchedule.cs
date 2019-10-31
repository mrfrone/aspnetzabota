using aspnetzabota.Data.Interfaces;
using aspnetzabota.Data.Models;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;

namespace aspnetzabota.Data.Services
{
    public class DoctorSchedule : IDoctorSchedule
    {
        private readonly Random random = new Random();
        private IEnumerable<DoctorScheduleModel> JsonSchedule
        {
            get
            {
                using (StreamReader sr = new StreamReader("wwwroot/json/schedule.json"))
                {
                    return JsonConvert.DeserializeObject<IEnumerable<DoctorScheduleModel>>(sr.ReadToEnd());
                }
            }
        }

        public IEnumerable<DoctorScheduleModel> AllSchedules => JsonSchedule;
        public IEnumerable<DoctorScheduleModel> RandomSchedules => JsonSchedule.OrderBy(x => random.Next()).TakeLast(4);

        public IEnumerable<DoctorScheduleModel> DoctorsSchedule(int cat_id) => JsonSchedule.Where(c => c.cat_id == cat_id.ToString());

        public DoctorScheduleModel SingleSchedule(int id) => JsonSchedule.FirstOrDefault(c => c.doctors.id == id.ToString());
    }
}
