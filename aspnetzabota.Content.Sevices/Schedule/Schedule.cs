using aspnetzabota.Content.Datamodel.Doctors;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Threading.Tasks;
using X.PagedList;

namespace aspnetzabota.Content.Services.Schedule
{
    internal class Schedule : ISchedule
    {
        private static readonly Random random = new Random();
        private IEnumerable<DoctorScheduleModel> RemoveNoReception(IEnumerable<DoctorScheduleModel> model)
        {
            string symb = "-";
            string phrase = "нет приема";
            foreach (var mod in model)
            {
                if (mod.doctors.schedule.mon == phrase)
                    mod.doctors.schedule.mon = symb;
                if (mod.doctors.schedule.tue == phrase)
                    mod.doctors.schedule.tue = symb;
                if (mod.doctors.schedule.wed == phrase)
                    mod.doctors.schedule.wed = symb;
                if (mod.doctors.schedule.thu == phrase)
                    mod.doctors.schedule.thu = symb;
                if (mod.doctors.schedule.fri == phrase)
                    mod.doctors.schedule.fri = symb;
                if (mod.doctors.schedule.sat == phrase)
                    mod.doctors.schedule.sat = symb;
                if (mod.doctors.schedule.sun == phrase)
                    mod.doctors.schedule.sun = symb;
            }
            return model;
        }
        private async Task<IEnumerable<DoctorScheduleModel>> JsonSchedule()
        {
                using (StreamReader sr = new StreamReader("wwwroot/json/schedule.json"))
                {
                    return RemoveNoReception(JsonConvert.DeserializeObject<IEnumerable<DoctorScheduleModel>>(await sr.ReadToEndAsync())).OrderBy(c => c.category);
                }
        }

        public async Task<IEnumerable<DoctorScheduleModel>> Get()
        {
            return await JsonSchedule();
        }

        public async Task<IEnumerable<string>> Posts()
        {
            var schedule = await Get();
            return schedule.Select(c => c.category).Distinct().ToList();
        }

        public async Task<DoctorScheduleModel> Single(int id)
        {
            var schedule = await Get();
            return schedule.FirstOrDefault(c => c.doctors.id == id.ToString());
        }

        public async Task<IEnumerable<DoctorScheduleModel>> ScheduleFromSinglePost(int cat_id)
        {
            var schedule = await Get();
            return schedule.Where(c => c.cat_id == cat_id.ToString());
        }

        public async Task<IEnumerable<DoctorScheduleModel>> Random(int Count)
        {
            var schedule = await Get();
            return schedule.OrderBy(x => random.Next()).Take(Count);
        }

        public async Task<IEnumerable<DoctorScheduleModel>> GetPagedList(int pageNumber, int pageSize)
        {
            var schedule = await JsonSchedule();
            return await schedule.ToPagedListAsync(pageNumber, pageSize);
        }
    }
}
