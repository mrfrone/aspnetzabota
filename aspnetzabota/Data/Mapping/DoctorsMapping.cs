using aspnetzabota.Data.Models;
using System;
using System.Collections.Generic;
using System.Linq;

namespace aspnetzabota.Data.Mapping
{
    public static class DoctorsMapping
    {
        private static readonly Random random = new Random();
        public static List<string> Posts(IEnumerable<DoctorScheduleModel> Model) => Model.Select(c => c.category).Distinct().ToList();
        public static DoctorScheduleModel Single(int id, IEnumerable<DoctorScheduleModel> Model) => Model.FirstOrDefault(c => c.doctors.id == id.ToString());
        public static IEnumerable<DoctorScheduleModel> ScheduleFromSinglePost(int cat_id, IEnumerable<DoctorScheduleModel> Model) => Model.Where(c => c.cat_id == cat_id.ToString());
        public static IEnumerable<DoctorScheduleModel> Random(IEnumerable<DoctorScheduleModel> Model) => Model.OrderBy(x => random.Next()).TakeLast(4);
    }
}
