using aspnetzabota.Common.Upload;
using aspnetzabota.Content.Database.Entities;
using aspnetzabota.Content.Database.Repository.DoctorInfo;
using aspnetzabota.Content.Datamodel.Doctors;
using AutoMapper;
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
        private readonly Random random = new Random();
        private readonly IDoctorInfoRepository _doctorInfoRepository;
        private readonly IMapper _mapper;
        private readonly IUpload _upload;
        public Schedule(IDoctorInfoRepository doctorInfoRepository, IMapper mapper, IUpload upload)
        {
            _doctorInfoRepository = doctorInfoRepository;
            _mapper = mapper;
            _upload = upload;
        }
        private IEnumerable<DoctorSchedule> RemoveNoReception(IEnumerable<DoctorSchedule> model)
        {
            string symb = "-";
            string phrase = "нет приема";
            foreach (var mod in model)
            {
                if (mod.Doctor.Schedule.Monday == phrase)
                    mod.Doctor.Schedule.Monday = symb;
                if (mod.Doctor.Schedule.Tuesday == phrase)
                    mod.Doctor.Schedule.Tuesday = symb;
                if (mod.Doctor.Schedule.Wednesday == phrase)
                    mod.Doctor.Schedule.Wednesday = symb;
                if (mod.Doctor.Schedule.Thursday == phrase)
                    mod.Doctor.Schedule.Thursday = symb;
                if (mod.Doctor.Schedule.Friday == phrase)
                    mod.Doctor.Schedule.Friday = symb;
                if (mod.Doctor.Schedule.Saturday == phrase)
                    mod.Doctor.Schedule.Saturday = symb;
                if (mod.Doctor.Schedule.Sunday == phrase)
                    mod.Doctor.Schedule.Sunday = symb;
            }
            return model;
        }
        private async Task<IEnumerable<DoctorSchedule>> JsonSchedule()
        {
                using (StreamReader sr = new StreamReader("wwwroot/json/schedule.json"))
                {
                    return RemoveNoReception(JsonConvert
                        .DeserializeObject<IEnumerable<DoctorSchedule>>(await sr.ReadToEndAsync()))
                        .OrderBy(c => c.CategoryName);
                }
        }
        private async Task<IEnumerable<DoctorSchedule>> ScheduleAtDoctors(bool OnlyComplete = false)
        {
            var doctors = await GetDoctorsInfo();
            var schedule = await JsonSchedule();
            foreach (var doctor in doctors)
            {
                if (!String.IsNullOrEmpty(schedule.FirstOrDefault(c => c.Doctor.Id == doctor.DoctorId).Doctor.Name))
                    schedule.FirstOrDefault(c => c.Doctor.Id == doctor.DoctorId).DoctorInfo = doctor;
            }
            if (OnlyComplete)
            {
                return schedule.Where(x => x.DoctorInfo != null);
            }
            else
            {
                return schedule;
            }
        }
        public async Task<IEnumerable<DoctorSchedule>> Get(bool OnlyComplete = false)
        {
            return await ScheduleAtDoctors(OnlyComplete);
        }

        public async Task<IEnumerable<string>> Posts()
        {
            var schedule = await Get();
            return schedule.Select(c => c.CategoryName).Distinct().ToList();
        }

        public async Task<DoctorSchedule> Single(int id)
        {
            var schedule = await Get();
            return schedule.FirstOrDefault(c => c.Doctor.Id == id);
        }

        public async Task<IEnumerable<DoctorSchedule>> ScheduleFromSinglePost(int cat_id)
        {
            var schedule = await Get();
            return schedule.Where(c => c.CategoryID == cat_id.ToString());
        }

        public async Task<IEnumerable<DoctorSchedule>> Random(int Count)
        {
            var schedule = await Get();
            return schedule.OrderBy(x => random.Next()).Take(Count);
        }

        public async Task<IEnumerable<DoctorSchedule>> GetPagedList(int pageNumber, int pageSize)
        {
            var schedule = await ScheduleAtDoctors();
            return await schedule.ToPagedListAsync(pageNumber, pageSize);
        }
        public async Task<IEnumerable<ZabotaDoctorInfo>> GetDoctorsInfo() 
        {
            var result = await _doctorInfoRepository.Get();
            return _mapper.Map<IEnumerable<ZabotaDoctorInfo>>(result);
        }
        public async Task<bool> AddDoctorInfo(ZabotaDoctorInfo model)
        {
            var schedule = await JsonSchedule();
            if (!String.IsNullOrEmpty(schedule.FirstOrDefault(c => c.Doctor.Id == model.DoctorId).Doctor.Name))
            {
                await _doctorInfoRepository.Add(model);
                return true;
            }
            else
            {
                return false;
            }
        }
        public async Task<bool> UpdateDoctorInfo(ZabotaDoctorInfo model)
        {
                await _doctorInfoRepository.Update(model);

                return true;
        }
        public async Task<bool> DeleteDoctorInfo(int id)
        {
            var result = await _doctorInfoRepository.GetSingle(id);
            _upload.DeleteImage(result.Photo);

            await _doctorInfoRepository.Delete(id);

            return true;
        }
    }
}
