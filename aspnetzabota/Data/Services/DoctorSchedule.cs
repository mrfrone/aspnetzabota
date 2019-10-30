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
        private string JsonSchedule
        {
            get
            {
                using (StreamReader sr = new StreamReader("wwwroot/json/schedule.json"))
                {
                    return sr.ReadToEnd();
                }
            }
        }

        public IEnumerable<DoctorScheduleModel> AllSchedules => JsonConvert.DeserializeObject<IEnumerable<DoctorScheduleModel>>(JsonSchedule);
        public IEnumerable<DoctorScheduleModel> RandomSchedules 
        { 
            get 
            {
                IEnumerable<DoctorScheduleModel> elements = JsonConvert.DeserializeObject<IEnumerable<DoctorScheduleModel>>(JsonSchedule);
                
                return elements.OrderBy(x => random.Next()).TakeLast(4);
            } 
        } 
    }
}
