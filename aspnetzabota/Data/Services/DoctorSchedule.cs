using aspnetzabota.Data.Interfaces;
using aspnetzabota.Data;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using X.PagedList;

namespace aspnetzabota.Data.Services
{
    public class DoctorSchedule : IDoctorSchedule
    {
        private static readonly Random random = new Random();
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

        public IEnumerable<DoctorScheduleModel> Take => JsonSchedule;
        public IEnumerable<string> Posts => JsonSchedule.Select(c => c.category).Distinct().ToList();
        public DoctorScheduleModel Single(int id) => JsonSchedule.FirstOrDefault(c => c.doctors.id == id.ToString());
        public IEnumerable<DoctorScheduleModel> ScheduleFromSinglePost(int cat_id) => JsonSchedule.Where(c => c.cat_id == cat_id.ToString());
        public IEnumerable<DoctorScheduleModel> Random(int Count) => JsonSchedule.OrderBy(x => random.Next()).TakeLast(Count);
        public IEnumerable<DoctorScheduleModel> GetPagedList(int pageNumber, int pageSize) => JsonSchedule.ToPagedList(pageNumber, pageSize);

    }
}
